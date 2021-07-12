using Microsoft.EntityFrameworkCore.Migrations;

namespace donet_rpg.Migrations
{
    public partial class UpdatedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Class",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "InventoryLegID",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "InventoryLegKey",
                table: "Flights");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Class",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InventoryLegID",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "InventoryLegKey",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
