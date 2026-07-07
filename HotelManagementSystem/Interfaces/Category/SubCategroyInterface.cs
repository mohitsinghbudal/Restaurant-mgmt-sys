using HotelManagementSystem.Models.Categories;

namespace HotelManagementSystem.Interfaces.SubCategoryInterface
{
    public interface ISubCategoryService
    {
        Task<int> CreateSubCategoryAsync(SubCategory subCategory);
        Task<IEnumerable<SubCategory>> GetAllSubCategoriesAsync();
        Task<IEnumerable<SubCategory>> GetSubCategoriesByCategoryIdAsync(int categoryId);
        Task<SubCategory> GetSubCategoryByIdAsync(int subCategoryId);
        Task<int> UpdateSubCategoryAsync(SubCategory subCategory);
        Task<int> DeleteSubCategoryAsync(int subCategoryId, int deletedBy);
    }
    public interface ISubCategoryDLL
    {
        Task<int> AddSubCategoryAsync(SubCategory subCategory);
        Task<IEnumerable<SubCategory>> GetAllSubCategoriesAsync();
        Task<IEnumerable<SubCategory>> GetSubCategoriesByCategoryIdAsync(int categoryId);
        Task<SubCategory?> GetSubCategoryByIdAsync(int subCategoryId);
        Task<int> UpdateSubCategoryAsync(SubCategory subCategory);
        Task<int> SoftDeleteSubCategoryAsync(int subCategoryId, int deletedBy);
    }
}
