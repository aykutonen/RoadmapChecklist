using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Web.Models.User
{
    public class Register
    {
        [Required(ErrorMessage = "İsim zorunlu")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Kullanıcı adı zorunlu")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Email zorunlu"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Parola zorunlu"), DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="Beni hatırla")]
        public bool RememberMe { get; set; } = true;

    }

    public class Login
    {
        [Required(ErrorMessage = "Email zorunlu"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Parola zorunlu"), DataType(DataType.Password)]
        public string Password { get; set; }

    }

    
}
