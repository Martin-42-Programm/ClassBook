using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClassBook.Controllers
{
    public class TeacherController : Controller
    {
        private ITeacherService teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            this.teacherService = teacherService;
        }


        // GET: /<controller>/
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult List(string subject)
        {

            if (subject != null)
            {

                var listTeachers = teacherService.GetТeachersWithSubject(subject);

                return View(listTeachers);
            }

            return BadRequest("No subject defined!");
        }
    }
}

