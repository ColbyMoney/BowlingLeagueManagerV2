using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BowlingLeagueManagerV2Backend.Migrations
{
    /// <inheritdoc />
    public partial class RecreateBowlersAndSeriesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bowlers",
                columns: table => new
                {
                    BowlerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalPins = table.Column<int>(type: "int", nullable: false),
                    TotalGamesBowled = table.Column<int>(type: "int", nullable: false),
                    Average = table.Column<int>(type: "int", nullable: false),
                    HighestGame = table.Column<int>(type: "int", nullable: false),
                    HighestSeries = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bowlers", x => x.BowlerId);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    SeriesId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BowlerId = table.Column<long>(type: "bigint", nullable: false),
                    WeekId = table.Column<long>(type: "bigint", nullable: false),
                    LeagueId = table.Column<long>(type: "bigint", nullable: false),
                    Game1 = table.Column<int>(type: "int", nullable: false),
                    Game2 = table.Column<int>(type: "int", nullable: false),
                    Game3 = table.Column<int>(type: "int", nullable: false),
                    SeriesTotal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.SeriesId);
                    table.UniqueConstraint("AK_Series_BowlerId_WeekId_LeagueId", x => new { x.BowlerId, x.WeekId, x.LeagueId }); // Unique constraint
                    table.CheckConstraint("CK_Series_Game1", "Game1 >= 0 AND SeriesTotal <= 300");
                    table.CheckConstraint("CK_Series_Game2", "Game2 >= 0 AND SeriesTotal <= 300");
                    table.CheckConstraint("CK_Series_Game3", "Game3 >= 0 AND SeriesTotal <= 300");
                    table.CheckConstraint("CK_Series_SeriesTotal", "SeriesTotal >= 0 AND SeriesTotal <= 900");
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Series");

            migrationBuilder.DropTable(
                name: "Bowlers");
        }
    }
}
