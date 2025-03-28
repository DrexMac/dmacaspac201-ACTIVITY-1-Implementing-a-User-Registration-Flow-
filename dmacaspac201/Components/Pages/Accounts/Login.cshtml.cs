using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using dmacaspac201.Contracts.Users;
using dmacaspac201.Contracts.Security;
using System.Security.Claims;
using dmacaspac201.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace dmacaspac201.Components.Pages.Accounts
{
    public class LoginModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly HashHelper _hashHelper;

        public LoginModel(IUserService userService, HashHelper hashHelper)
        {
            _userService = userService;
            _hashHelper = hashHelper;
        }

        [BindProperty]
        public string Email { get; set; } = string.Empty;

        [BindProperty]
        public string Password { get; set; } = string.Empty;

        public IActionResult OnPost()
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                ModelState.AddModelError("", "Email and Password are required.");
                return Page();
            }

            var user = _userService.GetUserByEmail(Email);
            if (user == null || !_hashHelper.VerifyPassword(Password, user.PasswordHash))
            {
                ModelState.AddModelError("", "Invalid email or password.");
                return Page();
            }

            // Set authentication cookie
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.EmailAddress),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
            };

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
            return RedirectToPage("Components/Accounts/Login"); 
        }
    }
}