using Microsoft.EntityFrameworkCore.Migrations;

namespace PoolDays.Migrations
{
    public partial class FixDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jacuzzis_Categories_CategoryId",
                table: "Jacuzzis");

            migrationBuilder.AddForeignKey(
                name: "FK_Jacuzzis_Categories_CategoryId",
                table: "Jacuzzis",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jacuzzis_Categories_CategoryId",
                table: "Jacuzzis");

            migrationBuilder.AddForeignKey(
                name: "FK_Jacuzzis_Categories_CategoryId",
                table: "Jacuzzis",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
