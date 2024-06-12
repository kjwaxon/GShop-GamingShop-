using ApplicationCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.Concrete
{
    public class Cart:BaseEntity
    {
        public string UserId { get; set; }

        public List<CartDetail> CartDetails { get; set; } = new List<CartDetail>();
    }
}
