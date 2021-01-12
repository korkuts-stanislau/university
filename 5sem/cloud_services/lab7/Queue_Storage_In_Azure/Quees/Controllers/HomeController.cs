using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Quees.Models;

namespace Quees.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        public ActionResult Index(string text)
        {
            ViewData["result"] = text;
            return View();
        }

        [HttpPost]
        public ActionResult UploadMessage(string text)
        {
            Queue_Storage_In_Azure.QueueOperations operations = new Queue_Storage_In_Azure.QueueOperations();
            operations.AddMessage(text);
            return RedirectToAction("Index", new { text = "Текст добавлен" });
        }

        [HttpPost]
        public ActionResult DownloadMessage()
        {
            try
            {
                Queue_Storage_In_Azure.QueueOperations operations = new Queue_Storage_In_Azure.QueueOperations();
                return RedirectToAction("Index", new { text = operations.RetrieveMessage().AsString });
            }
            catch(NullReferenceException)
            {
                return RedirectToAction("Index", new { text = "В очереди нет сообщений" });
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
