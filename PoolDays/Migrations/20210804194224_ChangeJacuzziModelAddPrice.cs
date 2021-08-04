using Microsoft.EntityFrameworkCore.Migrations;

namespace PoolDays.Migrations
{
    public partial class ChangeJacuzziModelAddPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Diameter",
                table: "Jacuzzies");

            migrationBuilder.DropColumn(
                name: "PumpIncluded",
                table: "Jacuzzies");

            migrationBuilder.DropColumn(
                name: "Stairway",
                table: "Jacuzzies");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Jacuzzies",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Jacuzzies");

            migrationBuilder.AddColumn<double>(
                name: "Diameter",
                table: "Jacuzzies",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PumpIncluded",
                table: "Jacuzzies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Stairway",
                table: "Jacuzzies",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
