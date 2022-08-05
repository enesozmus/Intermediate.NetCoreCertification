using Intermediate.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace Intermediate.MVC.Controllers
{
     public class HomeController : Controller
     {
          private readonly ILogger<HomeController> _logger;

          public HomeController(ILogger<HomeController> logger)
          {
               _logger = logger;
          }

          public IActionResult Index()
          {
               //ViewBag.BillType = new List<SelectListItem>()
               //{
               //     new SelectListItem() { Text = "Aidat", Value = "1" },
               //     new SelectListItem() { Text = "Dogalgaz", Value = "2" },
               //     new SelectListItem() { Text = "Su", Value = "3" },
               //     new SelectListItem() { Text = "Elektrik", Value = "4" },
               //     new SelectListItem() { Text = "Internet", Value = "5" }
               //};
               return View();
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