using Microsoft.AspNetCore.Mvc;
using SimpleHealthyRecipes.Services.Interfaces;

namespace SimpleHealthyRecipes.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TagController : ControllerBase
{
    private readonly ITagService _tagService;

    public TagController(ITagService tagService)
    {
        _tagService = tagService;
    }

    // Отримання всіх тегів (DTO)
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tags = await _tagService.GetAllTagsAsync();
        return Ok(tags);
    }

    // Отримання тегу за ID (DTO)
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var tag = await _tagService.GetTagByIdAsync(id);
        if (tag == null) return NotFound();
        return Ok(tag);
    }
}