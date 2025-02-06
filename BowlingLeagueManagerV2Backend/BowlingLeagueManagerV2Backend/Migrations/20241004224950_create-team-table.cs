using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BowlingLeagueManagerV2Backend.Migrations
{
    /// <inheritdoc />
    public partial class createteamtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeagueId = table.Column<long>(type: "bigint", nullable: false),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PointsWon = table.Column<int>(type: "int", nullable: false),
                    PointsLost = table.Column<int>(type: "int", nullable: false),
                    TeamAverage = table.Column<int>(type: "int", nullable: false),
                    TeamHandicap = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
