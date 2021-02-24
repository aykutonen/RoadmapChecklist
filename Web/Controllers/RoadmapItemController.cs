using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using Web.Db;
using Web.Db.Entity;
using Web.Infrastructure;
using Web.Models.RoadmapItem;

namespace Web.Controllers
{
    public class RoadmapItemController : BaseController
    {
        protected AppDbContext _dbContext;
        private readonly IStringLocalizer<RoadmapItemController> _localizer;

        public RoadmapItemController(AppDbContext dbContext, ILogger<HomeController> logger, IStringLocalizer<RoadmapItemController> localizer) : base(logger)
        {
            _dbContext = dbContext;
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(Guid RoadmapId, int? Order)
        {
            var model = new Create { Order = Order, RoadmapId = RoadmapId };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ModelStateValidationFilter]
        public IActionResult Create(Create model)
        {
            var item = new RoadmapItem()
            {
                Title = model.Title,
                RoadmapId = model.RoadmapId
            };

            // Belli sıraya ekler, eklenen sıradali ve sonraki kayıtları bir alt sıraya taşır.
            if (model.Order.HasValue && model.Order.Value > 0)
            {
                item.Order = model.Order.Value;

                var afterItems = _dbContext.RoadmapItem
                    .Where(x => x.RoadmapId == model.RoadmapId
                    && !x.ParentId.HasValue
                    && x.Status != (int)StatusEnum.DeletedRoadmapItem
                    && (x.Order == item.Order || x.Order > item.Order))
                    .OrderBy(x => x.Order)
                    .ToList();

                if (afterItems != null && afterItems.Count > 0)
                {
                    foreach (var after in afterItems)
                    {
                        after.Order += 1;
                        _dbContext.RoadmapItem.Update(after);
                    }
                }
            }

            // En son sıraya ekler
            else
            {
                var parent = _dbContext.RoadmapItem
                .Where(x => x.RoadmapId == model.RoadmapId
                && x.Status != (int)StatusEnum.DeletedRoadmapItem
                && !x.ParentId.HasValue)
                .OrderByDescending(x => x.Order)
                .FirstOrDefault();

                if (parent != null) item.Order = parent.Order + 1;
            }

            _dbContext.RoadmapItem.Add(item);
            _dbContext.SaveChanges();
            return RedirectToAction("Details", "Roadmap", new { id = model.RoadmapId });
        }

        public IActionResult Delete(Guid RoadmapId, Guid ItemId)
        {
            var toDelete = _dbContext.RoadmapItem
                .FirstOrDefault(x => x.RoadmapId == RoadmapId
                && x.Id == ItemId
                && x.Status != (int)StatusEnum.DeletedRoadmapItem);

            if (toDelete != null)
            {
                // kaydı silinecek olarak işaretle.
                toDelete.Status = (int)StatusEnum.DeletedRoadmapItem;
                _dbContext.RoadmapItem.Update(toDelete);

                // Kendinden sonraki kayıtların sırasını azalt.
                var afterItems = _dbContext.RoadmapItem
                   .Where(x => x.RoadmapId == RoadmapId
                   && x.ParentId == toDelete.ParentId
                   && x.Status != (int)StatusEnum.DeletedRoadmapItem
                   && x.Order >= toDelete.Order)
                   .OrderBy(x => x.Order)
                   .ToList();

                if (afterItems != null && afterItems.Count > 0)
                {
                    foreach (var after in afterItems) { after.Order--; }
                    _dbContext.RoadmapItem.UpdateRange(afterItems);
                }

                // db'yi güncelle
                _dbContext.SaveChanges();
            }
            else { ModelState.AddModelError("", _localizer["RoadmapItemNotFoundError"]); }

            return RedirectToAction(nameof(RoadmapController.Details), "Roadmap", new { id = RoadmapId });
        }
    }
}
