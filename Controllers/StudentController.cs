using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ERP_Demo.Models.DATABASEFOLDER;
using ERP_Demo.Models;

namespace ERP_Demo.Controllers
{
    public class StudentController : Controller
    {
        private readonly SchoolDB db;

        public StudentController(SchoolDB context)
        {
            db = context;
        }

        // GET: /Student
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Students";
            var students = await db.student.ToListAsync();
            return View(students);
        }

        public IActionResult add()
        {
            ViewData["Title"] = "Add Student";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> add(Student s)
        {
            if (ModelState.IsValid)
            {
                await db.student.AddAsync(s);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            // Return the model so validation messages & entered values persist
            ViewData["Title"] = "Add Student";
            return View(s);
        }

        // Shows the update/edit page for a student
        public IActionResult Update(int id)
        {
            ViewData["Title"] = "Edit Student";
            ViewData["StudentId"] = id;
            return View("update");
        }

        // Shows the delete confirmation page for a student
        public IActionResult Delete(int id)
        {
            ViewData["Title"] = "Delete Student";
            ViewData["StudentId"] = id;
            return View("delete");
        }
    }
}