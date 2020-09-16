using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RoadmapChecklistWeb.Models.User;
using Service.Users;

namespace RoadmapChecklistWeb.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string userName, string password)
        {
            var user = _userService.CheckUser(userName, password);
            if (user != null)
            {
                var userClaims = new List<Claim>()
               {
                   new Claim(ClaimTypes.Name,user.Name),
                   new Claim(ClaimTypes.Email,user.Email),
               };

                var identify = new ClaimsIdentity(userClaims, "User Identify");

                var userPrincipal=new ClaimsPrincipal(new[] { identify });
                HttpContext.SignInAsync(userPrincipal);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                
                
                // Kullanıcı bulunamadı uyarısı
            }

            return View(user);
        }

    }
}