﻿using Data.Infrastructure.Repository;
using Data.Infrastructure.UnitOfWork;
using Entity.Domain.Roadmap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Roadmap.CopiedRoadmap
{
    public class CopiedRoadmapService : ICopiedRoadmapService
    {
        private readonly IRepository<Entity.Domain.Roadmap.Roadmap> _roadmapRepository;
        private readonly IRepository<Entity.Domain.Roadmap.RoadmapItem> _roadmapItemRepository;
        private readonly IRepository<CopiedRoadmaps> _copiedRoadmapRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CopiedRoadmapService(IRepository<Entity.Domain.Roadmap.Roadmap> roadmapRepository, IRepository<CopiedRoadmaps> copiedRoadmapRepository, IUnitOfWork unitOfWork)
        {
            _roadmapRepository = roadmapRepository;
            _copiedRoadmapRepository = copiedRoadmapRepository;
            _unitOfWork = unitOfWork;
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public ReturnModel<CopiedRoadmaps> Create(int roadmapId, int userId)
        {
            var result = new ReturnModel<CopiedRoadmaps>();

            try
            {
                if (roadmapId > 0 && userId > 0)
                {
                    var sourceRoadmap = _roadmapRepository.Get(roadmap => roadmap.Id == roadmapId);
                    var targetRoadmap = new Entity.Domain.Roadmap.Roadmap
                    {
                        Name = sourceRoadmap.Name,
                        Visibility = sourceRoadmap.Visibility,
                        Status = sourceRoadmap.Status,
                        StartDate = sourceRoadmap.StartDate,
                        EndDate = sourceRoadmap.EndDate,
                        UserId = userId
                    };
                    _roadmapRepository.Add(targetRoadmap);
                    
                    var sourceRoadmapItems = _roadmapItemRepository.GetList(roadmapItem => roadmapItem.RoadmapId == sourceRoadmap.Id);
                    foreach (var sourceRoadmapItem in sourceRoadmapItems)
                    {
                        var tempItem = new Entity.Domain.Roadmap.RoadmapItem
                        {
                            Title = sourceRoadmapItem.Title,
                            Description = sourceRoadmapItem.Description,
                            Status = sourceRoadmapItem.Status,
                            TargetDate = sourceRoadmapItem.TargetDate,
                            EndDate = sourceRoadmapItem.EndDate,
                            ParentId = sourceRoadmapItem.ParentId,
                            RoadmapId = targetRoadmap.Id
                        };
                        
                        _roadmapItemRepository.Add(tempItem);
                    }

                    var sourceCopiedRoadmapEntity = new CopiedRoadmaps
                    {
                        SourceRoadmapId = sourceRoadmap.Id,
                        SourceRoadmap = sourceRoadmap,
                        TargetRoadmap = targetRoadmap
                    };
                    targetRoadmap.CopiedSourceRoadmaps.Add(sourceCopiedRoadmapEntity);
                    
                    var targetCopiedRoadmapEntity = new CopiedRoadmaps
                    {
                        SourceRoadmapId = sourceRoadmap.Id,
                        SourceRoadmap = sourceRoadmap,
                        TargetRoadmap = targetRoadmap
                    };
                    sourceRoadmap.CopiedTargetRoadmaps.Add(targetCopiedRoadmapEntity);

                    result.Data = targetCopiedRoadmapEntity;
                }
            }
            catch (Exception exception)
            {
                result.IsSuccess = false;
                result.Exception = exception;
                result.Message = exception.Message;
            }

            return result;
        }
    }
}
