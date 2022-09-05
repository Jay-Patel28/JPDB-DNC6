using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JPDB.Migrations
{
    public partial class dfgdswd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Crypto_CryptoId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "CryptoId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Crypto_CryptoId",
                table: "Users",
                column: "CryptoId",
                principalTable: "Crypto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Crypto_CryptoId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "CryptoId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Crypto_CryptoId",
                table: "Users",
                column: "CryptoId",
                principalTable: "Crypto",
                principalColumn: "Id");
        }
    }
}
