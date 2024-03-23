// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClassBook.Data.Enums;
using ClassBook.Data.Entities;

namespace ClassBook.Areas.Identity.Pages.Account
{
    public class RegisterTeacherModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ITeacherService _teacherService;

        public RegisterTeacherModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ITeacherService teacherService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _teacherService = teacherService;
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
            [StringLength(
                100,
                ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
                MinimumLength = 2)]
            [Display(Name = "Subject")]
            public string Subject { get; set; }

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
                        var newTeacher = new CreateTeacherViewModel(user.Id, Input.Name, Input.Surname, Input.Subject);
                        _teacherService.Add(newTeacher);

                        await _userManager.AddToRoleAsync(user, UserRoles.Teacher.ToString());
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
            var newGuid = Guid.NewGuid().ToString();

            var newUser = new User(
                    newGuid,
                    Input.Email,
                    Input.Email);
            return newUser;

        }
    }
}
