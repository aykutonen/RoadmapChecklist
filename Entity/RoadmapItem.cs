﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Entity
{
    public class RoadmapItem : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? TargetDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? ParentId { get; set; }
        public int RoadmapId { get; set; }


        // Relations
        public virtual Roadmap Roadmap { get; set; }
        public virtual RoadmapItem Parent { get; set; }
        public virtual ICollection<RoadmapItem> Childiren { get; set; }
    }
}
