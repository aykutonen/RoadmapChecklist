using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Models.Request.Roadmap
{
    public class RoadmapItemModel
    {
        [Required(ErrorMessage = "Title field is required !"), 
         StringLength(500, ErrorMessage = "Title length should be a maximum of 500 characters.")]
        public string Title { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime TargetDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RoadmapId { get; set; }
        public int ParentId { get; set; }
    }
}
