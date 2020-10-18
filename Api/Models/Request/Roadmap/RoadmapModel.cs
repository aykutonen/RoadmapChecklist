using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Models.Request.Roadmap
{
    public class RoadmapModel
    {
        [Required(ErrorMessage = "Name field is required !"), 
         StringLength(250, ErrorMessage = "Name length should be a maximum of 250 characters.")]
        public string Name { get; set; }
        public int Visibility { get; set; }
        public int Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }
        public int TagId { get; set; }
    }
}