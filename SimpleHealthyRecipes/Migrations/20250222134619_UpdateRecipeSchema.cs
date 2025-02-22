using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SimpleHealthyRecipes.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRecipeSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryRecipe");

            migrationBuilder.DropTable(
                name: "RecipeTag");

            migrationBuilder.DropColumn(
                name: "IsEggFree",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "IsFreezable",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "IsHealthy",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "IsLowCalorie",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "IsVegetarian",
                table: "Recipes");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Recipes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "CuisineId",
                table: "Recipes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Difficulty",
                table: "Recipes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MovieReferenceId",
                table: "Recipes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                table: "Recipes",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CategoryModelRecipeModel",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "integer", nullable: false),
                    RecipesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryModelRecipeModel", x => new { x.CategoriesId, x.RecipesId });
                    table.ForeignKey(
                        name: "FK_CategoryModelRecipeModel_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryModelRecipeModel_Recipes_RecipesId",
                        column: x => x.RecipesId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cuisines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuisines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieReferences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieReferences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipeModelTagModel",
                columns: table => new
                {
                    RecipesId = table.Column<int>(type: "integer", nullable: false),
                    TagsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeModelTagModel", x => new { x.RecipesId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_RecipeModelTagModel_Recipes_RecipesId",
                        column: x => x.RecipesId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeModelTagModel_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeSteps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StepNumber = table.Column<int>(type: "integer", nullable: false),
                    Instruction = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    RecipeId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeSteps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeSteps_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CuisineId",
                table: "Recipes",
                column: "CuisineId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_MovieReferenceId",
                table: "Recipes",
                column: "MovieReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryModelRecipeModel_RecipesId",
                table: "CategoryModelRecipeModel",
                column: "RecipesId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeModelTagModel_TagsId",
                table: "RecipeModelTagModel",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeSteps_RecipeId",
                table: "RecipeSteps",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Cuisines_CuisineId",
                table: "Recipes",
                column: "CuisineId",
                principalTable: "Cuisines",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_MovieReferences_MovieReferenceId",
                table: "Recipes",
                column: "MovieReferenceId",
                principalTable: "MovieReferences",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Cuisines_CuisineId",
                table: "Recipes");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_MovieReferences_MovieReferenceId",
                table: "Recipes");

            migrationBuilder.DropTable(
                name: "CategoryModelRecipeModel");

            migrationBuilder.DropTable(
                name: "Cuisines");

            migrationBuilder.DropTable(
                name: "MovieReferences");

            migrationBuilder.DropTable(
                name: "RecipeModelTagModel");

            migrationBuilder.DropTable(
                name: "RecipeSteps");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_CuisineId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_MovieReferenceId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "CuisineId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Difficulty",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "MovieReferenceId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "VideoUrl",
                table: "Recipes");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Recipes",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsEggFree",
                table: "Recipes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsFreezable",
                table: "Recipes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHealthy",
                table: "Recipes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLowCalorie",
                table: "Recipes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVegetarian",
                table: "Recipes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "CategoryRecipe",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "integer", nullable: false),
                    RecipesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryRecipe", x => new { x.CategoriesId, x.RecipesId });
                    table.ForeignKey(
                        name: "FK_CategoryRecipe_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryRecipe_Recipes_RecipesId",
                        column: x => x.RecipesId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeTag",
                columns: table => new
                {
                    RecipesId = table.Column<int>(type: "integer", nullable: false),
                    TagsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeTag", x => new { x.RecipesId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_RecipeTag_Recipes_RecipesId",
                        column: x => x.RecipesId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryRecipe_RecipesId",
                table: "CategoryRecipe",
                column: "RecipesId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeTag_TagsId",
                table: "RecipeTag",
                column: "TagsId");
        }
    }
}
