using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models.Roadmap;
using Entity.Domain.Roadmap;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service.Roadmap.RoadmapItem;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoadmapItemController : Controller
    {
        private IRoadmapItemService _roadmapItemService;
        private IConfiguration _configuration;

        public RoadmapItemController(IRoadmapItemService roadmapItemService, IConfiguration configuration)
        {
            _roadmapItemService = roadmapItemService;
            _configuration = configuration;
        }

        [HttpPost("addToRoadmap")]
        public IActionResult Add([FromBody] RoadmapItemModel roadmapItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var roadmapItemToAdd = new RoadmapItem()
            {
                Title = roadmapItem.Title,
                Description = roadmapItem.Description,
                Status = roadmapItem.Status,
                TargetDate = roadmapItem.TargetDate,
                EndDate = roadmapItem.EndDate,
                RoadmapId = roadmapItem.RoadmapId,
                ParentId = roadmapItem.ParentId,
            };
            var createdRoadmapItem = _roadmapItemService.Create(roadmapItemToAdd);

            return createdRoadmapItem.IsSuccess ? StatusCode(201) : BadRequest();
        }

        [HttpGet("getAllRoadmapItemsInRoadmap")]
        public IActionResult GetAll([FromQuery] int roadmapId)
        {
            if (!ModelState.IsValid || roadmapId <= 0)
            {
                return BadRequest(ModelState);
            }

            var roadmapItemsInRoadmap = _roadmapItemService.GetAll(roadmapId).Data.ToList();

            if (roadmapItemsInRoadmap.Count() != 0)
            {
                return Ok(roadmapItemsInRoadmap);
            }
            else
            {
                return NotFound();
            }

        }
    }
}
