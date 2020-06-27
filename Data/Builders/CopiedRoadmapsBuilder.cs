using System;
using System.Collections.Generic;
using System.Text;
using Entity.Domain.Roadmap;

namespace Data.Builders
{
    public class CopiedRoadmapsBuilder : BaseEntityBuilder<CopiedRoadmaps>
    {
        public CopiedRoadmapsBuilder()
        {
            // fields
            

            // relation
            //HasRequired(roadmap => roadmap.User).WithMany().HasForeignKey(roadmap => roadmap.UserId).WillCascadeOnDelete(false);

            // table
            ToTable("CopiedRoadmaps");
        }
    }
}
