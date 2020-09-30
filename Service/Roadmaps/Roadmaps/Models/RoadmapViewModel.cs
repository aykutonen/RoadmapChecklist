using Entity.Models.Roadmaps;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Service.Roadmaps.Roadmaps.Models
{
    public class RoadmapViewModel
    {
        public string Name { get; set; }
        public int Visibility { get; set; } = 1;
        public int Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }

        public class RoadmapValidator : AbstractValidator<Roadmap>
        {
            public RoadmapValidator()
            {
                RuleFor(x => x.UserId).NotNull();
                RuleFor(x => x.Name).Length(0, 500);
                RuleFor(x => x.Visibility).Null();
                RuleFor(x => x.Status).NotNull();
                RuleFor(x => x.StartDate).NotNull();
                RuleFor(x => x.EndDate).NotNull();
            }

            //return FluentValidation
        }
    }
}
