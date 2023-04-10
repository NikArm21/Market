using Market.Models;
using Microsoft.EntityFrameworkCore;

namespace Market.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly MarketDbContext _context;
        private readonly IWareHouseService _wareHouseService;

        public CategoriesService(MarketDbContext context, IWareHouseService wareHouseService)
        {
            _context = context;
            _wareHouseService = wareHouseService;
        }

        public async Task<List<Category>> GetCategories()
        {
            var categories = await _context.Categories.ToListAsync();

            return categories;
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategory(Category category)
        {
            var categories = await _context.Categories.FirstOrDefaultAsync(x => x.Id == category.Id);
            if (categories == null)
            {
                categories.Products = category.Products;
                categories.Name = category.Name;
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCateegory(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category != null)
            {
                _context.Categories.Remove(category);
            }
            await _context.SaveChangesAsync();
        }
    }
}
