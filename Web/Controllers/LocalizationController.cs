using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class LocalizationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SetLanguage(string culture, string returnURL)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName, // name of the cookie
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),  
                new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddDays(1),
                    IsEssential = true,
                } 
                );
            return Redirect(Request.GetTypedHeaders().Referer.ToString());
        }
    }
}
