using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassBook.Services;
using ClassBook.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClassBook.Controllers
{
    public class SubjectController : Controller
    {

        private ISubjectService subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            this.subjectService = subjectService;
        }



        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            var listSubjects = subjectService.List();

            return View(listSubjects);
        }

        public IActionResult Delete(Subject subject)
        {
            subjectService.Delete(subject);

            return View(nameof(List));
        }

        public IActionResult Add(Subject subject)
        {
            subjectService.Add(subject);

            return View(nameof(List));
        }
    }
}

