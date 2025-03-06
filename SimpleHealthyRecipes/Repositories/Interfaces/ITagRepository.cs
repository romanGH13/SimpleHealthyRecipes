using SimpleHealthyRecipes.Models;
using SimpleHealthyRecipes.Repositories.Base;

namespace SimpleHealthyRecipes.Repositories.Interfaces;

public interface ITagRepository : IBaseRepository<TagModel>
{
    Task<List<TagModel>> GetByNamesAsync(List<string> tagNames);
    Task<List<TagModel>> GetAllTagsAsync();
    Task<TagModel?> GetTagByIdAsync(int id);
}