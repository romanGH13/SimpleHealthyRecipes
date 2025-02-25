using SimpleHealthyRecipes.DTOs;

namespace SimpleHealthyRecipes.Services.Interfaces;

public interface ICategoryService
{
    Task<List<CategoryDTO>> GetAllCategoriesAsync();
    Task<CategoryDTO?> GetCategoryByIdAsync(int id);
}
