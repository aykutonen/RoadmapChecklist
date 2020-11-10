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

        [HttpGet]
        public IActionResult Get(int id)
        {
            return Ok(service.Get(id));
        }

        [HttpGet, Route("list")]
        public IActionResult List()
        {
            return Ok(service.Get());
        }


    }
}
