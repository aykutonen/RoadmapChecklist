using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Web.Db;
using Web.Db.Entity;
using Web.Infrastructure;

namespace Web.Controllers
{
    [Authorize]
    public class RoadmapController : BaseController
    {
        protected AppDbContext _dbContext;
        private readonly IStringLocalizer<RoadmapController> _localizer;

        public RoadmapController(AppDbContext dbContext, IStringLocalizer<RoadmapController> localizer, ILogger<HomeController> logger) : base(logger)
        {
            this._dbContext = dbContext;
            this._localizer = localizer;
        }

        // GET: RoadmapController
        public ActionResult Index()
        {
            List<Roadmap> roadmaps = _dbContext.Roadmap.Where(x => x.UserId == currentUserId && x.Status == (int)StatusEnum.ActiveRoadmap).ToList();
            return View(roadmaps);

        }

        // GET: RoadmapController/Details/5
        public ActionResult Details(Guid id)
        {

            if (Guid.Empty == id)
            {
                ModelState.AddModelError("", _localizer["InvalidId"].Value);
            }
            else
            {
                var roadmapDetail = _dbContext.Roadmap.FirstOrDefault(x => x.Id == id && x.UserId == currentUserId && x.Status == (int)StatusEnum.ActiveRoadmap);
                if (roadmapDetail != null)
                {
                    var model = new Models.Roadmap.Detail()
                    {
                        Id = roadmapDetail.Id,
                        Name = roadmapDetail.Name,
                        Visibility = roadmapDetail.Visibility,
                        StartDate = roadmapDetail.StartDate,
                        EndDate = roadmapDetail.EndDate
                    };
                    return View(model);
                }
                else { ModelState.AddModelError("", _localizer["RoadmapNotFoundError"].Value); }
            }

            return View();
        }

        // GET: RoadmapController/Create
        public ActionResult Create()
        {
            return View(new Models.Roadmap.Create());
        }

        // POST: RoadmapController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ModelStateValidationFilter]
        public ActionResult Create(Models.Roadmap.Create model)
        {
            var roadmap = new Roadmap()
            {
                EndDate = model.EndDate,
                Name = model.Name,
                StartDate = model.StartDate,
                Visibility = model.Visibility,
                UserId = currentUserId
            };

            _dbContext.Roadmap.Add(roadmap);

            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: RoadmapController/Edit/5
        public ActionResult Edit(Guid id)
        {

            if (Guid.Empty == id)
            {
                ModelState.AddModelError("", _localizer["InvalidId"].Value);
            }
            else
            {
                var fromdb = _dbContext.Roadmap.FirstOrDefault(x => x.Id == id && x.UserId == currentUserId && x.Status == (int)StatusEnum.ActiveRoadmap);
                if (fromdb != null)
                {
                    var model = new Models.Roadmap.Edit()
                    {
                        Id = fromdb.Id,
                        EndDate = fromdb.EndDate,
                        Name = fromdb.Name,
                        StartDate = fromdb.StartDate,
                        Visibility = fromdb.Visibility
                    };
                    return View(model);
                }
                else { ModelState.AddModelError("", _localizer["RoadmapNotFoundError"].Value); }
            }

            return View();
        }

        // POST: RoadmapController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ModelStateValidationFilter]
        public ActionResult Edit(Models.Roadmap.Edit model)
        {
            var fromdb = _dbContext.Roadmap.FirstOrDefault(x => x.Id == model.Id && x.UserId == currentUserId && x.Status == (int)StatusEnum.ActiveRoadmap);
            if (fromdb != null)
            {

                fromdb.Name = model.Name;
                fromdb.StartDate = model.StartDate;
                fromdb.EndDate = model.EndDate;
                fromdb.Visibility = model.Visibility;

                _dbContext.Roadmap.Update(fromdb);
                _dbContext.SaveChanges();

                return RedirectToAction("Index", "Roadmap");
            }
            else { ModelState.AddModelError("", _localizer["RoadmapNotFoundError"].Value); }

            return View(model);
        }

        // GET: RoadmapController/Delete/5
        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            if (id == Guid.Empty) return NotFound();

            var roadmapToBeDeleted = _dbContext.Roadmap.FirstOrDefault(x => x.Id == id && x.UserId == currentUserId && x.Status == (int)StatusEnum.ActiveRoadmap);
            if (roadmapToBeDeleted != null) return View(roadmapToBeDeleted);

            ModelState.AddModelError("", _localizer["RoadmapNotFoundError"].Value);

            return RedirectToAction(nameof(Index));
        }

        // POST: RoadmapController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var roadmapToBeDeleted = _dbContext.Roadmap.FirstOrDefault(x => x.Id == id && x.UserId == currentUserId && x.Status == (int)StatusEnum.ActiveRoadmap);

            if (roadmapToBeDeleted != null)
            {
                roadmapToBeDeleted.Status = (int)StatusEnum.DeletedRoadmap;
                _dbContext.Roadmap.Update(roadmapToBeDeleted);
                _dbContext.SaveChanges();
            }
            else { ModelState.AddModelError("", _localizer["RoadmapNotFoundError"].Value); }

            return RedirectToAction(nameof(Index));
        }
    }
}
