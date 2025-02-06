using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BowlingLeagueManagerV2Backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeriesConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop the existing CHECK constraint if it exists
            migrationBuilder.DropCheckConstraint(
                name: "CK_Series_SeriesTotal",
                table: "Series");

            // Add a new CHECK constraint with updated conditions
            migrationBuilder.CreateCheckConstraint(
                name: "CK_Series_SeriesTotal",
                table: "Series",
                sql: "SeriesTotal = Game1 + Game2 + Game3");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
