using System.Diagnostics;
using ERP_Demo.Models;
using ERP_Demo.Models.DATABASEFOLDER;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERP_Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly SchoolDB _db;

        public HomeController(ILogger<HomeController> logger, SchoolDB db)
        {
            _logger = logger;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var totalStudent = await _db.student.CountAsync();
            ViewBag.TotalStudents = totalStudent;
            return View();
        }

        //public IActionResult Index()
        //{
        //    var totalStudent = 
        //    ViewData["Title"] = "Dashboard";
        //    return View();
        //}

        public IActionResult Privacy()
        {
            ViewData["Title"] = "Privacy";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var model = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            ViewData["Title"] = "Error";
            return View(model);
        }
    }
}