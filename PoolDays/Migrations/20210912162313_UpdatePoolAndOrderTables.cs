using Microsoft.EntityFrameworkCore.Migrations;

namespace PoolDays.Migrations
{
    public partial class UpdatePoolAndOrderTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Pools");

            migrationBuilder.DropColumn(
                name: "JacuzziId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "PoolId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PoolId",
                table: "Orders",
                column: "PoolId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Pools_PoolId",
                table: "Orders",
                column: "PoolId",
                principalTable: "Pools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Pools_PoolId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PoolId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Pools",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PoolId",
                table: "Comments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "JacuzziId",
                table: "Comments",
                type: "int",
                nullable: true);
        }
    }
}
