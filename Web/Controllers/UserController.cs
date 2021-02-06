using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Web.Db;
using Web.Infrastructure;

namespace Web.Controllers
{
    public class UserController : Controller
    {
        protected AppDbContext _dbContext;
        private readonly IStringLocalizer<UserController> _localizer;

        public UserController(AppDbContext dbContext, IStringLocalizer<UserController> localizer)
        {
            _dbContext = dbContext;
            _localizer = localizer;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new Models.User.Login());
        }

        [HttpPost]
        [ModelStateValidationFilter]
        public async Task<IActionResult> Index(Models.User.Login model, string returnUrl = "")
        {
            var hashedPassword = MD5Hash(model.Password);
            var user = _dbContext.User
                 .FirstOrDefault(x =>
                 x.Password == hashedPassword
                 && x.Email == model.Email);

            if (user == null)
            {
                ModelState.AddModelError("mesaj", _localizer["InvalidInformationError"].Value);
            }
            else
            {
                var claims = new List<Claim>() { new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()) };

                var cIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext
                       .SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(cIdentity));

                if (!String.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    return Redirect(returnUrl);
                else
                    return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new Models.User.Register());
        }

        [HttpPost]
        [ModelStateValidationFilter]
        public IActionResult Register(Models.User.Register model, string returnUrl = "")
        {
            if (!MailIsValid(model.Email))
            {
                ModelState.AddModelError("", _localizer["InvalidMailFormat"].Value);
                return View(model);
            }

            var isValidMail = _dbContext.User.FirstOrDefault(x => x.Email == model.Email.ToLower() || x.Username == model.Username);

            if (isValidMail != null)
            {
                if (isValidMail.Email == model.Email.ToLower())
                    ModelState.AddModelError("", _localizer["ExistingMailAddressError"].Value);

                if (isValidMail.Username == model.Username)
                    ModelState.AddModelError("", _localizer["UsernameAlreadyExists"].Value);
            }
            else
            {
                // db modeli oluştur
                var user = new Db.Entity.User
                {
                    Email = model.Email.ToLower(),
                    Name = model.Name,
                    Password = MD5Hash(model.Password),
                    Username = model.Username
                };

                // context'e modeli ekle
                _dbContext.User.Add(user);

                // db'ye kaydet
                _dbContext.SaveChanges();

                // index'e yolla
                if (!String.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    return Redirect(returnUrl);
                else
                    return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("index", "user");
        }

        public string MD5Hash(string input)
        {
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.ASCII.GetBytes(input));
                return Encoding.ASCII.GetString(result);
            }
        }

        private static bool MailIsValid(string email)
        {
            string expression = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (Regex.IsMatch(email, expression))
            {
                if (Regex.Replace(email, expression, string.Empty).Length == 0)
                    return true;
            }
            return false;
        }
    }
}
