using Data.Repository;
using Data.UnitOfWork;
using Entity.Models.Roadmaps;
using Entity.Models.Tags;
using Service.Roadmaps.Roadmaps;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.RoadmapTags
{
    public class RoadmapTagService : IRoadmapTagService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<RoadmapTag> _repository;
        private readonly IRoadmapService _roadmapService;
        public RoadmapTagService(IUnitOfWork unitOfWork,IRepository<RoadmapTag> repository,IRoadmapService roadmapService)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _roadmapService = roadmapService;
        }

        public ReturnModel<Roadmap> Create(RoadmapTag roadmapTag)
        {
            var result = new ReturnModel<Roadmap>();
            try
            {
                var roadmapToUpdate = _roadmapService.Get(roadmapTag.Id);
                if (roadmapToUpdate!=null)
                {
                    roadmapToUpdate.Data.RoadmapTags.Add(roadmapTag);

                    _repository.Add(roadmapTag);
                    result.Data = roadmapTag.Roadmap;
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

        public void Save()
        {
            _unitOfWork.Commmit();
        }

        

    }
}
