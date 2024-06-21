using ApplicationCore.Entities.Abstract;
using ApplicationCore.Entities.Concrete;
using DataAccess.Context;
using DataAccess.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services.Concrete
{
    public class HomeRepository : IHomeRepository
    {
        private readonly AppDbContext _context;

        public HomeRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _context.Categories.Where(x=>x.Status!=Status.Passive).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProducts(string searchTerm = "", int subcategoryId = 0, int categoryId = 0)
        {
            searchTerm = searchTerm.ToLower();
            var query = from product in _context.Products
                        join subcategory in _context.Subcategories
                        on product.SubcategoryId equals subcategory.Id
                        join category in _context.Categories
                        on subcategory.CategoryId equals category.Id
                        join stock in _context.Stocks
                        on product.Id equals stock.ProductId into product_stocks
                        from productWithStock in product_stocks.DefaultIfEmpty()
                        where category.Status != Status.Passive &&
                              (string.IsNullOrWhiteSpace(searchTerm) || product.ProductName.ToLower().Contains(searchTerm)) &&
                              (subcategoryId == 0 || product.SubcategoryId == subcategoryId) &&
                              (categoryId == 0 || subcategory.CategoryId == categoryId)
                        select new Product
                        {
                            Id = product.Id,
                            Image = product.Image,
                            ImagePath = product.ImagePath,
                            Description = product.Description,
                            ProductName = product.ProductName,
                            SubcategoryId = product.SubcategoryId,
                            UnitPrice = product.UnitPrice,
                            SubcategoryName = subcategory.SubcategoryName,
                            Quantity = productWithStock == null ? 0 : productWithStock.Quantity,
                        };

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Subcategory>> GetSubcategories(int categoryId = 0)
        {
            var query = from subcategory in _context.Subcategories
                        join category in _context.Categories
                        on subcategory.CategoryId equals category.Id
                        where category.Status != Status.Passive
                        select new Subcategory
                        {
                            Id = subcategory.Id,
                            SubcategoryName = subcategory.SubcategoryName,
                            CategoryId = subcategory.CategoryId
                        };

            if (categoryId > 0)
            {
                query = query.Where(s => s.CategoryId == categoryId);
            }

            return await query.ToListAsync();
        }

        public async Task<List<TResult>> GetFilteredListAsync<TResult>(
        Expression<Func<Product, TResult>> select,
        Expression<Func<Product, bool>> where = null,
        Func<IQueryable<Product>, IOrderedQueryable<Product>> orderBy = null,
        Func<IQueryable<Product>, IIncludableQueryable<Product, object>> join = null)
        {
            IQueryable<Product> query = _context.Set<Product>();

            if (join != null)
            {
                query = join(query);
            }

            if (where != null)
            {
                query = query.Where(where);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await query.Select(select).ToListAsync();
        }
    }
}
