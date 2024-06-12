using ApplicationCore.Entities.Abstract;
using ApplicationCore.Entities.Concrete;

namespace WEB.Models.ViewModels
{
    public class GetOrderVM
    {
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentStatus { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public List<GetOrderDetailVM> OrderDetails { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Status Status { get; set; }
    }
}
