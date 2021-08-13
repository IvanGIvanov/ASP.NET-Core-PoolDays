using Microsoft.EntityFrameworkCore.Migrations;

namespace PoolDays.Migrations
{
    public partial class UpdateJacuzzi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentJacuzzi_Jacuzzies_JacuzzisId",
                table: "CommentJacuzzi");

            migrationBuilder.DropForeignKey(
                name: "FK_Jacuzzies_Categories_CategoryId",
                table: "Jacuzzies");

            migrationBuilder.DropForeignKey(
                name: "FK_Jacuzzies_Employees_EmployeeId",
                table: "Jacuzzies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Jacuzzies",
                table: "Jacuzzies");

            migrationBuilder.RenameTable(
                name: "Jacuzzies",
                newName: "Jacuzzis");

            migrationBuilder.RenameIndex(
                name: "IX_Jacuzzies_EmployeeId",
                table: "Jacuzzis",
                newName: "IX_Jacuzzis_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Jacuzzies_CategoryId",
                table: "Jacuzzis",
                newName: "IX_Jacuzzis_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Jacuzzis",
                table: "Jacuzzis",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentJacuzzi_Jacuzzis_JacuzzisId",
                table: "CommentJacuzzi",
                column: "JacuzzisId",
                principalTable: "Jacuzzis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jacuzzis_Categories_CategoryId",
                table: "Jacuzzis",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jacuzzis_Employees_EmployeeId",
                table: "Jacuzzis",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentJacuzzi_Jacuzzis_JacuzzisId",
                table: "CommentJacuzzi");

            migrationBuilder.DropForeignKey(
                name: "FK_Jacuzzis_Categories_CategoryId",
                table: "Jacuzzis");

            migrationBuilder.DropForeignKey(
                name: "FK_Jacuzzis_Employees_EmployeeId",
                table: "Jacuzzis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Jacuzzis",
                table: "Jacuzzis");

            migrationBuilder.RenameTable(
                name: "Jacuzzis",
                newName: "Jacuzzies");

            migrationBuilder.RenameIndex(
                name: "IX_Jacuzzis_EmployeeId",
                table: "Jacuzzies",
                newName: "IX_Jacuzzies_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Jacuzzis_CategoryId",
                table: "Jacuzzies",
                newName: "IX_Jacuzzies_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Jacuzzies",
                table: "Jacuzzies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentJacuzzi_Jacuzzies_JacuzzisId",
                table: "CommentJacuzzi",
                column: "JacuzzisId",
                principalTable: "Jacuzzies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jacuzzies_Categories_CategoryId",
                table: "Jacuzzies",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jacuzzies_Employees_EmployeeId",
                table: "Jacuzzies",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
