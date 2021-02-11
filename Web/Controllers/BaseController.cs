using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Web.Controllers
{
    public class BaseController : Controller
    {
        public int currentUserId;
        public readonly ILogger<HomeController> _logger;

        public BaseController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!int.TryParse(context.HttpContext.User.Claims.FirstOrDefault()?.Value, out currentUserId))
            {
                HttpContext.SignOutAsync().Wait();
                context.Result = RedirectToAction("index", "user");
            }

            base.OnActionExecuting(context);
        }
    }
}