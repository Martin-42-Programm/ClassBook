using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClassBook.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Index()
        {
            var user = userService.GetAll();

            return View(user);
        }

        /*public async Task<IActionResult> IndexAsync()
        {
            var user = await userService.GetAllAsync();

            return View(user);
        }*/



        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}

