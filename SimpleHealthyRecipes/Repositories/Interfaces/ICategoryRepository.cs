using SimpleHealthyRecipes.Models;
using SimpleHealthyRecipes.Repositories.Base;

namespace SimpleHealthyRecipes.Repositories.Interfaces;

public interface ICategoryRepository : IBaseRepository<CategoryModel>
{
    Task<List<CategoryModel>> GetAllCategoriesAsync();
    Task<CategoryModel?> GetCategoryByIdAsync(int id);
}