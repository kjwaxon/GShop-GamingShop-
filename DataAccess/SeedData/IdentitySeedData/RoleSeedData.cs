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
    public class RoleSeedData : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            var admin = new IdentityRole
            {
                Id = "66cd8666-bad0-4e8e-9ac4-b803a2722f1f",
                Name = "admin",
                NormalizedName = "ADMIN"

            };
            var appUser = new IdentityRole
            {
                Id = "fc49fd92-5767-4aaa-b552-267c8a3ec7d4",
                Name = "user",
                NormalizedName = "USER"
            };
            builder.HasData(admin,appUser);

        }
    }
}
