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
    public class CategoryRepository : BaseRepository<Category>,ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<bool> IsThereAnySubcategories(int id)
           => _context.Categories.Include(x => x.Subcategories).FirstOrDefaultAsync(x => x.Id == id).Result.Subcategories.Count > 0 ? true : false;
    }
}
