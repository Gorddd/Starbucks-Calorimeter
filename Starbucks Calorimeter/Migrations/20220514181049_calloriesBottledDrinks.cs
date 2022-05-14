using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Starbucks_Calorimeter.Migrations
{
    public partial class calloriesBottledDrinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Calories",
                table: "BottledDrinks",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Carbohidrates",
                table: "BottledDrinks",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Fats",
                table: "BottledDrinks",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Proteins",
                table: "BottledDrinks",
                type: "float",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Calories",
                table: "BottledDrinks");

            migrationBuilder.DropColumn(
                name: "Carbohidrates",
                table: "BottledDrinks");

            migrationBuilder.DropColumn(
                name: "Fats",
                table: "BottledDrinks");

            migrationBuilder.DropColumn(
                name: "Proteins",
                table: "BottledDrinks");
        }
    }
}
