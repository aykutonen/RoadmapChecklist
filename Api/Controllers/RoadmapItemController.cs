using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.RoadmapItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoadmapItemController : ControllerBase
    {
        private readonly IRoadmapItemService service;

        public RoadmapItemController(IRoadmapItemService roadmapItemService)
        {
            this.service = roadmapItemService;
        }

        [HttpPost]
        public IActionResult Create(Entity.RoadmapItem item)
        {
            return Ok(service.Create(item));
        }

        [HttpPut]
        public IActionResult Update(Entity.RoadmapItem item)
        {
            // TODO: update işleminde boş gelen alanların güncellenmemesini sağla...
            return Ok(service.Update(item));
        }

        public IActionResult Get(int roadmapid)
        {
            return Ok(service.GetByRoadmap(roadmapid));
        }
    }
}
