using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GongChaWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class ProductTypeSize1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductTypeSize",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: false),
                    SugarAmount = table.Column<double>(type: "float", nullable: false),
                    CaffeinAmount = table.Column<double>(type: "float", nullable: false),
                    CalloriesSugarAmount = table.Column<double>(type: "float", nullable: false),
                    CalloriesNoSugarAmount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypeSize", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductTypeSize");
        }
    }
}
