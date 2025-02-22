using Microsoft.EntityFrameworkCore;
using SimpleHealthyRecipes.Models;

namespace SimpleHealthyRecipes.Data;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using System;
using SimpleHealthyRecipes.Models.Base;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<RecipeModel> Recipes { get; set; }
    public DbSet<IngredientModel> Ingredients { get; set; }
    public DbSet<CategoryModel> Categories { get; set; }
    public DbSet<TagModel> Tags { get; set; }
    public DbSet<RatingModel> Ratings { get; set; }
    public DbSet<CuisineModel> Cuisines { get; set; }
    public DbSet<MovieReferenceModel> MovieReferences { get; set; }
    public DbSet<RecipeStepModel> RecipeSteps { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=recipes;Username=postgres;Password=password");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Soft delete: фільтр на IsDeleted, щоб видалені записи не потрапляли в запити
        modelBuilder.Entity<RecipeModel>().HasQueryFilter(r => !r.IsDeleted);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.Entity is ITrackable trackableEntity)
            {
                if (entry.State == EntityState.Added)
                {
                    trackableEntity.CreatedAt = DateTime.UtcNow;
                    trackableEntity.ModifiedAt = DateTime.UtcNow;
                }
                else if (entry.State == EntityState.Modified)
                {
                    trackableEntity.ModifiedAt = DateTime.UtcNow;
                }
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}
