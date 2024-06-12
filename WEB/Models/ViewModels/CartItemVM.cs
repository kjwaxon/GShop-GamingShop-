﻿using Microsoft.Build.Evaluation;

namespace WEB.Models.ViewModels
{
    public class CartItemVM
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }
        public decimal TotalPrice => (decimal)UnitPrice * Quantity;

    }
}
