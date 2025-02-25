using Microsoft.EntityFrameworkCore;
using SimpleHealthyRecipes.Data;
using SimpleHealthyRecipes.Models;
using SimpleHealthyRecipes.Repositories.Base;
using SimpleHealthyRecipes.Repositories.Interfaces;

namespace SimpleHealthyRecipes.Repositories;
public class CategoryRepository(AppDbContext context) : BaseRepository<CategoryModel>(context), ICategoryRepository
{
    public async Task<List<CategoryModel>> GetAllCategoriesAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<CategoryModel?> GetCategoryByIdAsync(int id)
    {
        return await _context.Categories.FindAsync(id);
    }
}
