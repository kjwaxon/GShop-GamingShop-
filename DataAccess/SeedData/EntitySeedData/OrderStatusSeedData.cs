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
    public class OrderStatusSeedData : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            builder.HasData(
                        new OrderStatus
                        {
                            Id = 1,
                            StatusName = "Pending"
                        },
                        new OrderStatus
                        {
                            Id = 2,
                            StatusName = "Shipped"
                        },
                        new OrderStatus
                        {
                            Id = 3,
                            StatusName = "Delivered"
                        },
                        new OrderStatus
                        {
                            Id = 4,
                            StatusName = "Cancelled"
                        },
                        new OrderStatus
                        {
                            Id = 5,
                            StatusName = "Returned"
                        },
                        new OrderStatus
                        {
                            Id = 6,
                            StatusName = "Refund"
                        }

                );
        }
    }
}
