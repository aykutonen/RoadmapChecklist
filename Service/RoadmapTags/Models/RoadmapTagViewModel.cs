using Entity.Models.Tags;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.RoadmapTags.Models
{
    public class RoadmapTagViewModel
    {
        public int TagId { get; set; }
        public int RoadmapId { get; set; }

        public class RoadmapTagValidator : AbstractValidator<RoadmapTag>
        {
            public RoadmapTagValidator()
            {
                RuleFor(x => x.TagId).NotNull();
                RuleFor(x => x.RoadmapId).NotNull();
            }
        }
    }
}
