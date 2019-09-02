using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using SaaSy.Resource;

namespace SaaSy.Web.Controllers
{
    public class BaseController : Controller
    {
        private readonly IStringLocalizer<Labels> Labels;

        public BaseController(IStringLocalizer<Labels> localizer)
        {
            Labels = localizer;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}