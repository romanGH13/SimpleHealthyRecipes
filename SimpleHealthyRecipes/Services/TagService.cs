using AutoMapper;
using SimpleHealthyRecipes.DTOs;
using SimpleHealthyRecipes.Repositories.Interfaces;
using SimpleHealthyRecipes.Services.Interfaces;

namespace SimpleHealthyRecipes.Services;

public class TagService(ITagRepository tagRepository, IMapper mapper) : ITagService
{
    private readonly ITagRepository _tagRepository = tagRepository;

    public async Task<List<TagDTO>> GetAllTagsAsync()
    {
        var tags = await _tagRepository.GetAllTagsAsync();
        return mapper.Map<List<TagDTO>>(tags);
    }

    public async Task<TagDTO?> GetTagByIdAsync(int id)
    {
        var tag = await _tagRepository.GetTagByIdAsync(id);
        if (tag == null) return null;

        return mapper.Map<TagDTO>(tag);
    }
}