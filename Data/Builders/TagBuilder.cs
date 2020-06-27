using System;
using System.Collections.Generic;
using System.Text;
using Entity.Domain.Roadmap;

namespace Data.Builders
{
    public class TagBuilder : BaseEntityBuilder<Tag>
    {
        public TagBuilder()
        {
            // fields
            Property(tag => tag.Value).IsRequired().HasMaxLength(255);
            Property(tag => tag.FriendlyUrl).IsRequired().HasMaxLength(255);


            // relation
            //HasRequired(t => t.UserRole).WithMany().HasForeignKey(t => t.UserRoleId).WillCascadeOnDelete(false);

            // table
            ToTable("Tag");
        }
    }
}
