using Microsoft.AspNetCore.Mvc;
using Service.RoadmapItem;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoadmapItemController : ControllerBase
    {
        private readonly IRoadmapItemService service;

        public RoadmapItemController(IRoadmapItemService roadmapItemService)
        {
            this.service = roadmapItemService;
        }

        public IActionResult Get(int roadmapid)
        {
            return Ok(service.GetByRoadmap(roadmapid));
        }

        [HttpPost]
        public IActionResult Create(Entity.RoadmapItem item)
        {
            return Ok(service.Create(item));
        }

        #region Update
        [HttpPut, Route("title")]
        public IActionResult UpdateTitle(Models.StringValueById req)
        {
            var itemResult = service.Get(req.id);
            if (itemResult.IsSuccess)
            {
                itemResult.Data.Title = req.value;
                return Ok(service.Update(itemResult.Data));
            }
            return Ok(itemResult);
        }

        [HttpPut, Route("description")]
        public IActionResult UpdateDescription(Models.StringValueById req)
        {
            var itemResult = service.Get(req.id);
            if (itemResult.IsSuccess)
            {
                itemResult.Data.Description = req.value;
                return Ok(service.Update(itemResult.Data));
            }
            return Ok(itemResult);
        }

        [HttpPut, Route("status")]
        public IActionResult UpdateStatus(Models.IntValueById req)
        {
            var result = service.Get(req.id);
            if (result.IsSuccess)
            {
                result.Data.Status = req.value;
                return Ok(service.Update(result.Data));
            }
            return Ok(result);
        }

        [HttpPut, Route("target")]
        public IActionResult UpdateTargetDate(Models.DateTimeValueById req)
        {
            var result = service.Get(req.id);
            if (result.IsSuccess)
            {
                result.Data.TargetDate = req.value;
                return Ok(service.Update(result.Data));
            }
            return Ok(result);
        }

        [HttpPut, Route("end")]
        public IActionResult UpdateEndDate(Models.DateTimeValueById req)
        {
            var result = service.Get(req.id);
            if (result.IsSuccess)
            {
                result.Data.EndDate = req.value;
                return Ok(service.Update(result.Data));
            }
            return Ok(result);
        }

        [HttpPut, Route("parent")]
        public IActionResult UpdateParent(Models.IntValueById req)
        {
            var result = service.Get(req.id);
            if (result.IsSuccess)
            {
                result.Data.ParentId = req.value;
                return Ok(service.Update(result.Data));
            }
            return Ok(result);
        }
        #endregion
    }
}
