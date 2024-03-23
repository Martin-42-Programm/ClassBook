// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClassBook.Data.Enums;
using ClassBook.Data.Entities;
using ClassBook.Models.Student;

namespace ClassBook.Areas.Identity.Pages.Account
{
    public class RegisterStudentModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IStudentService _studentService;

        public RegisterStudentModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IStudentService studentService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _studentService = studentService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(
                100,
                ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
                MinimumLength = 2)]
            [Display(Name = "Name")]
            public string Name { get; set; }

            [Required]
            [StringLength(
                100,
                ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
                MinimumLength = 2)]
            [Display(Name = "Surname")]
            public string Surname { get; set; }

            [Required]
            [Range(
                1, 30,
                ErrorMessage = "Number in class must be an integer number between {0} and {1}")]
            [Display(Name = "NumberInClass")]
            public int NumberInClass { get; set; }

            [Required]
            [StringLength(
                3,
                ErrorMessage = "The {0} must be at least {2} and at max {1} characters long. It should contain grade and parallelClass without spaces!",
                MinimumLength = 2)]
            [RegularExpression(@"^[1234567890abcdefgh]+$", ErrorMessage = "The string must only contain '1234567890abcdefgh' and no spaces.")]
            [Display(Name = "Class")]
            public string Class { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                var user = CreateUser();

                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    try
                    {
                        var newStudent = new CreateStudentViewModel(
                            user.Id,
                            Input.Name,
                            Input.NumberInClass,
                            Input.Surname,
                            Input.Class);
                        _studentService.Add(newStudent);
                        await _userManager.AddToRoleAsync(user, UserRoles.Student.ToString());
                    }
                    catch (Exception)
                    {
                        await _userManager.DeleteAsync(user);

                        ModelState.AddModelError(string.Empty, "Registration error");

                        return Page();
                    }

                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return LocalRedirect(returnUrl);
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        private User CreateUser()
          
            {
            var newUser = new User(
            Guid.NewGuid().ToString(),
            Input.Email,
            Input.Name);

                return newUser;
            }
    }
}
