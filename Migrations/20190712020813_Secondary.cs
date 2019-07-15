using Microsoft.EntityFrameworkCore.Migrations;

namespace MobileApp.Migrations
{
    public partial class Secondary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_CarProfile_CarProfileID",
                table: "Image");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Image",
                newName: "ImageID");

            migrationBuilder.AlterColumn<int>(
                name: "CarProfileID",
                table: "Image",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Image_CarProfile_CarProfileID",
                table: "Image",
                column: "CarProfileID",
                principalTable: "CarProfile",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_CarProfile_CarProfileID",
                table: "Image");

            migrationBuilder.RenameColumn(
                name: "ImageID",
                table: "Image",
                newName: "ID");

            migrationBuilder.AlterColumn<int>(
                name: "CarProfileID",
                table: "Image",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Image_CarProfile_CarProfileID",
                table: "Image",
                column: "CarProfileID",
                principalTable: "CarProfile",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
