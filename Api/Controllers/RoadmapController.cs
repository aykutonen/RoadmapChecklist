using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models.Roadmap;
using Entity.Domain.Roadmap;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service;
using Service.Roadmap;
using Service.Roadmap.CopiedRoadmap;
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
        private IConfiguration _configuration;

        public RoadmapController(IRoadmapService roadmapService, IConfiguration configuration, ICopiedRoadmapService copiedRoadmapService)
        {
            _roadmapService = roadmapService;
            _configuration = configuration;
            _copiedRoadmapService = copiedRoadmapService;
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

            var roadmapResult = _roadmapService.Get(roadmapId);
            var roadmapEntity = roadmapResult.IsSuccess ? roadmapResult.Data : null;

            if (roadmapEntity != null)
            {
                var deletedRoadmap = _roadmapService.Delete(roadmapEntity);
                return deletedRoadmap.IsSuccess ? StatusCode(204) : NotFound();
            }
            
            return BadRequest();
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
    }
}