using Microsoft.AspNetCore.Mvc;
using Service.User;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService service;

        public UserController(IUserService userService)
        {
            this.service = userService;
        }

        [HttpPost]
        public IActionResult Create(Entity.User user)
        {
            var result = service.Create(user);
            return Ok(result);
        }

        public IActionResult Get()
        {
            var result = service.Get();
            return Ok(result);
        }
    }
}
