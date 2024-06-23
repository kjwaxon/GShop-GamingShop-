using ApplicationCore.Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.DTO_s.OrderDTO
{
    public class UpdateOrderDTO
    {
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int OrderStatusId { get; set; }
        public IEnumerable<SelectListItem> Statuses { get; set; } = new List<SelectListItem>();
    }
}
