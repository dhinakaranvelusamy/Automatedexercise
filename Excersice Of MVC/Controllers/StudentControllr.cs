/*using Excersice_Of_MVC.Models;
using Excersice_Of_MVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Excersice_Of_MVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly JasonCRUD _service;

        public StudentController()
        {
            _service = new JasonCRUD();
        }

        // GET: /Student/List
        public IActionResult List()
        {
            var students = _service.ReadJason();
            return View(students);
        }

        // GET: /Student/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Student/Create
        [HttpPost]
        public IActionResult Create(StudentInfo student)
        {
            if (ModelState.IsValid)
            {
                _service.AddJason(student);
                return RedirectToAction("List");
            }
            return View(student);
        }
    }
}
*/