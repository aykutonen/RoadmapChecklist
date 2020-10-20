using Entity.Models.Tags;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Tags.Models
{
    public class TagViewModel
    {
        public string Value { get; set; }
        public string FriendlyUrl { get; set; }

        public class TagValidator : AbstractValidator<Tag>
        {
            public TagValidator()
            {
                RuleFor(x => x.Value).NotNull();
                RuleFor(x => x.FriendlyUrl).NotNull();
                RuleFor(x => x.Id).NotNull();
            }
        }
    }
}
