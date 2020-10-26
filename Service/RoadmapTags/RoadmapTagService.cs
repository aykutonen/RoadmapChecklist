using Data.Repository;
using Data.UnitOfWork;
using Entity.Models.Roadmaps;
using Entity.Models.Tags;
using Service.Roadmaps.Roadmaps;
using Service.RoadmapTags.Models;
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
        public void Save()
        {
            _unitOfWork.Commmit();
        }

        public ReturnModel<Roadmap> Create(RoadmapTagViewModel roadmapTagViewModel)
        {
            var result = new ReturnModel<Roadmap>();
            try
            {
                var roadmapToUpdate = _roadmapService.Get(roadmapTagViewModel.RoadmapId);
                if (roadmapToUpdate!=null)
                {
                    var tag = new RoadmapTag()
                    {
                        RoadmapId =roadmapTagViewModel.RoadmapId,
                        TagId=roadmapTagViewModel.TagId
                    };
                    _repository.Add(tag);
                    roadmapToUpdate.Data.RoadmapTags.Add(tag);
                    result.Data = roadmapToUpdate.Data;
                    Save();
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
