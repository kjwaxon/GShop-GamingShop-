using ApplicationCore.DTO_s.StockDTO;
using ApplicationCore.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services.Interface
{
    public interface IStockRepository
    {
        Task<IEnumerable<GetStock>> GetStocks(string searchTerm = "");
        Task<Stock?> GetStockByProductId(int productID);
        Task UpdateStock(UpdateStockDTO model);
    }
}
