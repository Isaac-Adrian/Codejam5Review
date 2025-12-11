using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeJam5b.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "meals",
                columns: table => new
                {
                    meal_id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    calories = table.Column<int>(type: "integer", nullable: false),
                    carbs = table.Column<int>(type: "integer", nullable: false),
                    fat = table.Column<int>(type: "integer", nullable: false),
                    protein = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_meals", x => x.meal_id);
                });

            migrationBuilder.CreateTable(
                name: "progress",
                columns: table => new
                {
                    progress_id = table.Column<string>(type: "text", nullable: false),
                    current_weight = table.Column<int>(type: "integer", nullable: false),
                    target_weight = table.Column<int>(type: "integer", nullable: false),
                    target_cals = table.Column<int>(type: "integer", nullable: false),
                    target_carbs = table.Column<int>(type: "integer", nullable: false),
                    target_fat = table.Column<int>(type: "integer", nullable: false),
                    target_protein = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_progress", x => x.progress_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "meals");

            migrationBuilder.DropTable(
                name: "progress");
        }
    }
}
