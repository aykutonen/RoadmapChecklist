using Entity.Models.Roadmaps;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Roadmaps.CopiedRoadmaps.Models
{
    public class CopiedRoadmapViewModel
    {
        public int SourceRoadmapId { get; set; }
        public int TargetRoadmapId { get; set; }
    }
    public class CopiedRoadmapValidator : AbstractValidator<CopiedRoadmap>
    {
        public CopiedRoadmapValidator()
        {
            RuleFor(x => x.SourceRoadmapId).NotNull();
            RuleFor(x => x.TargetRoadmapId).NotNull();
        }
    }
}

