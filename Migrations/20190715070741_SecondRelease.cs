using Microsoft.EntityFrameworkCore.Migrations;

namespace MobileApp.Migrations
{
    public partial class SecondRelease : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Special",
                table: "Specification",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Special",
                table: "Specification");
        }
    }
}
