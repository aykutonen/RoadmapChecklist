﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Data.Repository;
using Entity.Models.Categories;
using Entity.Models.Roadmaps;
using Entity.Models.Tags;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Service.RoadmapCategories;
using Service.RoadmapCategories.Models;
using Service.Roadmaps.CopiedRoadmaps;
using Service.Roadmaps.CopiedRoadmaps.Models;
using Service.Roadmaps.Roadmaps;
using Service.Roadmaps.Roadmaps.Models;
using Service.RoadmapTags;
using Service.RoadmapTags.Models;

namespace RoadmapChecklistWeb.Controllers
{
    public class RoadmapController : Controller
    {
        private readonly IRoadmapService _roadmapService;
        private readonly ICopiedRoadmapService _copiedRoadmapService;
        private readonly IRepository<RoadmapService> _repository;
        private readonly IRoadmapCategoryService _roadmapCategoryService;
        private readonly IRoadmapTagService _roadmapTagService;
        public RoadmapController(IRoadmapService roadmapService, ICopiedRoadmapService copiedRoadmapService, IRepository<RoadmapService> repository, IRoadmapCategoryService roadmapCategoryService, IRoadmapTagService roadmapTagService)
        {
            _roadmapService = roadmapService;
            _repository = repository;
            _copiedRoadmapService = copiedRoadmapService;
            _roadmapTagService = roadmapTagService;
            _roadmapCategoryService = roadmapCategoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateRoadmap()
        {
            return View();
        }

        //Roadmap

        [HttpPost("AddRoadmap")]
        public IActionResult CreateRoadmap(RoadmapViewModel roadmapViewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Roadmap oluşturulurken hata oluştu.");
                return View("Roadmap", roadmapViewModel);
            }
            _roadmapService.AddRoadmap(roadmapViewModel);
            TempData["notice"] = "Roadmap oluşturuldu.";
            return RedirectToAction("Roadmap", "Roadmap");
        }

        [HttpGet("RoadmapList")]
        public IEnumerable<Roadmap> GetAll()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return _roadmapService.GetAllByUser(userId).Data.ToList();
        }

        [HttpPut("UpdateRoadmap")]
        public IActionResult Update(RoadmapViewModel roadmapViewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Roadmap güncelleme yapılırken hata oluştu.");
                return View("Roadmap", roadmapViewModel);
            }
            _roadmapService.UpdateRoadmap(roadmapViewModel);
            TempData["notice"] = "Roadmap güncellendi.";
            return RedirectToAction("Roadmap", "Roadmap");
        }

        [HttpDelete("DeleteRoadmap")]
        public IActionResult Delete(int roadmapId)
        {
            _roadmapService.Delete(roadmapId);
            return Ok();
        }

        //CopiedRoadmap

        [HttpPost("CopyRoadmap")]
        public IActionResult Copy(int userId, int roadmapId)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Roadmap kopyalanamadı.");
                return View("Roadmap"," userId, roadmapId");
            }
            _copiedRoadmapService.Create(userId, roadmapId);
            TempData["notice"] = "Roadmap kopyalandı.";
            return RedirectToAction("Roadmap", "Roadmap");
        }

        [HttpPost("AddTagToRoadmap")]
        public IActionResult Add(RoadmapTagViewModel roadmapTagViewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Hata oluştu.");
                return View("Roadmap", roadmapTagViewModel);
            }

            var createdRoadmap = _roadmapTagService.Create(roadmapTagViewModel);
            return RedirectToAction("Roadmap", "createdRoadmap");
        }

        [HttpPost("AddCategoryToRoadmap")]
        public IActionResult Add(RoadmapCategoryViewModel roadmapCategoryViewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Hata oluştu.");
                return View("Roadmap", roadmapCategoryViewModel);
            }

            var createdRoadmap = _roadmapCategoryService.Create(roadmapCategoryViewModel);
            return RedirectToAction("Roadmap", "createdRoadmap");
        }
    }
}