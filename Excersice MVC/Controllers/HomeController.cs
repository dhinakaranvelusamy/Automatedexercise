using Excersice_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JasonLibrary;  
using StudentLibrary;
using System.Collections.Generic;
using System.Diagnostics;

namespace Excersice_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly JasonCRUD _service;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _service = new JasonCRUD(); 
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult List()
        {
            List<StudentInfo> students = _service.ReadJason();
            return View(students);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
