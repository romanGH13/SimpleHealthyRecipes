using SimpleHealthyRecipes.DTOs;

namespace SimpleHealthyRecipes.Services.Interfaces;

public interface ICuisineService
{
    Task<List<CuisineDTO>> GetAllCuisinesAsync();
    Task<CuisineDTO?> GetCuisineByIdAsync(int id);
}