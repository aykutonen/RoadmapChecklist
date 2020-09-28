using Entity.Models.Roadmaps;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Service.Roadmaps.Roadmaps.Models
{
    public class RoadmapViewModel
    {
        [Required]
        [StringLength(500)]
        public string Name { get; set; }
        [Required]
        public int Visibility { get; set; } = 1;
        [Required]
        public int Status { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public int UserId { get; set; }

        //return FluentValidation
    }
}
