using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Web.Models.RoadmapItem
{
    public class Create
    {
        public string Title { get; set; }
        public Guid RoadmapId { get; set; }
        public Guid? ParentId { get; set; }
        public int? Order  { get; set; }

    }

    public class CreateValidator : AbstractValidator<Create>
    {
        public CreateValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("İsim Zorunlu");
            RuleFor(x => x.RoadmapId).NotNull().WithMessage("Roadmap ID Zorunlu");
        }
    }

    public class DetailItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Order { get; set; }
        public Guid? ParentId { get; set; }
    }

}
