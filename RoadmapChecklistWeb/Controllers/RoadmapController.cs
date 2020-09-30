using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Data.Repository;
using Entity.Models.Roadmaps;
using Microsoft.AspNetCore.Mvc;
using Service.Roadmaps.Roadmaps;
using Service.Roadmaps.Roadmaps.Models;

namespace RoadmapChecklistWeb.Controllers
{
    public class RoadmapController : Controller
    {
        private readonly IRoadmapService _roadmapService;
        private readonly IRepository<RoadmapService> _repository;

        public RoadmapController(IRoadmapService roadmapService, IRepository<RoadmapService> repository)
        {
            _roadmapService = roadmapService;
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Roadmap()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Roadmap(RoadmapViewModel roadmapViewModel)
        {
            if (! ModelState.IsValid)
            {
                TempData["notice"] = "Roadmap oluşturulurken hata oluştu.";
                return View("Roadmap",roadmapViewModel);
                
            }

            _roadmapService.AddRoadmap(roadmapViewModel);

            TempData["notice"] = "Roadmap oluşturuldu.";
            return RedirectToAction("Roadmap", "Roadmap");


            //var response = _roadmapService.AddRoadmap(roadmapViewModel);
            //if (response.IsSuccess)
            //{
            //    return RedirectToAction("Roadmap", "Roadmap");
            //}

            //return View(roadmapViewModel);
        }

        //Get Kontrolü! 
        [HttpGet]
        public IEnumerable<Roadmap> GetAll()
        {
            // Todo : Move basecontroller ctor -> _currentUser
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return _roadmapService.GetAllByUser(userId).Data.ToList();
        }

        [HttpDelete]
        public IActionResult Delete(int roadmapId)
        {
            _roadmapService.Delete(roadmapId);
            return Ok();
        }



    }

}