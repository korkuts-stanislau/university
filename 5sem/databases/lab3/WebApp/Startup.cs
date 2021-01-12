using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Microsoft.Extensions.Caching.Memory;
using System.Net;

namespace WebApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup()
        {

        }
        public void ConfigureServices(IServiceCollection services)
        {
            //Подключаем базу данных к сервисам
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<ComputerShopContext>(options => options.UseSqlServer(connectionString));
            //Добавление кеширования
            services.AddMemoryCache();
            services.AddDistributedMemoryCache();
            //Добавление сессий
            services.AddSession();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ComputerShopContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseSession();
            app.UseCachingMiddleware();


            app.Map("/info", Info);
            app.Map("/services", Services);
            app.Map("/searchform", SearchForm);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    StringBuilder htmlBuilder = new StringBuilder();
                    htmlBuilder.Append("<a href=\"/info\"><h2>Info</h2></a>");
                    htmlBuilder.Append("<a href=\"/services\"><h2>Services</h2></a>");
                    htmlBuilder.Append("<a href=\"/searchform\"><h2>SearchForm</h2></a>");
                    await context.Response.WriteAsync(htmlBuilder.ToString());
                });
            });
        }

        public void Info(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                StringBuilder htmlBuilder = new StringBuilder();
                htmlBuilder.Append("<a href=\"/\"<h2>Back</h2></a></br>");
                htmlBuilder.Append(context.Request.Headers["User-Agent"]);
                await context.Response.WriteAsync(htmlBuilder.ToString());
            });
        }

        public void Services(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                StringBuilder htmlBuilder = new StringBuilder();
                htmlBuilder.Append("<a href=\"/\"<h2>Back</h2></a></br>");
                IEnumerable<Service> services = (IEnumerable<Service>)context.RequestServices.GetService<IMemoryCache>().Get("services");
                htmlBuilder.Append(GetServicesHtmlTableFromEnumerable(services));
                await context.Response.WriteAsync(htmlBuilder.ToString());
            });
        }
        public void SearchForm(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                string component, customerMaxDiscount;
                GetFieldValuesFromCookies(context, out component, out customerMaxDiscount);
                StringBuilder htmlBuilder = new StringBuilder();
                htmlBuilder.Append("<a href=\"/\"<h2>Back</h2></a></br>");
                htmlBuilder.Append("<form action=\"/searchform\">" +
                                    "<h3>Select table</h3>" +
                                    "<select name=\"tables\">" +
                                        "<option>Customers</option>" +
                                        "<option>Components</option>" +
                                    "</select>" +
                                    "<h3>Enter part of a name of component</h3>" +
                                    $"<input name=\"componentInput\" value=\"{component}\">" +
                                    "<h3>Enter max discount of customer</h3>" +
                                    $"<input name=\"customerMaxDiscountInput\" value=\"{customerMaxDiscount}\">" +
                                    "<br><br>" +
                                    "<button type='submit'>Confirm</button>" +
                                "</form>");
                if (context.Request.Query["componentInput"] != "" && context.Request.Query["tables"] == "Components")
                {
                    var components = context.Session.Get<List<Component>>("components" + context.Request.Query["componentInput"]) ??
                        context.RequestServices.GetService<ComputerShopContext>().Components
                        .Where(component => component.ComponentType.ComponentTypeName.Contains(context.Request.Query["componentInput"]))
                        .Take(50)
                        .ToList();
                    htmlBuilder.Append(MakeComponentsTableFromEnumerable(components));
                    context.Session.Set("components" + context.Request.Query["componentInput"], components);
                }
                else if (context.Request.Query["customerMaxDiscountInput"] != "" && context.Request.Query["tables"] == "Customers")
                {
                    var customers = context.Session.Get<List<Customer>>("customers" + context.Request.Query["customerMaxDiscountInput"]) ??
                        context.RequestServices.GetService<ComputerShopContext>().Customers
                        .Where(customer => customer.CustomerDiscount < int.Parse(context.Request.Query["customerMaxDiscountInput"]))
                        .Take(50)
                        .ToList();
                    htmlBuilder.Append(MakeCustomersHtmlTableFromEnumerable(customers));
                    context.Session.Set("customers" + context.Request.Query["customerMaxDiscountInput"], customers);
                }
                await context.Response.WriteAsync(htmlBuilder.ToString());
            });
        }

        private static void GetFieldValuesFromCookies(HttpContext context, out string component, out string customerMaxDiscount)
        {
            component = context.Request.Query["componentInput"];
            customerMaxDiscount = context.Request.Query["customerMaxDiscountInput"];
            if (component != null)
            {
                context.Response.Cookies.Append("componentType", component);
            }
            else if (context.Request.Cookies["componentType"] != null)
            {
                component = context.Request.Cookies["componentType"];
            }
            if (customerMaxDiscount != null)
            {
                context.Response.Cookies.Append("customerMaxDiscount", customerMaxDiscount);
            }
            else if (context.Request.Cookies["customerMaxDiscount"] != null)
            {
                customerMaxDiscount = context.Request.Cookies["customerMaxDiscount"];
            }
        }

        private string GetServicesHtmlTableFromEnumerable(IEnumerable<Service> services)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<H1>Services Table</H1>" +
                            "<TABLE BORDER=1>");
            builder.Append("<TD>Id</TD>");
            builder.Append("<TD>Service name</TD>");
            builder.Append("<TD>Service description</TD>");
            builder.Append("<TD>Service Price</TD>");
            foreach (var service in services)
            {
                builder.Append("<TR>");
                builder.Append("<TD>" + service.ServiceId + "</TD>");
                builder.Append("<TD>" + service.ServiceName + "</TD>");
                builder.Append("<TD>" + service.ServiceDescription + "</TD>");
                builder.Append("<TD>" + service.ServicePrice + "</TD>");
                builder.Append("</TR>");
            }
            builder.Append("</TABLE>");
            return builder.ToString();
        }

        private string MakeCustomersHtmlTableFromEnumerable(IEnumerable<Customer> customers)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<H1>Customers Table</H1>" +
                            "<TABLE BORDER=1>");
            builder.Append("<TD>Id</TD>");
            builder.Append("<TD>Full Name</TD>");
            builder.Append("<TD>Address</TD>");
            builder.Append("<TD>Phone Number</TD>");
            builder.Append("<TD>Discount</TD>");
            foreach (var customer in customers)
            {
                builder.Append("<TR>");
                builder.Append("<TD>" + customer.CustomerId + "</TD>");
                builder.Append("<TD>" + customer.CustomerFullName + "</TD>");
                builder.Append("<TD>" + customer.CustomerAddress + "</TD>");
                builder.Append("<TD>" + customer.CustomerPhoneNumber + "</TD>");
                builder.Append("<TD>" + customer.CustomerDiscount + "</TD>");
                builder.Append("</TR>");
            }
            builder.Append("</TABLE>");
            return builder.ToString();
        }

        private string MakeComponentsTableFromEnumerable(IEnumerable<Component> components)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<H1>Components Table</H1>" +
                            "<TABLE BORDER=1>");
            builder.Append("<TD>Id</TD>");
            builder.Append("<TD>ComponentTypeId</TD>");
            builder.Append("<TD>Model</TD>");
            builder.Append("<TD>ManufacturerId</TD>");
            builder.Append("<TD>CountryId</TD>");
            builder.Append("<TD>Release Date</TD>");
            builder.Append("<TD>Characteristics</TD>");
            builder.Append("<TD>WarrantyPeriodInMonths</TD>");
            builder.Append("<TD>Description</TD>");
            builder.Append("<TD>Price</TD>");
            foreach (var component in components)
            {
                builder.Append("<TR>");
                builder.Append("<TD>" + component.ComponentId + "</TD>");
                builder.Append("<TD>" + component.ComponentTypeId + "</TD>");
                builder.Append("<TD>" + component.ComponentModel + "</TD>");
                builder.Append("<TD>" + component.ComponentManufacturerId + "</TD>");
                builder.Append("<TD>" + component.ComponentCountryId + "</TD>");
                builder.Append("<TD>" + component.ComponentReleaseDate + "</TD>");
                builder.Append("<TD>" + component.ComponentCharacteristics + "</TD>");
                builder.Append("<TD>" + component.ComponentWarrantyInMonths + "</TD>");
                builder.Append("<TD>" + component.ComponentDescription + "</TD>");
                builder.Append("<TD>" + component.ComponentPrice + "</TD>");
                builder.Append("</TR>");
            }
            builder.Append("</TABLE>");
            return builder.ToString();
        }
    }
}
