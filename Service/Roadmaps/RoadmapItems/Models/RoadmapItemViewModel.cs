using Entity.Models.Roadmaps;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Roadmaps.RoadmapItems.Models
{
    public class RoadmapItemViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime TargetEndDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RoadmapId { get; set; }
        public int ParentId { get; set; }

        public class RoadmapItemValidator : AbstractValidator<RoadmapItem>
        {
            public RoadmapItemValidator()
            {
                RuleFor(x => x.Title).Length(0,max:500);
                RuleFor(x => x.Description).Length(0, max:1000);
                RuleFor(x => x.Status).NotNull();
                RuleFor(x => x.TargetEndDate).Null();
                RuleFor(x => x.EndDate).NotNull();
                RuleFor(x => x.RoadmapId).NotNull();
                RuleFor(x => x.ParentId).NotNull();
            }
        }
    }
}
