using Microsoft.EntityFrameworkCore.Migrations;

namespace BowlingLeagueManagerV2Backend.Migrations
{
    public partial class AddSeries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    SeriesId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BowlerId = table.Column<long>(nullable: false),
                    WeekId = table.Column<long>(nullable: false),
                    LeagueId = table.Column<long>(nullable: false),
                    Game1 = table.Column<int>(nullable: false, defaultValue: 0),
                    Game2 = table.Column<int>(nullable: false, defaultValue: 0),
                    Game3 = table.Column<int>(nullable: false, defaultValue: 0),
                    SeriesTotal = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.SeriesId);
                    table.UniqueConstraint("AK_Series_BowlerId_WeekId", x => new { x.BowlerId, x.WeekId }); // Unique constraint
                });

            // Optionally, you might want to add foreign key constraints
            // migrationBuilder.AddForeignKey(
            //     name: "FK_Series_Bowlers_BowlerId",
            //     table: "Series",
            //     column: "BowlerId",
            //     principalTable: "Bowlers",
            //     principalColumn: "BowlerId",
            //     onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Series");
        }
    }
}
