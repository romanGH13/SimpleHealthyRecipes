using AutoMapper;
using SimpleHealthyRecipes.DTOs;
using SimpleHealthyRecipes.Repositories.Interfaces;
using SimpleHealthyRecipes.Services.Interfaces;

namespace SimpleHealthyRecipes.Services;

public class CuisineService(ICuisineRepository cuisineRepository, IMapper mapper) : ICuisineService
{
    private readonly ICuisineRepository _cuisineRepository = cuisineRepository;

    public async Task<List<CuisineDTO>> GetAllCuisinesAsync()
    {
        var cuisines = await _cuisineRepository.GetAllCuisinesAsync();
        return mapper.Map<List<CuisineDTO>>(cuisines);
    }

    public async Task<CuisineDTO?> GetCuisineByIdAsync(int id)
    {
        var cuisine = await _cuisineRepository.GetCuisineByIdAsync(id);
        if (cuisine == null) return null;

        return mapper.Map<CuisineDTO>(cuisine);
    }
}