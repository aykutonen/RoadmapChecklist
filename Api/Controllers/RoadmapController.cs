﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models.Roadmap;
using Entity.Domain.Roadmap;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service.Roadmap;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoadmapController : ControllerBase
    {
        private IRoadmapService _roadmapService;
        private IConfiguration _configuration;

        public RoadmapController(IRoadmapService roadmapService, IConfiguration configuration)
        {
            _roadmapService = roadmapService;
            _configuration = configuration;
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] RoadmapModel roadmap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var roadmapToCreate = new Roadmap()
            {
                Name = roadmap.Name,
                Visibility = roadmap.Visibility,
                Status = roadmap.Status,
                StartDate = roadmap.StartDate,
                EndDate = roadmap.EndDate,
                //UserId = null login'den sonra elde ettiğimiz token'ı bir yere yazıp oradan okumamız gerekiyor
            };

            var createdRoadmap = _roadmapService.Create(roadmapToCreate);

            return createdRoadmap.IsSuccess ? StatusCode(201) : BadRequest();
        }
    }
}