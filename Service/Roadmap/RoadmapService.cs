using Data.Infrastructure.Repository;
using Data.Infrastructure.UnitOfWork;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.Roadmap
{
    public class RoadmapService : IRoadmapService
    {
        private readonly IRepository<Entity.Roadmap> repository;
        private readonly IRepository<RoadmapCopy> copyRepository;
        private readonly IRepository<Entity.RoadmapItem> itemRepository;
        private readonly IUnitOfWork unitOfWork;

        public RoadmapService(IRepository<Entity.Roadmap> repository, IRepository<RoadmapCopy> copyRepository, IRepository<Entity.RoadmapItem> itemRepository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.copyRepository = copyRepository;
            this.itemRepository = itemRepository;
            this.unitOfWork = unitOfWork;
        }

        public ReturnModel<Entity.Roadmap> Create(Entity.Roadmap roadmap)
        {
            var result = new ReturnModel<Entity.Roadmap>();
            try
            {
                repository.Add(roadmap);
                Save();
                result.Data = roadmap;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Exception = ex;
                result.Message = ex.Message;
            }
            return result;
        }

        public ReturnModel<Entity.Roadmap> Get(int id)
        {
            var result = new ReturnModel<Entity.Roadmap>();
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

        public ReturnModel<List<Entity.Roadmap>> GetByUser(int userid)
        {
            var result = new ReturnModel<List<Entity.Roadmap>>();
            try
            {
                result.Data = repository.GetMany(x => x.UserId == userid);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Exception = ex;
                result.Message = ex.Message;
            }
            return result;
        }

        public ReturnModel<Entity.Roadmap> Update(Entity.Roadmap roadmap)
        {
            var result = new ReturnModel<Entity.Roadmap>();
            try
            {
                repository.Update(roadmap);
                Save();
                result.Data = roadmap;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Exception = ex;
                result.Message = ex.Message;
            }

            return result;
        }

        public ReturnModel<Entity.Roadmap> Copy(int id, int userid)
        {
            var result = new ReturnModel<Entity.Roadmap>();

            try
            {
                // db'den orijinali çek.
                var fromDb = repository.Get(x => x.Id == id, navigations: new string[] { "Targets", "Categories", "Tags", "Items" });
                if (fromDb != null)
                {
                    // aynısından bir kopya oluştur
                    Entity.Roadmap copy = new Entity.Roadmap()
                    {
                        Name = fromDb.Name,
                        UserId = userid,
                        Visibility = fromDb.Visibility,
                    };
                    repository.Attach(copy);

                    #region Categories
                    // TODO: Categorileri ekle
                    #endregion

                    #region Tags
                    // TODO: Etiketleri ekle
                    #endregion

                    #region RoadmapItems
                    copy.Items = new List<Entity.RoadmapItem>();
                    var childeren = fromDb.Items.OrderBy(x => x.ParentId).ThenBy(x => x.Order).ToList();
                    foreach (var child in childeren.Where(x => x.ParentId == null))
                    {
                        var newChild = new Entity.RoadmapItem
                        {
                            Description = child.Description,
                            Order = child.Order,
                            Title = child.Title,
                            Childiren = new List<Entity.RoadmapItem>()
                        };
                        itemRepository.Attach(newChild);
                        getChilderen(ref copy, child, childeren, ref newChild);
                        copy.Items.Add(newChild);
                    }

                    #endregion

                    var rc = new RoadmapCopy { SourceId = fromDb.Id };
                    copyRepository.Attach(rc);
                    rc.TargetRoadmap = copy;
                    Save();

                    // Geriye yeni kopyayı gönder.
                    result.Data = copy;
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

        /// <summary>
        /// Roadmap item'ları ve her birinin alt item'larını kendi kendini çağırarak çeken arkadaş.
        /// </summary>
        /// <param name="item">Aktif RoadmapItem</param>
        /// <param name="items">Tüm RoadmapItem'ların listesi (sıralı tam liste :))</param>
        /// <returns>RoadmapItem Listesi döner.</returns>
        private void getChilderen(ref Entity.Roadmap copy, Entity.RoadmapItem item, List<Entity.RoadmapItem> items, ref Entity.RoadmapItem parent)
        {
            foreach (var child in items.Where(x => x.ParentId == item.Id).OrderBy(x => x.ParentId).ThenBy(x => x.Order))
            {
                var newChild = new Entity.RoadmapItem
                {
                    Title = child.Title,
                    Description = child.Description,
                    Order = child.Order,
                    Childiren = new List<Entity.RoadmapItem>()
                };
                itemRepository.Attach(newChild);
                getChilderen(ref copy, child, items, ref newChild);
                parent.Childiren.Add(newChild);
                copy.Items.Add(newChild);
            }
        }

        public void Save() => unitOfWork.Commit();
    }
}
