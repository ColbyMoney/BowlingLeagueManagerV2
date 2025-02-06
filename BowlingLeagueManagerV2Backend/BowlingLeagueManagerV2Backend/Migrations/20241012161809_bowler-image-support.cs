using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BowlingLeagueManagerV2Backend.Migrations
{
    /// <inheritdoc />
    public partial class bowlerimagesupport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BowlerImage",
                table: "Bowlers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BowlerImageAltText",
                table: "Bowlers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeagueDetailsDto");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Bowlers");

            migrationBuilder.DropColumn(
                name: "ImageAltText",
                table: "Bowlers");
        }
    }
}
