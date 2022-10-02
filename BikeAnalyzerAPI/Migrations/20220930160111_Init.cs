using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeAnalyzerAPI.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bikes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    YearOfProduction = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    HeadTubeAngle = table.Column<decimal>(type: "decimal(18,2)", maxLength: 20, nullable: false),
                    SeatTubeEffectiveAngle = table.Column<decimal>(type: "decimal(18,2)", maxLength: 20, nullable: false),
                    TravelFrontWheel = table.Column<decimal>(type: "decimal(18,2)", maxLength: 20, nullable: false),
                    TravelBackWheel = table.Column<decimal>(type: "decimal(18,2)", maxLength: 20, nullable: false),
                    RimWidth = table.Column<decimal>(type: "decimal(18,2)", maxLength: 20, nullable: false),
                    TireWidth = table.Column<decimal>(type: "decimal(18,2)", maxLength: 20, nullable: false),
                    Weigth = table.Column<decimal>(type: "decimal(18,2)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bikes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bikes");
        }
    }
}
