using System.ComponentModel.DataAnnotations;

namespace WEB.Models.ViewModels
{
    public class CheckoutVM
    {
        public int OrderId { get; set; }
        public string BuyerId { get; set; }
        public List<CartItemVM> CartItems { get; set; }
        public decimal TotalAmount { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string CVV { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
    }
}
