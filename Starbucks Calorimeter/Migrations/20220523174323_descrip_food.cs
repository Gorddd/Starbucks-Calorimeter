using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Starbucks_Calorimeter.Migrations
{
    public partial class descrip_food : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Pastries",
                table: "Pastries");

            migrationBuilder.RenameTable(
                name: "Pastries",
                newName: "Pastries");

            migrationBuilder.AddColumn<string>(
                name: "Descriptions",
                table: "LunchAndBreakfasts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descriptions",
                table: "FoodInPackages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descriptions",
                table: "Pastries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pastries",
                table: "Pastries",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Pastries",
                table: "Pastries");

            migrationBuilder.DropColumn(
                name: "Descriptions",
                table: "LunchAndBreakfasts");

            migrationBuilder.DropColumn(
                name: "Descriptions",
                table: "FoodInPackages");

            migrationBuilder.DropColumn(
                name: "Descriptions",
                table: "Pastries");

            migrationBuilder.RenameTable(
                name: "Pastries",
                newName: "Pastries");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pastries",
                table: "Pastries",
                column: "Id");
        }
    }
}
