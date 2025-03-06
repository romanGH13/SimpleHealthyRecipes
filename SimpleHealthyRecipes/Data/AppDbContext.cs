using Microsoft.EntityFrameworkCore;
using SimpleHealthyRecipes.Models;
using SimpleHealthyRecipes.Models.Base;

namespace SimpleHealthyRecipes.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<RecipeModel> Recipes { get; set; }
    public DbSet<IngredientModel> Ingredients { get; set; }
    public DbSet<RecipeIngredientModel> RecipeIngredients { get; set; }
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

        var createdAt = new DateTime(2024, 2, 24, 0, 0, 0, DateTimeKind.Utc);
        var modifiedAt = createdAt;

        // Seed data for Cuisine
        modelBuilder.Entity<CuisineModel>().HasData(
            new CuisineModel { Id = 1, Name = "Italian", CreatedAt = createdAt, ModifiedAt = modifiedAt },
            new CuisineModel { Id = 2, Name = "French", CreatedAt = createdAt, ModifiedAt = modifiedAt },
            new CuisineModel { Id = 3, Name = "Japanese", CreatedAt = createdAt, ModifiedAt = modifiedAt },
            new CuisineModel { Id = 4, Name = "Ukrainian", CreatedAt = createdAt, ModifiedAt = modifiedAt },
            new CuisineModel { Id = 5, Name = "Mexican", CreatedAt = createdAt, ModifiedAt = modifiedAt }
        );

        // Seed data for Category
        modelBuilder.Entity<CategoryModel>().HasData(
            new CategoryModel { Id = 1, Name = "Breakfast", CreatedAt = createdAt, ModifiedAt = modifiedAt },
            new CategoryModel { Id = 2, Name = "Lunch", CreatedAt = createdAt, ModifiedAt = modifiedAt },
            new CategoryModel { Id = 3, Name = "Dinner", CreatedAt = createdAt, ModifiedAt = modifiedAt },
            new CategoryModel { Id = 4, Name = "Desserts", CreatedAt = createdAt, ModifiedAt = modifiedAt },
            new CategoryModel { Id = 5, Name = "Drinks", CreatedAt = createdAt, ModifiedAt = modifiedAt }
        );
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
