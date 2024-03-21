using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SchoolDiary.Controllers
{
   
    public class AccountController : Controller
    {
        private readonly DataContext _dbContext; 
        private readonly IAccountService _accountService;
        public AccountController(DataContext dbContext, IAccountService accountService)
        {
            dbContext = dbContext;
            accountService = accountService;
        }
        
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]LoginModel model)
        {
            var user = _accountService.Authenticate(model.Login, model.Password);
            if (user != null)
            {
                return Ok(user);
            }
            return BadRequest(new { message = "wrong username or password." });
        }
       
        [HttpPost(nameof(RegisterStudent))]
        public async Task<IActionResult> RegisterStudent(RegisterStudentModel model)
        {
            if (dbContext.Users.Any(u => u.Login == model.Login))
            {
                ModelState.AddModelError("Error", "An account with this login already exists.");
            }
            if (ModelState.IsValid)
            {
                await _accountService.RegisterStudentAsync(model);
                return Ok();
            }
            return BadRequest(Json(ModelState));
        }
       
        [HttpPost("RegisterTeacher")]
        public async Task<IActionResult> RegisterTeacher(RegisterTeacherModel model)
        {
            if (_dbContext.Users.Any(u => u.Login == model.Login))
            {
                ModelState.AddModelError("Error", "An account with this login username already exists.");
            }
            if (ModelState.IsValid)
            {
                await accountService.RegisterTeacherAsync(model);
                return Ok();
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser([FromBody] int id)
        {
            if (id != 0)
            {
                var deletedUser = await _accountService.DeleteUserAsync(id);
                if (deletedUser != null)
                {
                    return Ok();
                }
            }
            ModelState.AddModelError("Error", "Cannot delete user because it does not exist.");
            return BadRequest(ModelState);
        }
    }
}
