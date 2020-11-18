using Data.Infrastructure.Repository;
using Data.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.RoadmapItem
{
    public class RoadmapItemService : IRoadmapItemService
    {
        private readonly IRepository<Entity.RoadmapItem> repository;
        private readonly IUnitOfWork unitOfWork;

        public RoadmapItemService(IRepository<Entity.RoadmapItem> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public ReturnModel<Entity.RoadmapItem> Create(Entity.RoadmapItem item)
        {
            var result = new ReturnModel<Entity.RoadmapItem>();
            try
            {
                var order = 1;

                // Sıra belirtilmemişse en sona ekle.
                if (item.Order == 0)
                {
                    try { order = repository.AsIQueryable(x => x.ParentId == item.ParentId, o => o.Order).Max(x => x.Order) + 1; }
                    catch { }
                    item.Order = order;
                }
                // Sıra belirtilmişse belirtilen sıradan sonraki kayıtları tekrar sırala
                else
                {
                    var nextRecords = repository.GetMany(x => x.ParentId == item.ParentId && x.Order >= item.Order, o => o.Order, true);
                    if (nextRecords != null && nextRecords.Count > 0)
                    {
                        var lastOrder = item.Order + 1;
                        foreach (var ri in nextRecords)
                        {
                            ri.Order = lastOrder;
                            repository.Update(ri);
                            lastOrder++;
                        }
                    }
                }

                repository.Add(item);
                Save();
                result.Data = item;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Exception = ex;
                result.Message = ex.Message;
            }
            return result;
        }

        public ReturnModel<Entity.RoadmapItem> Get(int id)
        {
            var result = new ReturnModel<Entity.RoadmapItem>();
            try
            {
                result.Data = repository.Get(x => x.Id == id);
                if (result.Data == null)
                {
                    result.IsSuccess = false;
                    result.Message = "Not found a record.";
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

        public ReturnModel<List<Entity.RoadmapItem>> GetByRoadmap(int roadmapid)
        {
            var result = new ReturnModel<List<Entity.RoadmapItem>>();
            try
            {
                result.Data = repository.GetMany(x => x.RoadmapId == roadmapid, o => o.Id, true);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Exception = ex;
                result.Message = ex.Message;
            }
            return result;
        }

        public ReturnModel<Entity.RoadmapItem> Update(Entity.RoadmapItem item)
        {
            var result = new ReturnModel<Entity.RoadmapItem>();
            try
            {
                item.UpdateAt = DateTime.UtcNow;
                repository.Update(item);
                Save();
                result.Data = item;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Exception = ex;
                result.Message = ex.Message;
            }

            return result;
        }
        public void Save() => unitOfWork.Commit();
    }
}
