using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.Roadmap
{
    public class Create
    {
        //[Required(ErrorMessage = "İsim zorunlu")]
        public string Name { get; set; }
        //[Range(1, int.MaxValue, ErrorMessage = "1 den küçük değer giremezsin.")]
        public int Visibility { get; set; } = 1;
        //[DataType(DataType.Date, ErrorMessage = "Geçerli bir tarih girin")]
        public DateTime? StartDate { get; set; }
        //[DataType(DataType.Date, ErrorMessage = "Geçerli bir tarih girin")]
        public DateTime? EndDate { get; set; }
    }

    public class CreateValidator : AbstractValidator<Create>
    {
        public CreateValidator()
        {

            RuleFor(x => x.Name).NotNull().WithMessage("İsim Zorunlu");
            RuleFor(x => x.Visibility).GreaterThanOrEqualTo(1);
            RuleFor(x => x.StartDate).NotNull().WithMessage("Geçerli bir tarih girin.");
            RuleFor(x => x.EndDate).NotNull().WithMessage("Geçerli bir tarih girin.");
            RuleFor(x => x.StartDate.Value).GreaterThan(x => x.StartDate.Value).WithMessage("Bitiş Tarihi başlangıç tarihinden büyük olmalıdır!").When(x => x.StartDate.HasValue);
        }
    }
    public class Edit
    {
        //[Required(ErrorMessage = "ID zorunlu")]
        public Guid Id { get; set; }
        //[Required(ErrorMessage = "İsim zorunlu")]
        public string Name { get; set; }
        //[Range(1, int.MaxValue, ErrorMessage = "1 den küçük değer giremezsin.")]
        public int Visibility { get; set; } = 1;
        //[DataType(DataType.Date, ErrorMessage = "Geçerli bir tarih girin")]
        public DateTime? StartDate { get; set; }
        //[DataType(DataType.Date, ErrorMessage = "Geçerli bir tarih girin")]
        public DateTime? EndDate { get; set; }
    }

    public class EditValidator : AbstractValidator<Edit>
    {
        public EditValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id zorunlu");
            RuleFor(x => x.Name).NotNull().WithMessage("İsim Zorunlu");
            RuleFor(x => x.Visibility).GreaterThanOrEqualTo(1);
            RuleFor(x => x.StartDate).NotNull().WithMessage("Geçerli bir tarih girin.");
            RuleFor(x => x.EndDate)
                .NotNull().WithMessage("Geçerli bir tarih girin.")
                .GreaterThan(x => x.StartDate.Value).WithMessage("Bitiş Tarihi başlangıç tarihinden büyük olmalıdır!").When(x => x.StartDate.HasValue);
        }
     }

    public class Detail
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Visibility { get; set; } = 1;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
