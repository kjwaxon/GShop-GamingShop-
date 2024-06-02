using ApplicationCore.Entities.Abstract;

namespace WEB.Models.ViewModels
{
    public class GetProductVM
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public string ProductDescription { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }

        public string? Image { get; set; }

        public string SubcategoryName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Status Status { get; set; }
    }
}
