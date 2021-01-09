using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.Roadmap
{
    public class Create
    {
        [Required(ErrorMessage = "İsim zorunlu")]
        public string Name { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "1 den küçük değer giremezsin.")]
        public int Visibility { get; set; } = 1;
        [DataType(DataType.Date, ErrorMessage = "Geçerli bir tarih girin")]
        public DateTime? StartDate { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Geçerli bir tarih girin")]
        public DateTime? EndDate { get; set; }
    }

    public class Edit
    {
        [Required(ErrorMessage = "ID zorunlu")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "İsim zorunlu")]
        public string Name { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "1 den küçük değer giremezsin.")]
        public int Visibility { get; set; } = 1;
        [DataType(DataType.Date, ErrorMessage = "Geçerli bir tarih girin")]
        public DateTime? StartDate { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Geçerli bir tarih girin")]
        public DateTime? EndDate { get; set; }
    }
}
