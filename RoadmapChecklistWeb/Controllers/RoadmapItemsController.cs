using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Data.Repository;
using Entity.Models.Roadmaps;
using Microsoft.AspNetCore.Mvc;
using Service.Roadmaps.IRoadmapItems;
using Service.Roadmaps.RoadmapItems.Models;

namespace RoadmapChecklistWeb.Controllers
{
    public class RoadmapItemsController : Controller
    {
        private readonly IRoadmapItemService _roadmapItemService;
        private readonly IRepository<RoadmapItem> _repository;
        public RoadmapItemsController(IRoadmapItemService roadmapItemService,IRepository<RoadmapItem> repository)
        {
            _roadmapItemService = roadmapItemService;
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RoadmapItem()
        {
            return View();
        }

        [HttpPost("AddRoadmap")]
        public IActionResult Create(RoadmapItemViewModel roadmapItemViewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Roadmapıtem oluşturulurken hata oluştu.");
                return View("RoadmapItem", roadmapItemViewModel);
            }
            _roadmapItemService.Create(roadmapItemViewModel);
            TempData["notice"] = "Roadmap oluşturuldu.";
            return RedirectToAction("RoadmapItem", "RoadmapItem");
        }

        [HttpGet("ListRoadmapItem")]
        public IEnumerable<RoadmapItem> GetAll()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return _roadmapItemService.GetAllByUser(userId).Data.ToList();
        }

        [HttpPut("UpdateRoadmapItem")]
        public IActionResult Update(RoadmapItemViewModel roadmapItemViewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Roadmapıtem güncelleme yapılırken hata oluştu.");
                return View("Roadmap", roadmapItemViewModel);
            }
            _roadmapItemService.UpdateItem(roadmapItemViewModel);
            TempData["notice"] = "Roadmapıtem güncellendi.";
            return RedirectToAction("RoadmapItem", "RoadmapItem");
        }

        [HttpDelete("DeleteRoadmapItem")]
        public IActionResult Delete(int roadmapId)
        {
            _roadmapItemService.Delete(roadmapId);
            return Ok();
        }
    }
}