﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Tag : ModelBase
    {
        public string Value { get; set; }
        public string FriendlyUrl { get; set; }

        public virtual ICollection<RoadmapTag> RoadmapTag { get; set; }
    }
}
