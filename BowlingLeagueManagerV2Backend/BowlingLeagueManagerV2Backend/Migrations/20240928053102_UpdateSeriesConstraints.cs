using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BowlingLeagueManagerV2Backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeriesConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop the existing CHECK constraint if it exists
            migrationBuilder.DropCheckConstraint(
                name: "CK_Series_Game1",
                table: "Series");
            migrationBuilder.DropCheckConstraint(
                name: "CK_Series_Game2",
                table: "Series");
            migrationBuilder.DropCheckConstraint(
                name: "CK_Series_Game3",
                table: "Series");

            // Add a new CHECK constraint with updated conditions
            migrationBuilder.CreateCheckConstraint(
                name: "CK_Series_Game1",
                table: "Series",
                sql: "Game1 >= 0 AND Game1 <= 300"); // Example of new constraints
            migrationBuilder.CreateCheckConstraint(
                name: "CK_Series_Game2",
                table: "Series",
                sql: "Game2 >= 0 AND Game2 <= 300");
            migrationBuilder.CreateCheckConstraint(
                name: "CK_Series_Game3",
                table: "Series",
                sql: "Game3 >= 0 AND Game3 <= 300");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
