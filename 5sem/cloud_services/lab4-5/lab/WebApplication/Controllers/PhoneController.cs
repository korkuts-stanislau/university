using System;
using CosmosTableSamples;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos.Table;

namespace WebApplication.Controllers
{
    public class PhoneController : Controller
    {
        private readonly StorageOperations _so;
        private readonly EntityOperations _eo;
        public PhoneController()
        {
            _so = new StorageOperations();
            _eo = new EntityOperations();
        }
        // GET: PhoneController
        public async Task<ActionResult> Index()
        {
            var phonesTable = await _so.CreateTableAsync("phones");
            var manufacturersTable = await _so.CreateTableAsync("manufacturers");
            var countriesTable = await _so.CreateTableAsync("countries");
            var phones = _eo.GetPhones(phonesTable);
            var manufacturers = _eo.GetManufacturers(manufacturersTable);
            var countries = _eo.GetCountries(countriesTable);

            ViewModels.IndexPhoneViewModel model = new ViewModels.IndexPhoneViewModel
            {
                Phones = phones,
                Manufacturers = new Dictionary<string, string>(manufacturers.Select(m => new KeyValuePair<string, string>(m.RowKey, m.Name)).ToList()),
                Countries = new Dictionary<string, string>(countries.Select(m => new KeyValuePair<string, string>(m.RowKey, m.Name)).ToList())
            };
            return View(model);
        }

        // GET: PhoneController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PhoneController/Create
        public async Task<ActionResult> Create()
        {
            var manufacturersTable = await _so.CreateTableAsync("manufacturers");
            var countriesTable = await _so.CreateTableAsync("countries");
            var manufacturers = _eo.GetManufacturers(manufacturersTable);
            var countries = _eo.GetCountries(countriesTable);

            ViewModels.CreatePhoneViewModel model = new ViewModels.CreatePhoneViewModel
            {
                Manufacturers = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(manufacturers, "RowKey", "Name"),
                Countries = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(countries, "RowKey", "Name")
            };
            return View(model);
        }

        // POST: PhoneController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(int? countryId, int? manufacturerId, string modelName, int? price)
        {
            try
            {
                var phonesTable = await _so.CreateTableAsync("phones");
                int maxId = _eo.GetPhones(phonesTable).Select(p => int.Parse(p.RowKey)).Max();
                CosmosTableSamples.Models.Phone phone = new CosmosTableSamples.Models.Phone(maxId + 1)
                {
                    ModelName = modelName,
                    ManufacturerId = manufacturerId ?? 1,
                    CountryId = countryId ?? 1,
                    Price = price ?? 100
                };
                await _eo.InsertOrMergePhoneAsync(phonesTable, phone);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var manufacturersTable = await _so.CreateTableAsync("manufacturers");
                var countriesTable = await _so.CreateTableAsync("countries");
                var manufacturers = _eo.GetManufacturers(manufacturersTable);
                var countries = _eo.GetCountries(countriesTable);

                ViewModels.CreatePhoneViewModel model = new ViewModels.CreatePhoneViewModel
                {
                    Manufacturers = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(manufacturers, "RowKey", "Name"),
                    Countries = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(countries, "RowKey", "Name")
                };
                return View(model);
            }
        }

        // GET: PhoneController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var manufacturersTable = await _so.CreateTableAsync("manufacturers");
            var countriesTable = await _so.CreateTableAsync("countries");
            var manufacturers = _eo.GetManufacturers(manufacturersTable);
            var countries = _eo.GetCountries(countriesTable);

            var phonesTable = await _so.CreateTableAsync("phones");
            var phone = _eo.GetPhones(phonesTable).FirstOrDefault(p => int.Parse(p.RowKey) == id);

            ViewModels.CreatePhoneViewModel model = new ViewModels.CreatePhoneViewModel
            {
                Manufacturers = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(manufacturers, "RowKey", "Name", phone.ManufacturerId.ToString()),
                Countries = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(countries, "RowKey", "Name", phone.CountryId.ToString())
            };

            ViewBag.Phone = phone;

            return View(model);
        }

        // POST: PhoneController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, int? countryId, int? manufacturerId, string modelName, int? price)
        {
            try
            {
                CosmosTableSamples.Models.Phone phone = new CosmosTableSamples.Models.Phone(id)
                {
                    ModelName = modelName,
                    ManufacturerId = manufacturerId ?? 1,
                    CountryId = countryId ?? 1,
                    Price = price ?? 100
                };
                var phonesTable = await _so.CreateTableAsync("phones");
                await _eo.InsertOrMergePhoneAsync(phonesTable, phone);
                return RedirectToAction(nameof(Index));
            }
            catch
            {

                var manufacturersTable = await _so.CreateTableAsync("manufacturers");
                var countriesTable = await _so.CreateTableAsync("countries");
                var manufacturers = _eo.GetManufacturers(manufacturersTable);
                var countries = _eo.GetCountries(countriesTable);

                var phonesTable = await _so.CreateTableAsync("phones");
                var phone = _eo.GetPhones(phonesTable).FirstOrDefault(p => int.Parse(p.RowKey) == id);

                ViewModels.CreatePhoneViewModel model = new ViewModels.CreatePhoneViewModel
                {
                    Manufacturers = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(manufacturers, "RowKey", "Name", phone.ManufacturerId.ToString()),
                    Countries = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(countries, "RowKey", "Name", phone.CountryId.ToString())
                };

                ViewBag.Phone = phone;

                return View();
            }
        }

        // GET: PhoneController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var phonesTable = await _so.CreateTableAsync("phones");
            await _eo.DeletePhoneAsync(phonesTable, new CosmosTableSamples.Models.Phone(id) { ETag = "*" });
            return RedirectToAction(nameof(Index));
        }
    }
}
