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
using System.Threading.Tasks;
using Web.Db;

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
        public async Task<IActionResult> Index(Models.User.Login model, string returnUrl = "")
        {
            if (ModelState.IsValid)
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
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new Models.User.Register());
        }

        [HttpPost]
        public IActionResult Register(Models.User.Register model, string returnUrl = "")
        {
            // model doğrulaması
            if (ModelState.IsValid)
            {
                var isValidMail = _dbContext.User.FirstOrDefault(x => x.Email == model.Email) == null ? true : false;

                if (isValidMail)
                {
                    // db modeli oluştur
                    var user = new Db.Entity.User
                    {
                        Email = model.Email,
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
                else
                {
                    ModelState.AddModelError("", _localizer["ExistingMailAddressError"].Value);
                }
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
    }
}
