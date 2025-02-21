using Microsoft.EntityFrameworkCore;
using SimpleHealthyRecipes.Requests.Base;

namespace SimpleHealthyRecipes.Extensions;

public static class RepositoryExtension
{
    public static (List<T> Items, int TotalCount) Page<T>(this IQueryable<T> query, BasePaginationRequest schema) where T : class
    {
        int totalCount = query.Count();
        List<T> list = query
            .Skip((schema.Page - 1) * schema.PageSize)
            .Take(schema.PageSize)
            .ToList();

        return (list, totalCount);
    }

    public static async Task<(List<T> Items, int TotalCount)> PageAsync<T>(this IQueryable<T> query, BasePaginationRequest schema) where T : class
    {
        int totalCount = await query.CountAsync();
        List<T> list = await query
            .Skip((schema.Page - 1) * schema.PageSize)
            .Take(schema.PageSize)
            .ToListAsync();

        return (list, totalCount);
    }
}