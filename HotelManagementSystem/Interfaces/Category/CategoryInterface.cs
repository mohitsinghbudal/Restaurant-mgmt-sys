using HotelManagementSystem.Models.Categories;

namespace HotelManagementSystem.Interfaces.CategoryInterface

{
    public interface ICategoryDLL
    {
        Task<int> AddCategoryAsync(Category category);
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category?> GetCategoryByIdAsync(int categoryId);
        Task<int> UpdateCategoryAsync(Category category);
        Task<int> SoftDeleteCategoryAsync(int categoryId, int deletedBy);
    }
    public interface ICategoryService
    {
        Task<int> CreateCategoryAsync(Category category);
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int categoryId);
        Task<int> UpdateCategoryAsync(Category category);
        Task<int> DeleteCategoryAsync(int categoryId, int deletedBy);
    }
}
