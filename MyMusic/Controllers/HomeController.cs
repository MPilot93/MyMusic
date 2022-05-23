using Microsoft.AspNetCore.Mvc;
using MyMusic.Models;
using MyMusic.DBManage;
using System.Diagnostics;
using System.Data.SqlClient;

namespace MyMusic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BraniManager branoDB;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            branoDB = new BraniManager();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = branoDB.GetAll();

            return View(result);
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