using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.DTO_s.StockDTO
{
    public class UpdateStockDTO
    {
        public int ProductId { get; set; }
        [Range(0, int.MaxValue, ErrorMessage ="Quantity can't be below 0.")]
        public int Quantity { get; set; }
    }
}
