using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PageRole.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["result"] = "";
            return View();
        }
        [HttpPost]
        public ActionResult Index(string vector1, string vector2, string prod_types)
        {
            VectorLib.Vector vec1 = new VectorLib.Vector(vector1);
            VectorLib.Vector vec2 = new VectorLib.Vector(vector2);
            if (prod_types.Equals("vector"))
            {
                ViewData["result"] = vec1.multiply(vec2).ToString();
            }
            else
            {
                ViewData["result"] = vec1.dot(vec2).ToString();
            }
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}