using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ComputerShopContext db = new ComputerShopContext();
            Task1(db);
            Task2(db);
            Task3(db);
            Task4(db);
            Task5(db);
            Task6(db);
            Task7(db);
            Task8(db);
            Task9(db);
            Task10(db);
        }

        static void Print(string sqltext, IEnumerable items)
        {
            Console.WriteLine(sqltext);
            Console.WriteLine("Записи: ");
            foreach (var item in items)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();
        }

        static void Task1(ComputerShopContext db)
        {
            var countries = db.Countries
                .Select(c => c);
            Print("Результат выборки из таблицы Countries", countries.Take(5).ToList());
        }

        static void Task2(ComputerShopContext db)
        {
            var customers = db.Customers
                .Where(c => c.CustomerDiscount < 30)
                .Select(c => c);
            Print("Результат выборки из таблицы Customers.\n" +
                "Ограничение на поле CustomerDiscount (< 30).", customers.Take(5).ToList());
        }

        static void Task3(ComputerShopContext db)
        {
            var orders = db.Orders
                .GroupBy(c => c.OrderCustomer.CustomerDiscount)
                .Average(c => c.Key);
            Console.WriteLine($"Средняя скидка по всем клиентам {orders}");
        }

        static void Task4(ComputerShopContext db)
        {
            var ordersPlusCustomers = db.Orders
                .Join(db.Customers, order => order.OrderCustomerId, customer => customer.CustomerId,
                (order, customer) => new
                {
                    order.OrderStartDate.Date,
                    order.OrderExecutionDate,
                    customer.CustomerFullName,
                    customer.CustomerAddress,
                    customer.CustomerPhoneNumber,
                    customer.CustomerDiscount,
                    order.OrderPaid,
                    order.OrderFinished
                });
            Print("Результат выборки из таблиц Orders и Customers.", ordersPlusCustomers.Take(5).ToList());
        }

        static void Task5(ComputerShopContext db)
        {
            var ordersPlusCustomers = db.Orders
                .Where(order => order.OrderPaid)
                .Join(db.Customers, order => order.OrderCustomerId, customer => customer.CustomerId,
                (order, customer) => new
                {
                    order.OrderStartDate.Date,
                    order.OrderExecutionDate,
                    customer.CustomerFullName,
                    customer.CustomerAddress,
                    customer.CustomerPhoneNumber,
                    customer.CustomerDiscount,
                    order.OrderFinished
                });
            Print("Результат выборки из таблиц Orders и Customers с фильтром по полю OrderPaid. " +
                "Вывести только оплаченные заказы", ordersPlusCustomers.Take(5).ToList());
        }

        static void Task6(ComputerShopContext db)
        {
            Service service = new Service
            {
                ServiceName = "TestService",
                ServiceDescription = "TestServiceDecription",
                ServicePrice = 1000
            };
            db.Services.Add(service);
            db.SaveChanges();
            Console.WriteLine("Сервис добавлен");
        }

        static void Task7(ComputerShopContext db)
        {
            Random rand = new Random();
            ComponentType componentType = db.ComponentTypes.ToList().ElementAt(rand.Next(0, db.ComponentTypes.Count() - 1));
            Manufacturer manufacturer = db.Manufacturers.ToList().ElementAt(rand.Next(0, db.Manufacturers.Count() - 1));
            Country country = db.Countries.ToList().ElementAt(rand.Next(0, db.Countries.Count() - 1));
            Component component = new Component
            {
                ComponentType = componentType,
                ComponentTypeId = componentType.ComponentTypeId,
                ComponentModel = "TestComponentModel",
                ComponentManufacturer = manufacturer,
                ComponentManufacturerId = manufacturer.ManufacturerId,
                ComponentCountry = country,
                ComponentCountryId = country.CountryId,
                ComponentReleaseDate = DateTime.Now,
                ComponentCharacteristics = "TestCharacteristics",
                ComponentWarrantyInMonths = rand.Next(6, 36),
                ComponentDescription = "TestDescription",
                ComponentPrice = rand.Next(100, 3000)
            };
            db.Components.Add(component);
            db.SaveChanges();
            Console.WriteLine("Компонент добавлен");
        }

        static void Task8(ComputerShopContext db)
        {
            db.Services.Remove(db.Services.ToList()[db.Services.Count() - 1]);
            db.SaveChanges();
            Console.WriteLine("Услуга удалена");
        }

        static void Task9(ComputerShopContext db)
        {
            db.Components.Remove(db.Components.ToList()[db.Components.Count() - 1]);
            db.SaveChanges();
            Console.WriteLine("Компонент удалён");
        }

        static void Task10(ComputerShopContext db)
        {
            var lowcostServices = db.Services.Where(service => service.ServicePrice < 1000);
            foreach(var service in lowcostServices)
            {
                service.ServicePrice *= (decimal)1.01;
            }
            db.SaveChanges();
            Console.WriteLine("Стоимость услуг, стоящих меньше 1000 увеличена на 1%");
        }
    }
}
