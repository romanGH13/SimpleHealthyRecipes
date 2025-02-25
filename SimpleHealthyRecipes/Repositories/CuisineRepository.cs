using Microsoft.EntityFrameworkCore;
using SimpleHealthyRecipes.Data;
using SimpleHealthyRecipes.Models;
using SimpleHealthyRecipes.Repositories.Base;
using SimpleHealthyRecipes.Repositories.Interfaces;

namespace SimpleHealthyRecipes.Repositories;

public class CuisineRepository : BaseRepository<CuisineModel>, ICuisineRepository
{
    public CuisineRepository(AppDbContext context) : base(context) { }

    public async Task<List<CuisineModel>> GetAllCuisinesAsync()
    {
        return await _context.Cuisines.ToListAsync();
    }

    public async Task<CuisineModel?> GetCuisineByIdAsync(int id)
    {
        return await _context.Cuisines.FindAsync(id);
    }
}