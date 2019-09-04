using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SaaSy.Entity.Identity;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using SaaSy.Web.Resources.Areas.Identity.Pages.Account;

namespace SaaSy.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly IConfiguration _configuration;
        public IConfiguration Configuration => _configuration;

        public LoginModel(
            SignInManager<ApplicationUser> signInManager, 
            ILogger<LoginModel> logger,
            IConfiguration configuration)
        {
            _signInManager = signInManager;
            _logger = logger; 
            _configuration = configuration;
        }

        [BindProperty]
        public LoginViewModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }


        public class LoginViewModel
        {
            [Required(ErrorMessageResourceName = "EmailRequired", ErrorMessageResourceType = typeof(Login))]
            [EmailAddress(ErrorMessageResourceName = "InvalidEmail", ErrorMessageResourceType = typeof(Login))]
            [Display(Name = "Email", ResourceType = typeof(Login))]
            public string Email { get; set; }

            [Required(ErrorMessageResourceName = "PasswordRequired", ErrorMessageResourceType = typeof(Login))]
            [DataType(DataType.Password,ErrorMessageResourceName = "InvalidPassword", ErrorMessageResourceType = typeof(Login))]
            [Display(Name = "Password", ResourceType = typeof(Login))]
            public string Password { get; set; }

            [Display(Name = "RememberMe", ResourceType = typeof(Login))]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string locale, string tenant, string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl = returnUrl ?? Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();


            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    return LocalRedirect(returnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, Login.InvalidLoginAttempt);
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }


    }
}
