using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Db;
using Web.Db.Entity;

namespace Web.Controllers
{
    [Authorize]
    public class RoadmapController : Controller
    {
        protected AppDbContext _dbContext;

        public RoadmapController(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        // GET: RoadmapController
        public ActionResult Index()
        {
            if (int.TryParse(HttpContext.User.Claims.FirstOrDefault()?.Value, out int currentUserId))
            {
                List<Roadmap> roadmaps = _dbContext.Roadmap.Where(x => x.UserId == currentUserId).ToList();
                return View(roadmaps);
            }
            return View(new List<Roadmap>());
        }

        // GET: RoadmapController/Details/5
        public ActionResult Details(int id)
        {
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
        public ActionResult Create(Models.Roadmap.Create model)
        {
            if (ModelState.IsValid)
            {
                if (int.TryParse(HttpContext.User.Claims.FirstOrDefault()?.Value, out int currentUserId))
                {
                    var roadmap = new Roadmap()
                    {
                        EndDate = model.EndDate,
                        Name = model.name,
                        StartDate = model.StartDate,
                        Visibility = model.Visibility,
                        UserId = currentUserId
                    };

                    _dbContext.Roadmap.Add(roadmap);

                    _dbContext.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("mesaj", "Birader sen kimsin?");
                }
            }

            return View(model);
        }

        // GET: RoadmapController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RoadmapController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RoadmapController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (id == null || id == default)
            {
                return NotFound();
            }

            var roadmap = _dbContext.Roadmap
                .SingleOrDefault(m => m.Id == id.ToString());
            
            if (roadmap == null)
            {
                return NotFound();
            }

            return View(roadmap);
        }

        // POST: RoadmapController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var roadmap = _dbContext.Roadmap.SingleOrDefault(m => m.Id == id.ToString());

            _dbContext.Remove(roadmap);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
