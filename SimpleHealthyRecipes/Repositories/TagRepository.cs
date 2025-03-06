using Microsoft.EntityFrameworkCore;
using SimpleHealthyRecipes.Data;
using SimpleHealthyRecipes.Models;
using SimpleHealthyRecipes.Repositories.Base;
using SimpleHealthyRecipes.Repositories.Interfaces;

namespace SimpleHealthyRecipes.Repositories;

public class TagRepository : BaseRepository<TagModel>, ITagRepository
{
    public TagRepository(AppDbContext context) : base(context) { }

    public async Task<List<TagModel>> GetByNamesAsync(List<string> tagNames)
    {
        return await _dbSet.Where(t => tagNames.Contains(t.Name)).ToListAsync();
    }

    public async Task<List<TagModel>> GetAllTagsAsync()
    {
        return await _context.Tags.ToListAsync();
    }

    public async Task<TagModel?> GetTagByIdAsync(int id)
    {
        return await _context.Tags.FindAsync(id);
    }
}