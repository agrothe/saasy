using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SaaSy.Entity.Authorization;
using SaaSy.Web.Models;

namespace SaaSy.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if(HttpContext.Request.Path.Value.TrimStart('/') == "")
            {
                return RedirectToActionPermanentPreserveMethod("Index", "Home", new { locale = "en", tenant = "app" });
            }
            return View();
        }

        [AuthorizedTenant]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
