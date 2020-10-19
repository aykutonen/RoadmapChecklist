using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Data.Repository;
using Entity.Models.Roadmaps;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Service.Roadmaps.CopiedRoadmaps;
using Service.Roadmaps.CopiedRoadmaps.Models;
using Service.Roadmaps.Roadmaps;
using Service.Roadmaps.Roadmaps.Models;

namespace RoadmapChecklistWeb.Controllers
{
    public class RoadmapController : Controller
    {
        private readonly IRoadmapService _roadmapService;
        private readonly ICopiedRoadmapService _copiedRoadmapService;
        private readonly IRepository<RoadmapService> _repository;

        public RoadmapController(IRoadmapService roadmapService, ICopiedRoadmapService copiedRoadmapService, IRepository<RoadmapService> repository)
        {
            _roadmapService = roadmapService;
            _repository = repository;
            _copiedRoadmapService = copiedRoadmapService;
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
        public IActionResult Copy(CopiedRoadmapViewModel copiedRoadmapViewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Roadmap kopyalanamadı.");
                return View("Roadmap", copiedRoadmapViewModel);
            }
            _copiedRoadmapService.AddCopy(copiedRoadmapViewModel);
            TempData["notice"] = "Roadmap kopyalandı.";
            return RedirectToAction("Roadmap", "Roadmap");
        }

        //[HttpGet("CopyList")]
        //public IEnumerable<CopiedRoadmap> GetCopy()
        //{
        //    var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        //    return _copiedRoadmapService.GetAllByUser(userId).Data.ToList();
        //}

        //[HttpPut("UpdateRoadmap")]
        //public IActionResult UpdateCopy(CopiedRoadmapViewModel copiedRoadmapViewModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        ModelState.AddModelError("", "Roadmap kopyalanamadı.");
        //        return View("Roadmap", copiedRoadmapViewModel);
        //    }
        //    _copiedRoadmapService.UpdateCopy(copiedRoadmapViewModel);
        //    TempData["notice"] = "Roadmap kopyalandı.";
        //    return RedirectToAction("Roadmap", "Roadmap");
        //}

        //[HttpDelete("DeleteRoadmap")]
        //public IActionResult CopyDelete(int roadmapId)
        //{
        //    _roadmapService.Delete(roadmapId);
        //    return Ok();
        //}


    }

}