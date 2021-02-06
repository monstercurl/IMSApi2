using Microsoft.EntityFrameworkCore.Migrations;

namespace IMSApi.DAL.Migrations
{
    public partial class vendorApis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_Vendor_Vendorid",
                table: "product");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Vendor");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Vendor");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Vendor",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Vendorid",
                table: "product",
                newName: "VendorId");

            migrationBuilder.RenameIndex(
                name: "IX_product_Vendorid",
                table: "product",
                newName: "IX_product_VendorId");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Vendor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gstin",
                table: "Vendor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IsDeleted",
                table: "Vendor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Store_name",
                table: "Vendor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Supplier_code",
                table: "Vendor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Vendor_name",
                table: "Vendor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "Vendor",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_product_Vendor_VendorId",
                table: "product",
                column: "VendorId",
                principalTable: "Vendor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_Vendor_VendorId",
                table: "product");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Vendor");

            migrationBuilder.DropColumn(
                name: "Gstin",
                table: "Vendor");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Vendor");

            migrationBuilder.DropColumn(
                name: "Store_name",
                table: "Vendor");

            migrationBuilder.DropColumn(
                name: "Supplier_code",
                table: "Vendor");

            migrationBuilder.DropColumn(
                name: "Vendor_name",
                table: "Vendor");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "Vendor");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Vendor",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "VendorId",
                table: "product",
                newName: "Vendorid");

            migrationBuilder.RenameIndex(
                name: "IX_product_VendorId",
                table: "product",
                newName: "IX_product_Vendorid");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Vendor",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Vendor",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_product_Vendor_Vendorid",
                table: "product",
                column: "Vendorid",
                principalTable: "Vendor",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
