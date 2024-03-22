using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SchoolDiary.Controllers
{
  
    public class GradeController : Controller
    {
        private IGradesService gradesService;

        public GradeController(IGradesService gradesService)
        {
            this.gradesService = gradesService;
        }

        public IHttpActionResult GetGrade(int id)
        {
            if(gradesService.ExistsID(id) == false)
            {
                return NotFound();
            }
            return Ok(gradesService.GetByID(id));
        }

     
        public IHttpActionResult PutGrade(int id, Grade grade)
        {
            if (gradesService.ExistsID(id) == false)
            {
                return NotFound();
            }

            return Ok(gradesService.PutGrade(id, grade));
        }

       
        public IHttpActionResult DeleteGrade(int id)
        {
            if(gradesService.ExistsID(id) == false)
            {
                return NotFound();
            }
            return Ok(gradesService.DeleteByID(id));
        }
    }
}
