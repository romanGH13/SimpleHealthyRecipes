using SimpleHealthyRecipes.Models;
using SimpleHealthyRecipes.Repositories.Base;
using SimpleHealthyRecipes.Requests.Recipe;

namespace SimpleHealthyRecipes.Repositories.Interfaces;

public interface ICuisineRepository : IBaseRepository<CuisineModel>
{
    Task<List<CuisineModel>> GetAllCuisinesAsync();
    Task<CuisineModel?> GetCuisineByIdAsync(int id);
}
