using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassBook.Data.Entities;
using ClassBook.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClassBook.Controllers
{
    public class ClassController : Controller
    {

        private IClassService classService;

        public ClassController(IClassService classService)
        {
            this.classService = classService;
        }


        // GET: /<controller>/
        public IActionResult List()
        {
            var listClasses = classService.List();

            return View(listClasses);
        }

        public IActionResult Delete(string Class)
        {
            classService.Delete(Class);
            //var listClasses = classService.List();


            return RedirectToAction(nameof(List));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string Class)
        {

            if (Class == null)
                return View(nameof(Create));
            classService.Add(Class);

            return RedirectToAction(nameof(List));
        }
    }
}

