using SimpleHealthyRecipes.Models;
using SimpleHealthyRecipes.Repositories.Base;

namespace SimpleHealthyRecipes.Repositories;

public interface ITagRepository : IBaseRepository<TagModel>
{
    Task<List<TagModel>> GetByNamesAsync(List<string> tagNames);
    Task AddRangeAsync(List<TagModel> tags);
}