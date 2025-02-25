using SimpleHealthyRecipes.DTOs;

namespace SimpleHealthyRecipes.Services.Interfaces;
public interface ITagService
{
    Task<List<TagDTO>> GetAllTagsAsync();
    Task<TagDTO?> GetTagByIdAsync(int id);
}