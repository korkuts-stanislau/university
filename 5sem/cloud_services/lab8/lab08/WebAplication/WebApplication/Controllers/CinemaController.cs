using System;
using CosmosTableSamples;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos.Table;
using WebApplication.ViewModels;
using CosmosTableSamples.Models;

namespace WebApplication.Controllers
{
    public class CinemaController : Controller
    {
        private readonly StorageOperations _so;
        private readonly EntityOperations _eo;

        public CinemaController()
        {
            _so = new StorageOperations();
            _eo = new EntityOperations();
        }

        public async Task<ActionResult> Index()
        {
            var cinemasTable = await _so.CreateTableAsync("Cinemas");
            var citiesTable = await _so.CreateTableAsync("Cities");
            var typesTable = await _so.CreateTableAsync("Types");

            var cinemas = _eo.GetCinemas(cinemasTable);
            var cities = _eo.GetCities(citiesTable);
            var types = _eo.GetTypes(typesTable);

            CinemaViewModel model = new CinemaViewModel
            {
                Cinemas = cinemas,
                Cities = new Dictionary<string, string>(cities.Select(m => new KeyValuePair<string, string>(m.RowKey, m.Name)).ToList()),
                Types = new Dictionary<string, string>(types.Select(m => new KeyValuePair<string, string>(m.RowKey, m.Name)).ToList())
            };
            return View(model);
        }

        public async Task<ActionResult> Create()
        {
            var citiesTable = await _so.CreateTableAsync("Cities");
            var typesTable = await _so.CreateTableAsync("Types");

            var cities = _eo.GetCities(citiesTable);
            var types = _eo.GetTypes(typesTable);

            CreateCinemaViewModel model = new CreateCinemaViewModel
            {
                Cities = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(cities, "RowKey", "Name"),
                Types = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(types, "RowKey", "Name")
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(int? typeId, int? cityId, string name, int? capacity)
        {
            try
            {
                var cinemasTable = await _so.CreateTableAsync("Cinemas");
                int maxId = _eo.GetCinemas(cinemasTable).Select(p => p.RowKey).Count();
                Cinema cinema = new Cinema(maxId + 1)
                {
                    Name = name,
                    CityId = cityId ?? 1,
                    TypeId = typeId ?? 1,
                    Capacity = capacity ?? 1
                };

                await _eo.InsertOrMergeCinemaAsync(cinemasTable, cinema);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var citiesTable = await _so.CreateTableAsync("Cities");
                var typesTable = await _so.CreateTableAsync("Types");
                var Cities = _eo.GetCities(citiesTable);
                var types = _eo.GetTypes(typesTable);

                CreateCinemaViewModel model = new CreateCinemaViewModel
                {
                    Cities = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(Cities, "RowKey", "Name"),
                    Types = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(types, "RowKey", "Name")
                };

                return View(model);
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            var citiesTable = await _so.CreateTableAsync("Cities");
            var typesTable = await _so.CreateTableAsync("Types");

            var cities = _eo.GetCities(citiesTable);
            var types = _eo.GetTypes(typesTable);

            var cinemasTable = await _so.CreateTableAsync("Cinemas");
            var cinema = _eo.GetCinemas(cinemasTable).FirstOrDefault(p => int.Parse(p.RowKey) == id);

            CreateCinemaViewModel model = new CreateCinemaViewModel
            {
                Cities = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(cities, "RowKey", "Name", cinema.CityId.ToString()),
                Types = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(types, "RowKey", "Name", cinema.TypeId.ToString())
            };

            ViewBag.Cinema = cinema;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, int? typeId, int? cityId, string name, int? capacity)
        {
            try
            {
                Cinema Cinema = new Cinema(id)
                {
                    Name = name,
                    CityId = cityId ?? 1,
                    TypeId = typeId ?? 1,
                    Capacity = capacity ?? 1
                };

                var cinemasTable = await _so.CreateTableAsync("Cinemas");
                await _eo.InsertOrMergeCinemaAsync(cinemasTable, Cinema);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var citiesTable = await _so.CreateTableAsync("Cities");
                var typesTable = await _so.CreateTableAsync("Types");
                var cities = _eo.GetCities(citiesTable);
                var types = _eo.GetTypes(typesTable);

                var cinemasTable = await _so.CreateTableAsync("Cinemas");
                var cinema = _eo.GetCinemas(cinemasTable).FirstOrDefault(p => int.Parse(p.RowKey) == id);

                CreateCinemaViewModel model = new CreateCinemaViewModel
                {
                    Cities = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(cities, "RowKey", "Name", cinema.CityId.ToString()),
                    Types = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(types, "RowKey", "Name", cinema.TypeId.ToString())
                };

                ViewBag.Cinema = cinema;

                return View();
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            var cinemasTable = await _so.CreateTableAsync("Cinemas");
            await _eo.DeleteCinemaAsync(cinemasTable, new Cinema(id) { ETag = "*" });
            return RedirectToAction(nameof(Index));
        }
    }
}
