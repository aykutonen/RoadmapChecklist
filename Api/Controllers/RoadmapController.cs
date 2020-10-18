using System;
using System.Linq;
using Api.Models.Request.Roadmap;
using Entity.Domain.Roadmap;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service.Roadmap;
using Service.Roadmap.CopiedRoadmap;
using Service.Roadmap.RoadmapCategory;
using Service.Roadmap.RoadmapTag;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoadmapController : ControllerBase
    {
        private IRoadmapService _roadmapService;
        private ICopiedRoadmapService _copiedRoadmapService;
        private IRoadmapTagService _roadmapTagService;
        private IRoadmapCategoryService _roadmapCategoryService;
        private IConfiguration _configuration;

        public RoadmapController(IRoadmapService roadmapService, IConfiguration configuration, ICopiedRoadmapService copiedRoadmapService, IRoadmapCategoryService roadmapCategoryService)
        {
            _roadmapService = roadmapService;
            _configuration = configuration;
            _copiedRoadmapService = copiedRoadmapService;
            _roadmapCategoryService = roadmapCategoryService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] RoadmapModel roadmap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userIdInSession = HttpContext.Session.GetString("userId");

            if (!string.IsNullOrEmpty(userIdInSession))
            {
                var roadmapToCreate = new Roadmap()
                {
                    Name = roadmap.Name,
                    Visibility = roadmap.Visibility,
                    Status = roadmap.Status,
                    StartDate = roadmap.StartDate,
                    EndDate = roadmap.EndDate,
                    UserId = Convert.ToInt32(userIdInSession)
                };
                var createdRoadmap = _roadmapService.Create(roadmapToCreate);

                return createdRoadmap.IsSuccess ? StatusCode(201) : BadRequest();
            }
            else
            {
                return NotFound("Session not found!");
            }
        }

        [HttpPost("copy")]
        public IActionResult Copy([FromBody] int roadmapId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var copiedRoadmap = _copiedRoadmapService.Create(roadmapId);

            return copiedRoadmap.IsSuccess ? StatusCode(201) : BadRequest();
        }

        [HttpGet("getAllRoadmaps")]
        public IActionResult GetAll([FromQuery] int userId)
        {
            if (!ModelState.IsValid || userId <= 0)
            {
                return BadRequest(ModelState);
            }

            var roadmapByUserList = _roadmapService.GetAllByUser(userId).Data.ToList();

            if (roadmapByUserList.Count() != 0)
            {
                return Ok(roadmapByUserList);
            }
            else
            {
                return NotFound();
            }
            
        }

        [HttpPut("updateRoadmap")]
        public IActionResult Update([FromBody] RoadmapModel roadmap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var roadmapToUpdate = new Roadmap()
            {
                Name = roadmap.Name,
                Visibility = roadmap.Visibility,
                Status = roadmap.Status,
                StartDate = roadmap.StartDate,
                EndDate = roadmap.EndDate
            };
            var updatedRoadmap = _roadmapService.Update(roadmapToUpdate);

            return updatedRoadmap.IsSuccess ? StatusCode(200) : BadRequest();
        }

        [HttpDelete("deleteRoadmap")]
        public IActionResult Delete([FromQuery] int roadmapId)
        {
            if (!ModelState.IsValid || roadmapId <= 0)
            {
                return BadRequest(ModelState);
            }

            var deletedRoadmap = _roadmapService.Delete(roadmapId);
            
            return deletedRoadmap.IsSuccess ? StatusCode(204) : NotFound();
        }
        
        [HttpPost("addTagToRoadmap")]
        public IActionResult Add([FromBody] RoadmapTagModel roadmapTag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var roadmapTagToCreate = new RoadmapTagRelation()
            {
                RoadmapId = roadmapTag.RoadmapId,
                TagId = roadmapTag.TagId
            };
            var createdRoadmap = _roadmapTagService.Create(roadmapTagToCreate);

            return createdRoadmap.IsSuccess ? StatusCode(201) : BadRequest();

        }
        
        [HttpPost("addCategoryToRoadmap")]
        public IActionResult Add([FromBody] RoadmapCategoryModel roadmapCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var roadmapCategoryToCreate = new RoadmapCategoryRelation()
            {
                RoadmapId = roadmapCategory.RoadmapId,
                CategoryId = roadmapCategory.CategoryId
            };
            var createdRoadmap = _roadmapCategoryService.Create(roadmapCategoryToCreate);

            return createdRoadmap.IsSuccess ? StatusCode(201) : BadRequest();

        }
    }
}