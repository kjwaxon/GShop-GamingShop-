using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SeedData.IdentitySeedData
{
    public class UserRoleSeedData : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData
                (
                    new IdentityUserRole<string>
                    {
                        RoleId = "66cd8666-bad0-4e8e-9ac4-b803a2722f1f",
                        UserId = "d297d83e-f9c8-4534-a81c-fe005bd61668"
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = "fc49fd92-5767-4aaa-b552-267c8a3ec7d4",
                        UserId = "a62a40f0-d8d9-4a80-92f8-6722612df266"
                    }
                ); 
        }
    }
}
