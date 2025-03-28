using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using dmacaspac201.Contracts.Users;
using dmacaspac201.Data.Models;
using dmacaspac201.Services;
using System.Data;
using System.Net.Mail;

namespace dmacaspac201.Components.Pages.Accounts
{
    public class RegisterModel : PageModel
    {
        private readonly IUserService _userService;

        public RegisterModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string FirstName { get; set; }

        [BindProperty]
        public string LastName { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var registerUserDto = new RegisterUserDto
            {
                EmailAddress = Email,
                FirstName = FirstName,
                LastName = LastName,
                Password = Password,
                Role = UserRole.Buyer // Set default role or get from input
            };

            await _userService.RegisterUser(registerUserDto);
            return RedirectToPage("Components/Accounts/Login"); 
        }
    }
}