using ApplicationCore.Entities.Abstract;

namespace WEB.Models.ViewModels
{
    public class GetCategoryVM
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Status Status{ get; set; }
    }
}
