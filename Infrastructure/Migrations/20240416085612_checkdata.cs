using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class checkdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobArabic",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "EmailArabic",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "EmailArabic",
                table: "Abouts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JobArabic",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailArabic",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmailArabic",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
