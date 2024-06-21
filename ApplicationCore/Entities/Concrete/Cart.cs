using ApplicationCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.Concrete
{
    public class Cart:BaseEntity
    {
        [Required]
        public string UserId { get; set; }
        public bool IsDeleted { get; set; }
        public List<CartDetail> CartDetails { get; set; }
    }
}
