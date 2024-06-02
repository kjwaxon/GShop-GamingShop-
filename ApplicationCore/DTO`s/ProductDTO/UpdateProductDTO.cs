using ApplicationCore.DTO_s.SubcategoryDTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.DTO_s.ProductDTO
{
    public class UpdateProductDTO
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        [Display(Name = "Product Name")]
        public string? ProductName { get; set; }

        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Display(Name = "Price")]
        public double? UnitPrice { get; set; }

        [Display(Name = "Quantity")]
        public int? Quantity { get; set; }
        public string? Image { get; set; }

        [Display(Name = "Image")]
        public IFormFile? UploadImage { get; set; }

        [Display(Name = "Subcategory")]
        public int? SubcategoryId { get; set; }

        public List<ShowSubcategoryDTO>? Subcategories { get; set; }
    }
}
