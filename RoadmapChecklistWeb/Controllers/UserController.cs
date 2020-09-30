using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Data.Repository;
using Entity;
using Entity.Models.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;
using Service;
using Service.Users;
using Service.Users.Models;


namespace RoadmapChecklistWeb.Controllers
{

    public class UserController : Controller
    {

        private readonly IUserService _userService;
        private readonly IRepository<UserService> _repository;

        public UserController(IUserService userService, IRepository<UserService> repository)
        {
            _userService = userService;
            _repository = repository;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserRegisterModel userRegisterModel)
        {
            var response = _userService.Register(userRegisterModel);
            if (response.IsSuccess)
                return RedirectToAction("Login", "User");
            else
                return View(userRegisterModel);
        }

        public IActionResult Login()
        {
            return View();
        }

        //Kullanıcı Giriş
        [HttpPost]
        public IActionResult Login(UserLoginModel userLoginModel)
        {
            var user = _userService.CheckUser(userLoginModel.Email, userLoginModel.Password);
            if (user != null)
            {
                var userClaims = new List<Claim>()
               {
                   // Maybe user info view model serialize json set nameidentifier after deserialize json call
                   new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                   new Claim(ClaimTypes.Name,user.Name),
                   new Claim(ClaimTypes.Email,user.Email),
               };

                var identify = new ClaimsIdentity(userClaims, "User Identify");

                var userPrincipal = new ClaimsPrincipal(new[] { identify });
                HttpContext.SignInAsync(userPrincipal);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı Bulunamadı!");

                // Kullanıcı bulunamadı uyarısı
            }

            return View(user);
        }

        //Kullanıcı Çıkış
        public async Task<IActionResult> LogOff()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }

    }
}