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
    public class SubcategorySeedData : IEntityTypeConfiguration<Subcategory>
    {
        public void Configure(EntityTypeBuilder<Subcategory> builder)
        {
            builder.HasData
                (
                    new Subcategory
                    {
                        Id = 1,
                        SubcategoryName = "Chairs",
                        CategoryId = 1
                    },
                    new Subcategory
                    {
                        Id = 2,
                        SubcategoryName = "Desks",
                        CategoryId = 1
                    },
                    new Subcategory
                    {
                        Id = 3,
                        SubcategoryName = "Stands",
                        CategoryId = 1
                    },
                    new Subcategory
                    {
                        Id = 4,
                        SubcategoryName = "Headsets",
                        CategoryId = 2
                    },
                    new Subcategory
                    {
                        Id = 5,
                        SubcategoryName = "Keyboards",
                        CategoryId = 2
                    },
                    new Subcategory
                    {
                        Id = 6,
                        SubcategoryName = "Mice",
                        CategoryId = 2
                    },
                    new Subcategory
                    {
                        Id = 7,
                        SubcategoryName = "Mousepads",
                        CategoryId = 2
                    },
                    new Subcategory
                    {
                        Id = 8,
                        SubcategoryName = "Monitors",
                        CategoryId = 2
                    },
                    new Subcategory
                    {
                        Id = 9,
                        SubcategoryName = "Microphones",
                        CategoryId = 2
                    },
                    new Subcategory
                    {
                        Id = 10,
                        SubcategoryName = "Controllers",
                        CategoryId = 2
                    },
                    new Subcategory
                    {
                        Id = 11,
                        SubcategoryName = "Speakers",
                        CategoryId = 2
                    },
                    new Subcategory
                    {
                        Id = 12,
                        SubcategoryName = "Cameras",
                        CategoryId = 2
                    },
                    new Subcategory
                    {
                        Id = 13,
                        SubcategoryName = "Laptops",
                        CategoryId = 3
                    },
                    new Subcategory
                    {
                        Id = 14,
                        SubcategoryName = "Desktops",
                        CategoryId = 3
                    }

                );
        }
    }
}
