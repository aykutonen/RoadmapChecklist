using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Web.Models.User
{
    public class Register
    {
        //[Required(ErrorMessage = "İsim zorunlu")]
        public string Name { get; set; }
        //[Required(ErrorMessage = "Kullanıcı adı zorunlu")]
        public string Username { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
    public class RegisterValidator : AbstractValidator<Register>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("İsim zorunlu!");
            RuleFor(x => x.Username).NotNull().WithMessage("Kullanıcı adı zorunlu!");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email zorunlu").EmailAddress().WithMessage("Lütfen geçerli bir mail adresi giriniz.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Parola zorunlu");
        }
    }
    public class Login
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Beni hatırla")]
        public bool RememberMe { get; set; } = true;
    }
    public class LoginValidator : AbstractValidator<Login>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email zorunlu").EmailAddress().WithMessage("Lütfen geçerli bir mail adresi giriniz.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Parola zorunlu");
        }
    }


}
