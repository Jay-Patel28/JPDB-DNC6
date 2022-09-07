using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JPDB.Migrations
{
    public partial class InitialCar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarOwners",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarOwners", x => new { x.CarId, x.OwnerId });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarOwners");
        }
    }
}
