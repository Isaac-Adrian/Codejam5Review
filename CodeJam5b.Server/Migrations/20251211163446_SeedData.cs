using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CodeJam5b.Server.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "meals",
                columns: new[] { "meal_id", "calories", "carbs", "fat", "name", "protein" },
                values: new object[,]
                {
                    { "1", 350, 10, 15, "Chicken Salad", 40 },
                    { "2", 450, 5, 25, "Grilled Salmon", 50 },
                    { "3", 300, 50, 10, "Veggie Stir Fry", 15 }
                });

            migrationBuilder.InsertData(
                table: "progress",
                columns: new[] { "progress_id", "current_weight", "target_cals", "target_carbs", "target_fat", "target_protein", "target_weight" },
                values: new object[] { "1", 180, 2000, 250, 80, 160, 160 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "meals",
                keyColumn: "meal_id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "meals",
                keyColumn: "meal_id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "meals",
                keyColumn: "meal_id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "progress",
                keyColumn: "progress_id",
                keyValue: "1");
        }
    }
}
