using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CosmosTableSamples;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class TypesController : Controller
    {
        private readonly StorageOperations _so;
        private readonly EntityOperations _eo;
        public TypesController()
        {
            _so = new StorageOperations();
            _eo = new EntityOperations();
        }
        
        public async Task<ActionResult> Index()
        {
            var typesTable = await _so.CreateTableAsync("Types");
            var types = _eo.GetTypes(typesTable);
            return View(types);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var CinemasTable = await _so.CreateTableAsync("Cinemas");
            var typesTable = await _so.CreateTableAsync("Types");
            await _eo.CascadeDeleteType(CinemasTable, typesTable, new CosmosTableSamples.Models.Type(id) { ETag = "*" });
            return RedirectToAction(nameof(Index));
        }
    }
}
