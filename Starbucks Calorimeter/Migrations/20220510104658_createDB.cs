using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Starbucks_Calorimeter.Migrations
{
    public partial class createDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BottledDrinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Volume = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BottledDrinks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Creams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Proteins = table.Column<double>(type: "float", nullable: true),
                    Fats = table.Column<double>(type: "float", nullable: true),
                    Carbohidrates = table.Column<double>(type: "float", nullable: true),
                    Calories = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Desserts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<double>(type: "float", nullable: true),
                    Proteins = table.Column<double>(type: "float", nullable: true),
                    Fats = table.Column<double>(type: "float", nullable: true),
                    Carbohidrates = table.Column<double>(type: "float", nullable: true),
                    Calories = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desserts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Espressoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Proteins = table.Column<double>(type: "float", nullable: true),
                    Fats = table.Column<double>(type: "float", nullable: true),
                    Carbohidrates = table.Column<double>(type: "float", nullable: true),
                    Calories = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Espressoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodInPackages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<double>(type: "float", nullable: true),
                    Proteins = table.Column<double>(type: "float", nullable: true),
                    Fats = table.Column<double>(type: "float", nullable: true),
                    Carbohidrates = table.Column<double>(type: "float", nullable: true),
                    Calories = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodInPackages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LunchAndBreakfasts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Volume = table.Column<int>(type: "int", nullable: true),
                    Proteins = table.Column<double>(type: "float", nullable: true),
                    Fats = table.Column<double>(type: "float", nullable: true),
                    Carbohidrates = table.Column<double>(type: "float", nullable: true),
                    Calories = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LunchAndBreakfasts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Milks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Volume = table.Column<int>(type: "int", nullable: true),
                    Proteins = table.Column<double>(type: "float", nullable: true),
                    Fats = table.Column<double>(type: "float", nullable: true),
                    Carbohidrates = table.Column<double>(type: "float", nullable: true),
                    Calories = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Milks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pastry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<double>(type: "float", nullable: true),
                    Proteins = table.Column<double>(type: "float", nullable: true),
                    Fats = table.Column<double>(type: "float", nullable: true),
                    Carbohidrates = table.Column<double>(type: "float", nullable: true),
                    Calories = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pastry", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Volume = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Syrops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Proteins = table.Column<double>(type: "float", nullable: true),
                    Fats = table.Column<double>(type: "float", nullable: true),
                    Carbohidrates = table.Column<double>(type: "float", nullable: true),
                    Calories = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Syrops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SizeId = table.Column<int>(type: "int", nullable: false),
                    EspressoId = table.Column<int>(type: "int", nullable: false),
                    MilkId = table.Column<int>(type: "int", nullable: false),
                    CreamId = table.Column<int>(type: "int", nullable: false),
                    Proteins = table.Column<double>(type: "float", nullable: true),
                    Fats = table.Column<double>(type: "float", nullable: true),
                    Carbohidrates = table.Column<double>(type: "float", nullable: true),
                    Coffeine = table.Column<double>(type: "float", nullable: true),
                    Calories = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drinks_Creams_CreamId",
                        column: x => x.CreamId,
                        principalTable: "Creams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Drinks_Espressoes_EspressoId",
                        column: x => x.EspressoId,
                        principalTable: "Espressoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Drinks_Milks_MilkId",
                        column: x => x.MilkId,
                        principalTable: "Milks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Drinks_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drinks_CreamId",
                table: "Drinks",
                column: "CreamId");

            migrationBuilder.CreateIndex(
                name: "IX_Drinks_EspressoId",
                table: "Drinks",
                column: "EspressoId");

            migrationBuilder.CreateIndex(
                name: "IX_Drinks_MilkId",
                table: "Drinks",
                column: "MilkId");

            migrationBuilder.CreateIndex(
                name: "IX_Drinks_SizeId",
                table: "Drinks",
                column: "SizeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BottledDrinks");

            migrationBuilder.DropTable(
                name: "Desserts");

            migrationBuilder.DropTable(
                name: "Drinks");

            migrationBuilder.DropTable(
                name: "FoodInPackages");

            migrationBuilder.DropTable(
                name: "LunchAndBreakfasts");

            migrationBuilder.DropTable(
                name: "Pastry");

            migrationBuilder.DropTable(
                name: "Syrops");

            migrationBuilder.DropTable(
                name: "Creams");

            migrationBuilder.DropTable(
                name: "Espressoes");

            migrationBuilder.DropTable(
                name: "Milks");

            migrationBuilder.DropTable(
                name: "Sizes");
        }
    }
}
