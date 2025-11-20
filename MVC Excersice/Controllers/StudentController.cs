using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using MVC_Excersice.Models;
using System.Collections.Generic;

namespace MVC_Excersice.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentsRepository _repo = new StudentsRepository();

        // GET: /Student
        public IActionResult Student()
        {
            List<StudentDetails> students = _repo.GetStudents();
            return View("Index", students);
        }

        // GET: /Student/Details/1
        public IActionResult Details(int id)
        {
            var student = _repo.GetStudentByID(id);
            if (student == null) return NotFound();
            return View(student);
        }

        // GET: /Student/Add
        public IActionResult Add()
        {
            return View();
        }

        // POST: /Student/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(StudentDetails student)
        {
            if (ModelState.IsValid)
            {
                bool added = _repo.AddStudent(student);
                if (added)
                    return RedirectToAction(nameof(Student));
                else
                    ModelState.AddModelError("", "Error adding student. Check logs.");
            }
            return View(student);
        }

        // GET: /Student/Edit/1
        public IActionResult Edit(int id)
        {
            var student = _repo.GetStudentByID(id);
            if (student == null) return NotFound();
            return View(student);
        }

        // POST: /Student/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StudentDetails student)
        {
            if (ModelState.IsValid)
            {
                bool updated = _repo.UpdateStudent(student);
                if (updated)
                    return RedirectToAction(nameof(Student));
                else
                    ModelState.AddModelError("", "Error updating student. Check logs.");
            }
            return View(student);
        }

        // GET: /Student/Delete/1
        public IActionResult Delete(int id)
        {
            var student = _repo.GetStudentByID(id);
            if (student == null) return NotFound();
            return View(student);
        }

        // POST: /Student/Delete/1
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            bool deleted = _repo.DeleteStudent(id);
            return RedirectToAction(nameof(Student));
        }

        // Optional: Search by Name
        [HttpGet]
        public IActionResult Search(string name)
        {
            var results = _repo.SearchStudentsByName(name);
            return View("Index", results);
        }
    }
}
