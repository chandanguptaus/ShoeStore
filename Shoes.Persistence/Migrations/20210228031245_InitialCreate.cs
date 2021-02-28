using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shoes.Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Brand_id = table.Column<byte>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    ModifiedBy = table.Column<string>(type: "TEXT", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Brand_id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Category_id = table.Column<byte>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    ModifiedBy = table.Column<string>(type: "TEXT", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Category_id);
                });

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    Color_id = table.Column<byte>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    ModifiedBy = table.Column<string>(type: "TEXT", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Color_id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Person_id = table.Column<byte>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", maxLength: 5, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    ModifiedBy = table.Column<string>(type: "TEXT", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Person_id);
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    Size_id = table.Column<byte>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<float>(type: "REAL", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    ModifiedBy = table.Column<string>(type: "TEXT", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.Size_id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Category_id = table.Column<byte>(type: "INTEGER", nullable: false),
                    Brand_id = table.Column<byte>(type: "INTEGER", nullable: false),
                    Person_id = table.Column<byte>(type: "INTEGER", nullable: false),
                    Product_id = table.Column<int>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    ModifiedBy = table.Column<string>(type: "TEXT", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => new { x.Category_id, x.Brand_id, x.Person_id });
                    table.ForeignKey(
                        name: "FK_Product_Brand_Brand_id",
                        column: x => x.Brand_id,
                        principalTable: "Brand",
                        principalColumn: "Brand_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Category_Category_id",
                        column: x => x.Category_id,
                        principalTable: "Category",
                        principalColumn: "Category_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Person_Person_id",
                        column: x => x.Person_id,
                        principalTable: "Person",
                        principalColumn: "Person_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductPhoto",
                columns: table => new
                {
                    Photo_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Source = table.Column<string>(type: "TEXT", nullable: false),
                    Alt = table.Column<string>(type: "TEXT", nullable: false),
                    Product_id = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductCategory_id = table.Column<byte>(type: "INTEGER", nullable: true),
                    ProductBrand_id = table.Column<byte>(type: "INTEGER", nullable: true),
                    ProductPerson_id = table.Column<byte>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPhoto", x => x.Photo_id);
                    table.ForeignKey(
                        name: "FK_ProductPhoto_Product_ProductCategory_id_ProductBrand_id_ProductPerson_id",
                        columns: x => new { x.ProductCategory_id, x.ProductBrand_id, x.ProductPerson_id },
                        principalTable: "Product",
                        principalColumns: new[] { "Category_id", "Brand_id", "Person_id" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductVariant",
                columns: table => new
                {
                    Product_id = table.Column<int>(type: "INTEGER", nullable: false),
                    Size_id = table.Column<byte>(type: "INTEGER", nullable: false),
                    Color_id = table.Column<byte>(type: "INTEGER", nullable: false),
                    ProductVariant_Id = table.Column<long>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    RetailPrice = table.Column<double>(type: "REAL", nullable: false),
                    Discount = table.Column<float>(type: "REAL", nullable: false),
                    ProductCategory_id = table.Column<byte>(type: "INTEGER", nullable: true),
                    ProductBrand_id = table.Column<byte>(type: "INTEGER", nullable: true),
                    ProductPerson_id = table.Column<byte>(type: "INTEGER", nullable: true),
                    Brand_id = table.Column<byte>(type: "INTEGER", nullable: true),
                    Category_id = table.Column<byte>(type: "INTEGER", nullable: true),
                    Person_id = table.Column<byte>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariant", x => new { x.Product_id, x.Color_id, x.Size_id });
                    table.ForeignKey(
                        name: "FK_ProductVariant_Brand_Brand_id",
                        column: x => x.Brand_id,
                        principalTable: "Brand",
                        principalColumn: "Brand_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductVariant_Category_Category_id",
                        column: x => x.Category_id,
                        principalTable: "Category",
                        principalColumn: "Category_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductVariant_Color_Color_id",
                        column: x => x.Color_id,
                        principalTable: "Color",
                        principalColumn: "Color_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductVariant_Person_Person_id",
                        column: x => x.Person_id,
                        principalTable: "Person",
                        principalColumn: "Person_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductVariant_Product_ProductCategory_id_ProductBrand_id_ProductPerson_id",
                        columns: x => new { x.ProductCategory_id, x.ProductBrand_id, x.ProductPerson_id },
                        principalTable: "Product",
                        principalColumns: new[] { "Category_id", "Brand_id", "Person_id" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductVariant_Size_Size_id",
                        column: x => x.Size_id,
                        principalTable: "Size",
                        principalColumn: "Size_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_Brand_id",
                table: "Product",
                column: "Brand_id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Person_id",
                table: "Product",
                column: "Person_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPhoto_ProductCategory_id_ProductBrand_id_ProductPerson_id",
                table: "ProductPhoto",
                columns: new[] { "ProductCategory_id", "ProductBrand_id", "ProductPerson_id" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariant_Brand_id",
                table: "ProductVariant",
                column: "Brand_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariant_Category_id",
                table: "ProductVariant",
                column: "Category_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariant_Color_id",
                table: "ProductVariant",
                column: "Color_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariant_Person_id",
                table: "ProductVariant",
                column: "Person_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariant_ProductCategory_id_ProductBrand_id_ProductPerson_id",
                table: "ProductVariant",
                columns: new[] { "ProductCategory_id", "ProductBrand_id", "ProductPerson_id" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariant_Size_id",
                table: "ProductVariant",
                column: "Size_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductPhoto");

            migrationBuilder.DropTable(
                name: "ProductVariant");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
