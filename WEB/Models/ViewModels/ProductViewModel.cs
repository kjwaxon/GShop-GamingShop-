using ApplicationCore.Entities.Concrete;
using Humanizer.Localisation;

namespace WEB.Models.ViewModels
{
    public class ProductViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Subcategory> Subcategories { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public string SearchTerm { get; set; } = "";
        public int SubcategoryId { get; set; } = 0;
        public int CategoryId { get; set; } = 0;
    }
}
