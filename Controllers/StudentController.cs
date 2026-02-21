using System.Linq;
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

            ViewData["Title"] = "Add Student";
            return View(s);
        }

        // GET: /Student/Update/5
        public async Task<IActionResult> Update(int id)
        {
            var student = await db.student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            ViewData["Title"] = "Edit Student";
            return View(student);
        }

        // POST: /Student/Update/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Student s)
        {
            if (id != s.Student_roll)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                ViewData["Title"] = "Edit Student";
                return View(s);
            }

            try
            {
                db.Update(s);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!db.student.Any(e => e.Student_roll == id))
                    return NotFound();
                throw;
            }
        }

        // GET: /Student/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var student = await db.student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            ViewData["Title"] = "Delete Student";
            return View(student);
        }

        // POST: /Student/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await db.student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            db.student.Remove(student);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}