using Microsoft.AspNetCore.Mvc;

namespace ERP_Demo.Controllers
{
    public class StudentController1 : Controller
    {
        //all students
        public IActionResult Index()
        {
            return View();
        }

        //inserting students
        public IActionResult AddStudent()
        {
            return View();
        }
    }
}
