using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ComputerShopMvc.Controllers
{
    public class ManufacturersController : Controller
    {
        Data.ComputerShopContext _dbContext;
        public ManufacturersController(Data.ComputerShopContext dbContext)
        {
            _dbContext = dbContext;
        }
        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 254)]
        public IActionResult Index()
        {
            return View(_dbContext.Manufacturers.ToList());
        }
    }
}

