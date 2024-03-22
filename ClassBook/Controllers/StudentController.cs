using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClassBook.Controllers
{
    public class StudentController : Controller
    {
        private IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        public IActionResult List()
        {
            var students = studentService.GetAll();
            return View(students);
        }

        public IActionResult ListByClass(string Class)
        {
            var listByClass = studentService.GetStudentsWithClass(Class);

            return View(listByClass);
        }
    }
}

