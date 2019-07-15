using Microsoft.EntityFrameworkCore.Migrations;

namespace MobileApp.Migrations
{
    public partial class Remodeled : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageID",
                table: "Image",
                newName: "CarImageID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CarImageID",
                table: "Image",
                newName: "ImageID");
        }
    }
}
