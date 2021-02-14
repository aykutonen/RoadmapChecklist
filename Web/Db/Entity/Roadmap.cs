using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Web.Db.Entity
{
    [BindProperties]
    public class Roadmap
    {
        public Guid Id { get; set; }

        //[Display(Name="İsim")]
        public string Name { get; set; }
        //[Display(Name = "Görünürlük")]
        public int Visibility { get; set; } = 1;
        //[Display(Name = "Durum")]
        public int Status { get; set; } = 1;
        //[Display(Name = "Başlangıç Tarihi")]
        public DateTime? StartDate { get; set; }
        //[Display(Name = "Bitiş Tarihi")]
        public DateTime? EndDate { get; set; }
        //[Display(Name = "User id")]
        public int UserId { get; set; }


        public virtual User User { get; set; }
    }
}
