using ApplicationCore.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services.Interface
{
    public interface IHomeRepository
    {
        Task<IEnumerable<Product>> GetProducts(string searchTerm="",int subcategoryId=0,int categoryId=0);
        Task<IEnumerable<Subcategory>> GetSubcategories(int categoryId=0);
        Task<IEnumerable<Category>> GetCategories();
        Task<List<TResult>> GetFilteredListAsync<TResult>
            (
                Expression<Func<Product,TResult>> select,
                Expression<Func<Product, bool>> where = null,
                Func<IQueryable<Product>, IOrderedQueryable<Product>> orderBy = null,
                Func<IQueryable<Product>, IIncludableQueryable<Product, object>> join = null
            );
    }
}
