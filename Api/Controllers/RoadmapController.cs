using Microsoft.AspNetCore.Mvc;
using Service.Roadmap;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoadmapController : ControllerBase
    {
        private readonly IRoadmapService service;

        public RoadmapController(IRoadmapService roadmapService)
        {
            service = roadmapService;
        }

        [HttpPost]
        public IActionResult Create(Entity.Roadmap roadmap)
        {
            var result = service.Create(roadmap);
            return Ok(result);
        }

        public IActionResult Get(int id)
        {
            return Ok(service.Get(id));
        }

        [Route("list")]
        public IActionResult List(int userid)
        {
            return Ok(service.GetByUser(userid));
        }

        [HttpPost, Route("copy")]
        public IActionResult Copy(int roadmapid, int userid)
        {
            var result = service.Copy(roadmapid, userid);
            return Ok(result);
        }
    }
}
