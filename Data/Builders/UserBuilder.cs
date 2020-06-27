using System;
using System.Collections.Generic;
using System.Text;
using Entity.Domain.User;

namespace Data.Builders
{
    public class UserBuilder : BaseEntityBuilder<User>
    {
        public UserBuilder()
        {
            // fields
            Property(user => user.Name).IsRequired().HasMaxLength(255);
            Property(user => user.Email).IsRequired().HasMaxLength(255);
            Property(user => user.Password).IsRequired().HasMaxLength(100);
            Property(user => user.Picture).IsOptional().HasMaxLength(255);
            Property(user => user.Status).IsRequired();

            // relation
            

            // table
            ToTable("User");
        }
    }
}
