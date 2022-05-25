using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Starbucks_Calorimeter.Migrations
{
    public partial class desc_desserts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descriptions",
                table: "Desserts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descriptions",
                table: "Desserts");
        }
    }
}
