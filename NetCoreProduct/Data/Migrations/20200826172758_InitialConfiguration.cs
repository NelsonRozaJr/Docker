using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace NetCoreProduct.Data.Migrations
{
    public partial class InitialConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Category", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Category 01", "Product 01", 10m },
                    { 2, "Category 02", "Product 02", 15m },
                    { 3, "Category 03", "Product 03", 13m },
                    { 4, "Category 04", "Product 04", 11m },
                    { 5, "Category 01", "Product 05", 19m },
                    { 6, "Category 03", "Product 06", 15m },
                    { 7, "Category 02", "Product 07", 16m },
                    { 8, "Category 02", "Product 08", 19m },
                    { 9, "Category 01", "Product 09", 20m },
                    { 10, "Category 01", "Product 10", 14m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
