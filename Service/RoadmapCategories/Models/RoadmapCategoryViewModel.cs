using Entity.Models.Categories;
using Entity.Models.Roadmaps;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.RoadmapCategories
{
    public class RoadmapCategoryViewModel
    {
        public int CategoryId { get; set; }
        public int RoadmapId { get; set; }


        public Category Category { get; set; }
        public Roadmap Roadmap { get; set; }
    }
    public class RoadmapCategoryValidator : AbstractValidator<RoadmapCategory>
    {
        public RoadmapCategoryValidator()
        {
            RuleFor(x => x.CategoryId).NotNull();
            RuleFor(x => x.RoadmapId).NotNull();
            RuleFor(x => x.Roadmap).NotNull();
            RuleFor(x => x.Category).NotNull();
        }
    }
}

