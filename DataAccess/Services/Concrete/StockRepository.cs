using ApplicationCore.DTO_s.StockDTO;
using ApplicationCore.Entities.Concrete;
using DataAccess.Context;
using DataAccess.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services.Concrete
{
    public class StockRepository : BaseRepository<Stock>, IStockRepository
    {
        private readonly AppDbContext _context;

        public StockRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Stock?> GetStockByProductId(int productID)
            => await _context.Stocks.FirstOrDefaultAsync(x => x.ProductId == productID);

        public async Task<IEnumerable<GetStock>> GetStocks(string searchTerm = "")
        {
            var stocks = await(from product in _context.Products
                               join stock in _context.Stocks
                               on product.Id equals stock.ProductId
                               into product_stock
                               from productStock in product_stock.DefaultIfEmpty()
            where string.IsNullOrWhiteSpace(searchTerm) || product.ProductName.ToLower().Contains(searchTerm.ToLower())
            select new GetStock
            {
                                   ProductId = product.Id,
                                   ProductName = product.ProductName,
                                   Quantity = productStock == null ? 0 : productStock.Quantity
                               }
                                ).ToListAsync();
            return stocks;
        }

        public async Task UpdateStock(UpdateStockDTO model)
        {
            var existingStock= await GetStockByProductId(model.ProductId);
            if (existingStock is null)
            {
                var stock = new Stock {  ProductId = model.ProductId,   Quantity = model.Quantity };
                _context.Stocks.Add(stock);
            }
            else 
            {
                existingStock.Quantity= model.Quantity;
                _context.Stocks.Update(existingStock);
            }
            await _context.SaveChangesAsync();  
        }
    }
}
