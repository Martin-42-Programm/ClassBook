using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SchoolDiary.Controllers
{
   
    public class TeacherController : Controller
    {
        ITeacherService teacherService;
        IMarkService _markService;
        public TeacherController(ITeacherService teacherService, IMarkService markService)
        {
            _teacherService = teacherService;
            _markService = markService;
        }
        
        public IActionResult GetPinnedClasses(int teacherId)
        {
            if (teacherId <= 0)
            {
                ModelState.AddModelError("Error", "Wrong teacher id.");
            }
            if (ModelState.IsValid)
            {
                var pinnedClasses = teacherService.GetPinnedClasses(teacherId);
                return Ok(pinnedClasses);
            }
            return BadRequest(ModelState);
        }
        [HttpGet(nameof(GetStudentMarks))]
        public IActionResult GetStudentMarks(int studentId, int subjectId, string firstDate, string lastDate)
        {
            if (!(studentId > 0 && subjectId > 0 && firstDate != null && lastDate != null))
            {
                ModelState.AddModelError("Error", "Data validation error.");
            }
            
            if (ModelState.IsValid)
            {
                
                var studentMarks = markService.GetConcreteStudentMarksBySubjectId(studentId, subjectId, firstDateObject, lastDateObject);
                if (studentMarks != null)
                {
                    return Ok(studentMarks);
                }
                ModelState.AddModelError("Error", "Failed to get student grades.");
                return BadRequest(ModelState);
            }
            return BadRequest(ModelState);
        }
        [HttpGet(nameof(GetAllMarks))]
        public IActionResult GetAllMarks()
        {
            var marks = markService.GetAllMarks();
            if (marks != null)
            {
                return Ok(marks);
            }
            ModelState.AddModelError("Error", "Failed to get grades data.");
            return BadRequest(ModelState);
        }
        [HttpPut(nameof(ChangeMark))]
        public IActionResult ChangeMark(MarkToChangeModel model)
        {
            if (ModelState.IsValid)
            {
                var changedMark = markService.ChangeMark(model);
                if (changedMark != null)
                {
                    return Ok();
                }
            }
            return BadRequest(ModelState);
        }
        [HttpPost(nameof(AddNewMark))]
        public IActionResult AddNewMark(MarkToAddModel model)
        {
            if (ModelState.IsValid)
            {
                var addedMark = _markService.AddNewMark(model);
                if (addedMark != null )
                {
                    return Ok(addedMark);
                }
            }
            return BadRequest(ModelState);
        }
    }
}
