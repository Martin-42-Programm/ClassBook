using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ClassBook.Controllers;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClassBook.Controllers
{
    public class GradeController : Controller
    {
        private IGradeService gradeService;
        private ISubjectService subjectService;
        private IStudentService studentService;

        public GradeController(IGradeService gradeViewService, ISubjectService subjectService, IStudentService studentService)
        {
            this.gradeService = gradeViewService;
            this.subjectService = subjectService;
            this.studentService = studentService;
        }

        public IActionResult Create(string student)
        {
            var studentEntity = studentService.GetById(student);

            return View(studentEntity);

        }

        [HttpPost]
        public IActionResult Create(int number, string Class, double grade, string subject)
        {
            var studentId = studentService.GetStudentId(number, Class);
            var student = studentService.GetById(studentId);
            var subjectEntity = subjectService.GetSubjectById(subject);

            var gradeModel = new CreateGradeViewModel(
                                        student,
                                        student.ClassId,
                                        grade,
                                        subjectEntity);

            gradeService.Add(gradeModel);

            return RedirectToAction("ListByClass", "Student", new { Class = Class});
        }

        public IActionResult List(int numberInClass, string Class)
        {
            var gradeView = gradeService.GetAll(numberInClass, Class);

            return View(gradeView);
        }

        public IActionResult Delete(int gradeId)
        {
            gradeService.Delete(gradeId);

            return View(nameof(StudentController.List));
        }

    }
}

