using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SimpleHealthyRecipes.Migrations
{
    /// <inheritdoc />
    public partial class SeedCuisinesAndCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 24, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 24, 0, 0, 0, 0, DateTimeKind.Utc), "Breakfast" },
                    { 2, new DateTime(2024, 2, 24, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 24, 0, 0, 0, 0, DateTimeKind.Utc), "Lunch" },
                    { 3, new DateTime(2024, 2, 24, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 24, 0, 0, 0, 0, DateTimeKind.Utc), "Dinner" },
                    { 4, new DateTime(2024, 2, 24, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 24, 0, 0, 0, 0, DateTimeKind.Utc), "Desserts" },
                    { 5, new DateTime(2024, 2, 24, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 24, 0, 0, 0, 0, DateTimeKind.Utc), "Drinks" }
                });

            migrationBuilder.InsertData(
                table: "Cuisines",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 24, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 24, 0, 0, 0, 0, DateTimeKind.Utc), "Italian" },
                    { 2, new DateTime(2024, 2, 24, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 24, 0, 0, 0, 0, DateTimeKind.Utc), "French" },
                    { 3, new DateTime(2024, 2, 24, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 24, 0, 0, 0, 0, DateTimeKind.Utc), "Japanese" },
                    { 4, new DateTime(2024, 2, 24, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 24, 0, 0, 0, 0, DateTimeKind.Utc), "Ukrainian" },
                    { 5, new DateTime(2024, 2, 24, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 24, 0, 0, 0, 0, DateTimeKind.Utc), "Mexican" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
