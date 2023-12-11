using Microsoft.AspNetCore.Mvc;
using PassmanWeb.Models;
using System.Diagnostics;

namespace PassmanWeb.Controllers
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
            // if the user logged in, return his name
            if (HttpContext.Session.GetString("Username") != null)
            {
                
                return View();
            }
            return View();
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}