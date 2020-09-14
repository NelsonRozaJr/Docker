using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace ApiNetCore.Infrastructure.Migrations
{
    public partial class InitialConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CatalogBrand",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Brand = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogBrand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Catalog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    PictureFileName = table.Column<string>(nullable: true),
                    CatalogTypeId = table.Column<int>(nullable: false),
                    CatalogBrandId = table.Column<int>(nullable: false),
                    AvailableStock = table.Column<int>(nullable: false),
                    RestockThreshold = table.Column<int>(nullable: false),
                    MaxStockThreshold = table.Column<int>(nullable: false),
                    OnReorder = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catalog_CatalogBrand_CatalogBrandId",
                        column: x => x.CatalogBrandId,
                        principalTable: "CatalogBrand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Catalog_CatalogType_CatalogTypeId",
                        column: x => x.CatalogTypeId,
                        principalTable: "CatalogType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CatalogBrand",
                columns: new[] { "Id", "Brand" },
                values: new object[,]
                {
                    { 1, "CatalogBrand" },
                    { 2, "Azure" },
                    { 3, ".NET" },
                    { 4, "Visual Studio" },
                    { 5, "SQL Server" },
                    { 6, "Other" },
                    { 7, "CatalogBrandTestOne" },
                    { 8, "CatalogBrandTestTwo" }
                });

            migrationBuilder.InsertData(
                table: "CatalogType",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "CatalogType" },
                    { 2, "Mug" },
                    { 3, "T-Shirt" },
                    { 4, "Sheet" },
                    { 5, "USB Memory Stick" },
                    { 6, "CatalogTypeTestOne" },
                    { 7, "CatalogTypeTestTwo" }
                });

            migrationBuilder.InsertData(
                table: "Catalog",
                columns: new[] { "Id", "AvailableStock", "CatalogBrandId", "CatalogTypeId", "Description", "MaxStockThreshold", "Name", "OnReorder", "PictureFileName", "Price", "RestockThreshold" },
                values: new object[,]
                {
                    { 2, 89, 3, 2, ".NET Black & White Mug", 0, ".NET Black & White Mug", true, "2.png", 8.50m, 0 },
                    { 9, 76, 6, 2, "Cup<T> White Mug", 0, "Cup<T> White Mug", false, "9.png", 12m, 0 },
                    { 13, 0, 6, 2, "De los Palotes", 0, "pepito", false, "13.png", 12m, 0 },
                    { 1, 100, 3, 3, ".NET Bot Black Hoodie, and more", 0, ".NET Bot Black Hoodie", false, "1.png", 19.5m, 0 },
                    { 3, 56, 6, 3, "Prism White T-Shirt", 0, "Prism White T-Shirt", false, "3.png", 12m, 0 },
                    { 4, 120, 3, 3, ".NET Foundation T-shirt", 0, ".NET Foundation T-shirt", false, "4.png", 12m, 0 },
                    { 6, 17, 3, 3, ".NET Blue Hoodie", 0, ".NET Blue Hoodie", false, "6.png", 12m, 0 },
                    { 7, 8, 6, 3, "Roslyn Red T-Shirt", 0, "Roslyn Red T-Shirt", false, "7.png", 12m, 0 },
                    { 8, 34, 6, 3, "Kudu Purple Hoodie", 0, "Kudu Purple Hoodie", false, "8.png", 8.5m, 0 },
                    { 12, 0, 6, 3, "Prism White TShirt", 0, "Prism White TShirt", false, "12.png", 12m, 0 },
                    { 5, 55, 6, 4, "Roslyn Red Sheet", 0, "Roslyn Red Sheet", false, "5.png", 8.5m, 0 },
                    { 10, 11, 3, 4, ".NET Foundation Sheet", 0, ".NET Foundation Sheet", false, "10.png", 12m, 0 },
                    { 11, 3, 3, 4, "Cup<T> Sheet", 0, "Cup<T> Sheet", false, "11.png", 8.5m, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_CatalogBrandId",
                table: "Catalog",
                column: "CatalogBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_CatalogTypeId",
                table: "Catalog",
                column: "CatalogTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Catalog");

            migrationBuilder.DropTable(
                name: "CatalogBrand");

            migrationBuilder.DropTable(
                name: "CatalogType");
        }
    }
}
