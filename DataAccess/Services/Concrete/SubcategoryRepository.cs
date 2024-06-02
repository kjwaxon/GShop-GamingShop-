using ApplicationCore.Entities.Concrete;
using DataAccess.Context;
using DataAccess.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services.Concrete
{
    public class SubcategoryRepository : BaseRepository<Subcategory>, ISubcategoryRepository
    {
        private readonly AppDbContext _context;

        public SubcategoryRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> IsThereAnyProducts(int id)
            => _context.Subcategories.Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == id).Result.Products.Count > 0 ? true : false;
    }
}
