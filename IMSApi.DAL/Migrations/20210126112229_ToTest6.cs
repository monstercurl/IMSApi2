using Microsoft.EntityFrameworkCore.Migrations;

namespace IMSApi.DAL.Migrations
{
    public partial class ToTest6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "vId",
                table: "Product",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_vId",
                table: "Product",
                column: "vId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Vendors_vId",
                table: "Product",
                column: "vId",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Vendors_vId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_vId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "vId",
                table: "Product");
        }
    }
}
