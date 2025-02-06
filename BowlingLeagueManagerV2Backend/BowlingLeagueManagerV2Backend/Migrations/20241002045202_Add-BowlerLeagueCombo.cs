using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BowlingLeagueManagerV2Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddBowlerLeagueCombo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Average",
                table: "Bowlers");

            migrationBuilder.DropColumn(
                name: "HighestGame",
                table: "Bowlers");

            migrationBuilder.DropColumn(
                name: "HighestSeries",
                table: "Bowlers");

            migrationBuilder.DropColumn(
                name: "TotalGamesBowled",
                table: "Bowlers");

            migrationBuilder.DropColumn(
                name: "TotalPins",
                table: "Bowlers");

            migrationBuilder.CreateTable(
                name: "BowlerLeagueCombos",
                columns: table => new
                {
                    BowlerLeagueComboId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BowlerId = table.Column<long>(type: "bigint", nullable: false),
                    LeagueId = table.Column<long>(type: "bigint", nullable: false),
                    TeamId = table.Column<long>(type: "bigint", nullable: false),
                    TotalPins = table.Column<int>(type: "int", nullable: false),
                    TotalGamesBowled = table.Column<int>(type: "int", nullable: false),
                    Average = table.Column<int>(type: "int", nullable: false),
                    HighestGame = table.Column<int>(type: "int", nullable: false),
                    HighestSeries = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BowlerLeagueCombos", x => x.BowlerLeagueComboId);
                    table.UniqueConstraint("AK_BowlerLeaugeCombo_BowlerId_LeagueId", x => new { x.BowlerId, x.LeagueId });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BowlerLeagueCombos");

            migrationBuilder.AddColumn<int>(
                name: "Average",
                table: "Bowlers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HighestGame",
                table: "Bowlers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HighestSeries",
                table: "Bowlers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalGamesBowled",
                table: "Bowlers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalPins",
                table: "Bowlers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
