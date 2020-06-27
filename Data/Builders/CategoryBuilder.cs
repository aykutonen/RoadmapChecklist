using System;
using System.Collections.Generic;
using System.Text;
using Entity.Domain.Roadmap;

namespace Data.Builders
{
    public class CategoryBuilder : BaseEntityBuilder<Category>
    {
        public CategoryBuilder()
        {
            // fields
            Property(category => category.Value).IsRequired().HasMaxLength(255);
            Property(category => category.FriendlyUrl).IsRequired().HasMaxLength(255);
            

            // relation
            //HasRequired(t => t.UserRole).WithMany().HasForeignKey(t => t.UserRoleId).WillCascadeOnDelete(false);

            // table
            ToTable("Category");
        }
    }
}
