using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MobileApp.Migrations
{
    public partial class MainData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Specification",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Price = table.Column<string>(nullable: true),
                    Year = table.Column<string>(nullable: true),
                    Make = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Mileage = table.Column<string>(nullable: true),
                    Trim = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Transmission = table.Column<string>(nullable: true),
                    Vin = table.Column<string>(nullable: true),
                    Condition = table.Column<string>(nullable: true),
                    ExteriorColor = table.Column<string>(nullable: true),
                    InteriorColor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specification", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CarProfile",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SpecificationID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarProfile", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CarProfile_Specification_SpecificationID",
                        column: x => x.SpecificationID,
                        principalTable: "Specification",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Picture = table.Column<byte[]>(nullable: true),
                    CarProfileID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Image_CarProfile_CarProfileID",
                        column: x => x.CarProfileID,
                        principalTable: "CarProfile",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarProfile_SpecificationID",
                table: "CarProfile",
                column: "SpecificationID");

            migrationBuilder.CreateIndex(
                name: "IX_Image_CarProfileID",
                table: "Image",
                column: "CarProfileID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "CarProfile");

            migrationBuilder.DropTable(
                name: "Specification");
        }
    }
}
