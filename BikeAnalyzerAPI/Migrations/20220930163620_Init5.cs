using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeAnalyzerAPI.Migrations
{
    public partial class Init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RimWidth",
                table: "Bikes");

            migrationBuilder.AlterColumn<double>(
                name: "Weigth",
                table: "Bikes",
                type: "float",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<int>(
                name: "TravelFrontWheel",
                table: "Bikes",
                type: "int",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<int>(
                name: "TravelBackWheel",
                table: "Bikes",
                type: "int",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<double>(
                name: "TireWidth",
                table: "Bikes",
                type: "float",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<double>(
                name: "SeatTubeEffectiveAngle",
                table: "Bikes",
                type: "float",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<double>(
                name: "HeadTubeAngle",
                table: "Bikes",
                type: "float",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<double>(
                name: "InnerRimWidth",
                table: "Bikes",
                type: "float",
                maxLength: 20,
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InnerRimWidth",
                table: "Bikes");

            migrationBuilder.AlterColumn<decimal>(
                name: "Weigth",
                table: "Bikes",
                type: "decimal(18,2)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<decimal>(
                name: "TravelFrontWheel",
                table: "Bikes",
                type: "decimal(18,2)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<decimal>(
                name: "TravelBackWheel",
                table: "Bikes",
                type: "decimal(18,2)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<decimal>(
                name: "TireWidth",
                table: "Bikes",
                type: "decimal(18,2)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<decimal>(
                name: "SeatTubeEffectiveAngle",
                table: "Bikes",
                type: "decimal(18,2)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<decimal>(
                name: "HeadTubeAngle",
                table: "Bikes",
                type: "decimal(18,2)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<decimal>(
                name: "RimWidth",
                table: "Bikes",
                type: "decimal(18,2)",
                maxLength: 20,
                nullable: false,
                defaultValue: 0m);
        }
    }
}
