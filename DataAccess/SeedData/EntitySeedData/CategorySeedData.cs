using ApplicationCore.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SeedData.EntitySeedData
{
    public class CategorySeedData : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData
                 (
                     new Category
                     {
                         Id=1,
                         CategoryName="Gaming Furniture",
                         Description="Gaming Chairs,Desks and Stands"
                     },
                     new Category
                     {
                         Id=2,
                         CategoryName="Gaming Accessories",
                         Description="Gaming Headset,Keyboard,Mouse,Mousepad,Monitor,Microphone,Controller,Speaker,Camera"
                     },
                     new Category
                     {
                         Id=3,
                         CategoryName="Gaming Computers",
                         Description="Gaming Laptops and Desktop Computers"
                     }

                 );
        }
    }
}
