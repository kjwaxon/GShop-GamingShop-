using ApplicationCore.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.DTO_s.OrderDTO
{
    public class OrderDetailModalDTO
    {
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
