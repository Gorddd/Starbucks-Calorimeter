using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Starbucks_Calorimeter.Migrations
{
    public partial class null_espressoid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drinks_Espressoes_EspressoId",
                table: "Drinks");

            migrationBuilder.AlterColumn<int>(
                name: "EspressoId",
                table: "Drinks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Drinks_Espressoes_EspressoId",
                table: "Drinks",
                column: "EspressoId",
                principalTable: "Espressoes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drinks_Espressoes_EspressoId",
                table: "Drinks");

            migrationBuilder.AlterColumn<int>(
                name: "EspressoId",
                table: "Drinks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Drinks_Espressoes_EspressoId",
                table: "Drinks",
                column: "EspressoId",
                principalTable: "Espressoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
