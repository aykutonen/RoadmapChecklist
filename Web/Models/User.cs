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
        public string name { get; set; }
        [Required(ErrorMessage = "Kullanıcı adı zorunlu")]
        public string username { get; set; }
        [Required(ErrorMessage = "Email zorunlu"), DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [Required(ErrorMessage = "Parola zorunlu"), DataType(DataType.Password)]
        public string password { get; set; }
        [Display(Name ="Beni hatırla")]
        public bool rememberMe { get; set; } = true;
    }

    public class Login
    {
        [Required(ErrorMessage = "Email zorunlu"), DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [Required(ErrorMessage = "Parola zorunlu"), DataType(DataType.Password)]
        public string password { get; set; }
    }

}
