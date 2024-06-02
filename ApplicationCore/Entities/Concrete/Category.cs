using ApplicationCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.Concrete
{
    public class Category:BaseEntity
    {
        public Category()
        {
            Subcategories = new List<Subcategory>();
        }
        [Required]
        [MaxLength(100)]
        [MinLength(2)]
        public string CategoryName { get; set; }
        [Required]
        [MaxLength(200)]
        [MinLength(3)]
        public string Description { get; set; }
        public List<Subcategory> Subcategories { get; set; }


    }
}
