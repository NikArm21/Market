using Market.Models;

namespace Market.Services
{
    public interface ICategoriesService
    {
        Task<List<Category>> GetCategories();
        Task AddCategory(Category category);
        Task<Category> GetCategoryById(int id);
        Task UpdateCategory(Category category);
         Task DeleteCateegory(int id);
    }
}
