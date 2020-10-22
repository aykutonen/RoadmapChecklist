using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models.Request.Roadmap;
using Api.Models.Response;
using Entity.Domain.Roadmap;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service.Roadmap;
using Service.Roadmap.RoadmapItem;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoadmapItemController : Controller
    {
        private IRoadmapItemService _roadmapItemService;
        private IRoadmapService _roadmapService;
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

        [HttpGet("getRoadmapWithItems")]
        public IActionResult GetAll([FromQuery] int roadmapId)
        {
            if (!ModelState.IsValid || roadmapId <= 0)
            {
                return BadRequest(ModelState);
            }
            
            var roadmapResponseModel = new RoadmapResponseModel();
            
            var roadmapResult = _roadmapService.Get(roadmapId);
            roadmapResponseModel.Roadmap = roadmapResult.IsSuccess ? roadmapResult.Data : null;

            var roadmapItemsResult = _roadmapItemService.GetAll(roadmapId);
            if (roadmapResponseModel.Roadmap != null)
                roadmapResponseModel.Roadmap.RoadmapItems =
                    (ICollection<RoadmapItem>) (roadmapItemsResult.IsSuccess ? roadmapItemsResult.Data : null);


            return Ok(roadmapResponseModel);
        }

        [HttpPut("updateRoadmapItem")]
        public IActionResult Update([FromBody] RoadmapItemModel roadmapItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var roadmapItemToUpdate = new RoadmapItem()
            {
                Title = roadmapItem.Title,
                Description = roadmapItem.Description,
                Status = roadmapItem.Status,
                TargetDate = roadmapItem.TargetDate,
                EndDate = roadmapItem.EndDate,
                RoadmapId = roadmapItem.RoadmapId,
                ParentId = roadmapItem.ParentId,
            };
            var updatedRoadmapItem = _roadmapItemService.Update(roadmapItemToUpdate);

            return updatedRoadmapItem.IsSuccess ? StatusCode(200) : BadRequest();
        }

        [HttpDelete("deleteRoadmapItem")]
        public IActionResult Delete([FromQuery] int roadmapItemId)
        {
            if (!ModelState.IsValid || roadmapItemId <= 0)
            {
                return BadRequest(ModelState);
            }

            var deletedRoadmapItem = _roadmapItemService.Delete(roadmapItemId);
            
            return deletedRoadmapItem.IsSuccess ? StatusCode(204) : NotFound();
        }
    }
}
