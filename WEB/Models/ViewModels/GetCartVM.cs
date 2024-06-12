namespace WEB.Models.ViewModels
{
    public class GetCartVM
    {
        public int Id { get; set; }
        public string BuyerId { get; set; }
        public List<CartItemVM> cartItems { get; set; }
        public decimal TotalPrice=> cartItems.Sum(x => x.TotalPrice);
    }
}
