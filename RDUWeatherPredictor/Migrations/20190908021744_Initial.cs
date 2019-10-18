using Microsoft.EntityFrameworkCore.Migrations;

namespace RDUWeatherPredictor.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailyNormals",
                columns: table => new
                {
                    JulianDay = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Month = table.Column<string>(nullable: true),
                    DayOfMonth = table.Column<int>(nullable: false),
                    NormalMaxTempF = table.Column<float>(nullable: false),
                    NormalMinTempF = table.Column<float>(nullable: false),
                    NormalPrecipitation = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyNormals", x => x.JulianDay);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyNormals");
        }
    }
}
