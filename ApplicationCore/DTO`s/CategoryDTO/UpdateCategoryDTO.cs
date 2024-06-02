using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.DTO_s.CategoryDTO
{
    public class UpdateCategoryDTO
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        [Display(Name = "Category Name")]
        public string? CategoryName { get; set; }

        [Display(Name = "Category Description")]
        public string? Description { get; set; }


    }
}
