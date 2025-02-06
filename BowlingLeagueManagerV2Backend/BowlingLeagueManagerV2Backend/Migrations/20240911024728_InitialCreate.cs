using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BowlingLeagueManagerV2Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bowlers");
        }
    }
}
