using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace SaaSy.Web.Controllers
{
    public class BaseController : Controller
    {
        private readonly IStringLocalizer Labels;

        public BaseController(IStringLocalizer localizer)
        {
            Labels = localizer;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}