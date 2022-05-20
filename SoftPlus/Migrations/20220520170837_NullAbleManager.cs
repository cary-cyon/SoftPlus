using Microsoft.EntityFrameworkCore.Migrations;

namespace SoftPlus.Migrations
{
    public partial class NullAbleManager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Managers_ManagerId",
                table: "Clients");

            migrationBuilder.AlterColumn<int>(
                name: "ManagerId",
                table: "Clients",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Managers_ManagerId",
                table: "Clients",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Managers_ManagerId",
                table: "Clients");

            migrationBuilder.AlterColumn<int>(
                name: "ManagerId",
                table: "Clients",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Managers_ManagerId",
                table: "Clients",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
