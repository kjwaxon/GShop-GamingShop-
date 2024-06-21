using ApplicationCore.Entities.UserEntities.Concrete;
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
    public class UserSeedData : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            var hasher = new PasswordHasher<AppUser>();

            var admin = new AppUser
            {
                Id = "d297d83e-f9c8-4534-a81c-fe005bd61668",
                FirstName = "Kaan",
                LastName = "Admin",
                BirthDate = new DateTime(1996, 01, 19),
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "kaanadmin@gshop.com",
                NormalizedEmail = "KAANADMIN@GSHOP.COM",
                PasswordHash=hasher.HashPassword(null,"123")
            };
            var appUser = new AppUser
            {
                Id = "a62a40f0-d8d9-4a80-92f8-6722612df266",
                FirstName = "Kaan",
                LastName = "Aslan",
                BirthDate = new DateTime(1996, 01, 19),
                UserName = "kaan.aslan",
                NormalizedUserName = "KAAN.ASLAN",
                Email = "kaanaslan@gshop.com",
                NormalizedEmail = "KAANASLAN@GSHOP.COM",
                PasswordHash = hasher.HashPassword(null, "123")
            };
            builder.HasData(admin,appUser);
        }
    }
}
