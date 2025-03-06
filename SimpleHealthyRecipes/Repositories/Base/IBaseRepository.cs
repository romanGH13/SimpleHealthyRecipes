using SimpleHealthyRecipes.Models.Base;

namespace SimpleHealthyRecipes.Repositories.Base;

public interface IBaseRepository<T> where T : BaseEntity<int>
{
    IQueryable<T> GetQueryable(bool asNoTracking = false);

    Task<List<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task AddAsync(T entity);
    Task AddRangeAsync(List<T> entities);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}