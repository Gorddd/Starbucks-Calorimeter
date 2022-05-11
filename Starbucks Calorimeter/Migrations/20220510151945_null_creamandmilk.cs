using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Starbucks_Calorimeter.Migrations
{
    public partial class null_creamandmilk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drinks_Creams_CreamId",
                table: "Drinks");

            migrationBuilder.DropForeignKey(
                name: "FK_Drinks_Milks_MilkId",
                table: "Drinks");

            migrationBuilder.AlterColumn<int>(
                name: "MilkId",
                table: "Drinks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CreamId",
                table: "Drinks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Drinks_Creams_CreamId",
                table: "Drinks",
                column: "CreamId",
                principalTable: "Creams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Drinks_Milks_MilkId",
                table: "Drinks",
                column: "MilkId",
                principalTable: "Milks",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drinks_Creams_CreamId",
                table: "Drinks");

            migrationBuilder.DropForeignKey(
                name: "FK_Drinks_Milks_MilkId",
                table: "Drinks");

            migrationBuilder.AlterColumn<int>(
                name: "MilkId",
                table: "Drinks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreamId",
                table: "Drinks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Drinks_Creams_CreamId",
                table: "Drinks",
                column: "CreamId",
                principalTable: "Creams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Drinks_Milks_MilkId",
                table: "Drinks",
                column: "MilkId",
                principalTable: "Milks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
