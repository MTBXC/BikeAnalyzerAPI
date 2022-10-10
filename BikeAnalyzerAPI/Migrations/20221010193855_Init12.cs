using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeAnalyzerAPI.Migrations
{
    public partial class Init12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "GeneralBikeRate",
                table: "Bikes",
                type: "float",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GeneralBikeRate",
                table: "Bikes");
        }
    }
}
