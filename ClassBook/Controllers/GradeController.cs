using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClassBook.Controllers
{
    public class GradeController : Controller
    {
        private IGradeService gradeService;

        public GradeController(IGradeService gradeViewService)
        {
            this.gradeService = gradeViewService;
        }

        public IActionResult Create()
        {
         

            return View();
        }

        public IActionResult List(int id)
        {
            var gradeView = gradeService.GetAll(id);

            return View(gradeView);
        }

        
    }
}

