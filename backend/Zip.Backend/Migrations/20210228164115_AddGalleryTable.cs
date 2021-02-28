using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Zip.Backend.Migrations
{
    public partial class AddGalleryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "gallery",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    url = table.Column<string>(nullable: true),
                    created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_gallery", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "gallery");
        }
    }
}
