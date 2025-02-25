using AutoMapper;
using SimpleHealthyRecipes.DTOs;
using SimpleHealthyRecipes.Repositories.Interfaces;
using SimpleHealthyRecipes.Services.Interfaces;

namespace SimpleHealthyRecipes.Services;

public class CategoryService(ICategoryRepository categoryRepository, IMapper mapper) : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;

    public async Task<List<CategoryDTO>> GetAllCategoriesAsync()
    {
        var categories = await _categoryRepository.GetAllCategoriesAsync();
        return mapper.Map<List<CategoryDTO>>(categories);
    }

    public async Task<CategoryDTO?> GetCategoryByIdAsync(int id)
    {
        var category = await _categoryRepository.GetCategoryByIdAsync(id);
        if (category == null) return null;

        return mapper.Map<CategoryDTO>(category);
    }
}
