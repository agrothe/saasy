using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SaaSy.Entity.Identity;
using SaaSy.Web.Resources.Areas.Identity.Pages.Account.Manage;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace SaaSy.Web.Areas.Identity.Pages.Account.Manage
{
    public class ChangePasswordModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<ChangePasswordModel> _logger;

        public ChangePasswordModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<ChangePasswordModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public class InputModel
        {
            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "CurrentPassword", ResourceType = typeof(ChangePassword))]
            public string OldPassword { get; set; }

            [Required]
            [StringLength(100, ErrorMessageResourceName = "PasswordInvalid", ErrorMessageResourceType = typeof(ChangePassword), MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "NewPassword", ResourceType = typeof(ChangePassword))]
            public string NewPassword { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "ConfirmPassword", ResourceType = typeof(ChangePassword))]
            [Compare("NewPassword", ErrorMessageResourceName = "ConfirmPasswordInvalid", ErrorMessageResourceType = typeof(ChangePassword))]
            public string ConfirmPassword { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound(string.Format(ChangePassword.UnableToLoadUser, _userManager.GetUserId(User)));
            }

            var hasPassword = await _userManager.HasPasswordAsync(user);
            if (!hasPassword)
            {
                return RedirectToPage("./SetPassword");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound(string.Format(ChangePassword.UnableToLoadUser, _userManager.GetUserId(User)));
            }

            var changePasswordResult = await _userManager.ChangePasswordAsync(user, Input.OldPassword, Input.NewPassword);
            if (!changePasswordResult.Succeeded)
            {
                foreach (var error in changePasswordResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return Page();
            }

            await _signInManager.RefreshSignInAsync(user);
            _logger.LogInformation("User changed their password successfully.");
            StatusMessage = ChangePassword.PasswordChanged;

            return RedirectToPage();
        }
    }
}
