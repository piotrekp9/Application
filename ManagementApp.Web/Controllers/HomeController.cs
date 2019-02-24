using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ManagementApp.Web.Models;

namespace ManagementApp.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult About()
        {
            ViewData["Message"] = "Coś o aplikacji";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Strona kontaktowa";

            return View();
        }

        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
