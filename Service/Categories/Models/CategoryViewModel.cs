using Entity.Models.Categories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Categories.Models
{
    public class CategoryViewModel
    {
        public string Value { get; set; }
        public string FriendlyUrl { get; set; }

        public class CategoryValidator : AbstractValidator<Category>
        {
            public CategoryValidator()
            {
                RuleFor(x => x.Value).NotNull();
                RuleFor(x => x.FriendlyUrl).NotNull();
                RuleFor(x => x.Id).NotNull();
            }
        }
    }
}
