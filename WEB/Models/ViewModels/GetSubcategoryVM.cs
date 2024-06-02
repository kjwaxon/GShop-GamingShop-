using ApplicationCore.Entities.Abstract;

namespace WEB.Models.ViewModels
{
    public class GetSubcategoryVM
    {
        public int Id { get; set; }
        public string SubcategoryName { get; set; }
        public string CategoryName { get; set; }
        public  DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Status Status { get; set; }
    }
}
