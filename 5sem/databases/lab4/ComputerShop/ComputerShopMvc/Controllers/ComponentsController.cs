using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerShopMvc.Controllers
{
    public class ComponentsController : Controller
    {
        Data.ComputerShopContext _dbContext;
        public ComponentsController(Data.ComputerShopContext dbContext)
        {
            _dbContext = dbContext;
        }
        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 254)]
        public IActionResult Index()
        {
            return View(_dbContext.Components.Include(component => component.ComponentType)
                                             .Include(component => component.Country)
                                             .Include(component => component.Manufacturer)
                                             .Take(500)
                                             .ToList());
        }
    }
}
