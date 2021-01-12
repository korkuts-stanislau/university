using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ComputerShopMvc.Controllers
{
    public class CountriesController : Controller
    {
        Data.ComputerShopContext _dbContext;
        public CountriesController(Data.ComputerShopContext dbContext)
        {
            _dbContext = dbContext;
        }
        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 254)]
        public IActionResult Index()
        {
            return View(_dbContext.Countries.ToList());
        }
    }
}
