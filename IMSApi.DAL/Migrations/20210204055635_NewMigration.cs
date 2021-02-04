using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IMSApi.DAL.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Category_Value = table.Column<string>(nullable: true),
                    Parent_Category = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "productColor",
                columns: table => new
                {
                    ProductColor_ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductColorValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productColor", x => x.ProductColor_ID);
                });

            migrationBuilder.CreateTable(
                name: "productSize",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productSize", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    _role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendor",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Brand = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    PasswordInHash = table.Column<string>(nullable: true),
                    profile_pic_url = table.Column<string>(nullable: true),
                    RoleId = table.Column<int>(nullable: true),
                    EmailVerificationToken = table.Column<string>(nullable: true),
                    PasswordResetToken = table.Column<string>(nullable: true),
                    PasswordResetTokenExpiry = table.Column<DateTime>(nullable: false),
                    VerifiedOn = table.Column<DateTime>(nullable: false),
                    IsVerified = table.Column<bool>(nullable: false),
                    IsDeactivated = table.Column<bool>(nullable: false),
                    RegisteredOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    Product_ID = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CategoryId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Cost_Price = table.Column<int>(nullable: false),
                    Selling_price = table.Column<int>(nullable: false),
                    Vendorid = table.Column<int>(nullable: true),
                    AddDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.Product_ID);
                    table.ForeignKey(
                        name: "FK_product_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_product_Vendor_Vendorid",
                        column: x => x.Vendorid,
                        principalTable: "Vendor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "productDesign",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductColor_ID = table.Column<int>(nullable: true),
                    productSizeId = table.Column<int>(nullable: true),
                    Product_ID = table.Column<long>(nullable: true),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productDesign", x => x.Id);
                    table.ForeignKey(
                        name: "FK_productDesign_productColor_ProductColor_ID",
                        column: x => x.ProductColor_ID,
                        principalTable: "productColor",
                        principalColumn: "ProductColor_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_productDesign_product_Product_ID",
                        column: x => x.Product_ID,
                        principalTable: "product",
                        principalColumn: "Product_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_productDesign_productSize_productSizeId",
                        column: x => x.productSizeId,
                        principalTable: "productSize",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    folderName = table.Column<string>(nullable: true),
                    Physicalurl = table.Column<string>(nullable: true),
                    Product_ID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProductImages_product_Product_ID",
                        column: x => x.Product_ID,
                        principalTable: "product",
                        principalColumn: "Product_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Category_Value", "Parent_Category" },
                values: new object[,]
                {
                    { 1, "Stiched", 0 },
                    { 2, "UnStiched", 0 },
                    { 3, "ReadyMade", 0 }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "_role" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "endUser" },
                    { 3, "customer" },
                    { 4, "reseller" }
                });

            migrationBuilder.InsertData(
                table: "productColor",
                columns: new[] { "ProductColor_ID", "ProductColorValue" },
                values: new object[,]
                {
                    { 1, "Red" },
                    { 2, "Black" },
                    { 3, "Blue" }
                });

            migrationBuilder.InsertData(
                table: "productSize",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { 4, "23" },
                    { 5, "24" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_RoleId",
                table: "Account",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_product_CategoryId",
                table: "product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_product_Vendorid",
                table: "product",
                column: "Vendorid");

            migrationBuilder.CreateIndex(
                name: "IX_productDesign_ProductColor_ID",
                table: "productDesign",
                column: "ProductColor_ID");

            migrationBuilder.CreateIndex(
                name: "IX_productDesign_Product_ID",
                table: "productDesign",
                column: "Product_ID");

            migrationBuilder.CreateIndex(
                name: "IX_productDesign_productSizeId",
                table: "productDesign",
                column: "productSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_Product_ID",
                table: "ProductImages",
                column: "Product_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "productDesign");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "productColor");

            migrationBuilder.DropTable(
                name: "productSize");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Vendor");
        }
    }
}
