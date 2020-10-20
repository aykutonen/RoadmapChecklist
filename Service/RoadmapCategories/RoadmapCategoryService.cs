using Data.Repository;
using Data.UnitOfWork;
using Entity.Models.Categories;
using Entity.Models.Roadmaps;
using Service.RoadmapCategories;
using Service.Roadmaps;
using Service.Roadmaps.Roadmaps;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.RoadmapCategories
{
    public class RoadmapCategoryService : IRoadmapCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<RoadmapCategory> _repository;
        private readonly IRoadmapService _roadmapService;

        public RoadmapCategoryService(IUnitOfWork unitOfWork,IRepository<RoadmapCategory> repository,IRoadmapCategoryService roadmapCategoryService,IRoadmapService roadmapService)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _roadmapService = roadmapService;
        }

        public void Save()
        {
            _unitOfWork.Commmit();
        }

        public ReturnModel<Roadmap> Create(RoadmapCategory roadmapCategory)
        {
            var result = new ReturnModel<Roadmap>();
            try
            {
                var roadmapToUpdate = _roadmapService.Get(roadmapCategory.RoadmapId);
                if (roadmapToUpdate != null)
                {
                    roadmapToUpdate.Data.RoadmapCategories.Add(roadmapCategory);
                    _repository.Add(roadmapCategory);
                    result.Data = roadmapCategory.Roadmap;
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Exception = ex;
                result.Message = ex.Message;
            }

            return result;

        }
    }
}
