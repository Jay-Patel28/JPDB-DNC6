using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JPDB.Migrations
{
    public partial class InitialCar12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerName = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarOwners_OwnerId",
                table: "CarOwners",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarOwners_Car_CarId",
                table: "CarOwners",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarOwners_Owner_OwnerId",
                table: "CarOwners",
                column: "OwnerId",
                principalTable: "Owner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarOwners_Car_CarId",
                table: "CarOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_CarOwners_Owner_OwnerId",
                table: "CarOwners");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Owner");

            migrationBuilder.DropIndex(
                name: "IX_CarOwners_OwnerId",
                table: "CarOwners");
        }
    }
}
