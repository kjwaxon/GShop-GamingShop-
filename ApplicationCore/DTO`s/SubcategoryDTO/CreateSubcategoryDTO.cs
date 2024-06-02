using ApplicationCore.DTO_s.CategoryDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.DTO_s.SubcategoryDTO
{
    public class CreateSubcategoryDTO
    {
        [Display(Name ="Subcategory Name")]
        public string? SubcategoryName { get; set; }

        [Display(Name = "Category")]
        public int? CategoryId { get; set; }

        public List<ShowCategoryDTO>? Categories { get; set; }

    }
}
