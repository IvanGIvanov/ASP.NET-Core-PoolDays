using Microsoft.EntityFrameworkCore.Migrations;

namespace PoolDays.Migrations
{
    public partial class AddJacuzziInDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jacuzzies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Manufacturer = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false),
                    Volume = table.Column<double>(type: "float", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    Length = table.Column<double>(type: "float", nullable: false),
                    Width = table.Column<double>(type: "float", nullable: false),
                    Diameter = table.Column<double>(type: "float", nullable: true),
                    PumpIncluded = table.Column<bool>(type: "bit", nullable: false),
                    Stairway = table.Column<bool>(type: "bit", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jacuzzies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jacuzzies_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jacuzzies_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jacuzzies_CategoryId",
                table: "Jacuzzies",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Jacuzzies_EmployeeId",
                table: "Jacuzzies",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jacuzzies");
        }
    }
}
