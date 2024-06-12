using ApplicationCore.Entities.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.Concrete
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public bool IsAvailable { get; set; }
        public string ImagePath { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }
        public int SubcategoryId { get; set; }
        public Subcategory Subcategory { get; set; }

        public bool CheckAvailability(int requiredQuantity)
        {
            return IsAvailable && Quantity>= requiredQuantity;
        }
    }
}
