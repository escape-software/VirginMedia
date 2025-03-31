using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductSales.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    DiscountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.DiscountId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Segment",
                columns: table => new
                {
                    SegmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SegmentName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Segment", x => x.SegmentId);
                });

            migrationBuilder.CreateTable(
                name: "ProductSaleSummary",
                columns: table => new
                {
                    SaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SegmentId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    DiscountId = table.Column<int>(type: "int", nullable: false),
                    UnitsSold = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    ManufacturingPrice = table.Column<decimal>(type: "money", nullable: true),
                    SalePrice = table.Column<decimal>(type: "money", nullable: true),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSaleSummary", x => x.SaleId);
                    table.ForeignKey(
                        name: "FK_ProductSaleSummary_Country",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "CountryId");
                    table.ForeignKey(
                        name: "FK_ProductSaleSummary_Discount",
                        column: x => x.DiscountId,
                        principalTable: "Discount",
                        principalColumn: "DiscountId");
                    table.ForeignKey(
                        name: "FK_ProductSaleSummary_Product",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK_ProductSaleSummary_Segment",
                        column: x => x.SegmentId,
                        principalTable: "Segment",
                        principalColumn: "SegmentId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductSaleSummary_CountryId",
                table: "ProductSaleSummary",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSaleSummary_DiscountId",
                table: "ProductSaleSummary",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSaleSummary_ProductId",
                table: "ProductSaleSummary",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSaleSummary_SegmentId",
                table: "ProductSaleSummary",
                column: "SegmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductSaleSummary");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Segment");
        }
    }
}
