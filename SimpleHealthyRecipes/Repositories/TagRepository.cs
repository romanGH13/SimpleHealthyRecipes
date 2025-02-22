using Microsoft.EntityFrameworkCore;
using SimpleHealthyRecipes.Data;
using SimpleHealthyRecipes.Models;
using SimpleHealthyRecipes.Repositories.Base;

namespace SimpleHealthyRecipes.Repositories;

public class TagRepository : BaseRepository<TagModel>, ITagRepository
{
    public TagRepository(AppDbContext context) : base(context) { }

    public async Task<List<TagModel>> GetByNamesAsync(List<string> tagNames)
    {
        return await _dbSet.Where(t => tagNames.Contains(t.Name)).ToListAsync();
    }

    public async Task AddRangeAsync(List<TagModel> tags)
    {
        await _dbSet.AddRangeAsync(tags);
        await _context.SaveChangesAsync();
    }
}