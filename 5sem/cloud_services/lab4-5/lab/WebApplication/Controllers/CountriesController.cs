using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CosmosTableSamples;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class CountriesController : Controller
    {
        private readonly StorageOperations _so;
        private readonly EntityOperations _eo;
        public CountriesController()
        {
            _so = new StorageOperations();
            _eo = new EntityOperations();
        }
        // GET: CountriesController
        public async Task<ActionResult> Index()
        {
            var countriesTable = await _so.CreateTableAsync("countries");
            var countries = _eo.GetCountries(countriesTable);
            return View(countries);
        }

        // GET: CountriesController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var phonesTable = await _so.CreateTableAsync("phones");
            var countriesTable = await _so.CreateTableAsync("countries");
            await _eo.CascadeDeleteCountry(phonesTable, countriesTable, new CosmosTableSamples.Models.Country(id) { ETag = "*" });
            return RedirectToAction(nameof(Index));
        }
    }
}
