using Microsoft.EntityFrameworkCore.Migrations;

namespace IMSApi.DAL.Migrations
{
    public partial class ToTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Vendors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Vendors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Vendors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Vendors");
        }
    }
}
