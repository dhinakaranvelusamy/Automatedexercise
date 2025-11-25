using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MVC_Excersice.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentsRepository _repo = new StudentsRepository();

        // LIST
        public IActionResult Student()
        {
            List<StudentDetails> students = _repo.GetStudents();
            return View("Index", students);
        }

        // DETAILS
        public IActionResult Details(int id)
        {
            var student = _repo.GetStudentByID(id);
            if (student == null) return NotFound();

            return View(student);
        }

        // ADD GET
        public IActionResult Add()
        {
            return View();
        }

        // ADD POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(StudentDetails student)
        {
            if (ModelState.IsValid)
            {
                if (_repo.AddStudent(student))
                    return RedirectToAction(nameof(Student));
            }
            return View(student);
        }

        // EDIT GET
        public IActionResult Edit(int id)
        {
            var student = _repo.GetStudentByID(id);
            if (student == null) return NotFound();

            return View(student);
        }

        // EDIT POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StudentDetails student)
        {
            if (ModelState.IsValid)
            {
                if (_repo.UpdateStudent(student))
                    return RedirectToAction(nameof(Student));
            }
            return View(student);
        }

        // DELETE GET
        public IActionResult Delete(int id)
        {
            var student = _repo.GetStudentByID(id);
            if (student == null) return NotFound();

            return View(student);
        }

        // DELETE POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _repo.DeleteStudent(id);
            return RedirectToAction(nameof(Student));
        }
    }
}
