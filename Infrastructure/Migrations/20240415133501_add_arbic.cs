using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class add_arbic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JobArabic",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameArabic",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionArabic",
                table: "MyWorks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameArabic",
                table: "MyWorks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleArabic",
                table: "MyWorks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Desc_ServArabic",
                table: "myServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionArabic",
                table: "myServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameServArabic",
                table: "myServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleArabic",
                table: "myServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionArabic",
                table: "Headers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressArabic",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionArabic",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailArabic",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneArabic",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AddressArabic",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionArabic",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailArabic",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameArabic",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NationalityArabic",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneArabic",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleArabic",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkStateArabic",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobArabic",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "NameArabic",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "DescriptionArabic",
                table: "MyWorks");

            migrationBuilder.DropColumn(
                name: "NameArabic",
                table: "MyWorks");

            migrationBuilder.DropColumn(
                name: "TitleArabic",
                table: "MyWorks");

            migrationBuilder.DropColumn(
                name: "Desc_ServArabic",
                table: "myServices");

            migrationBuilder.DropColumn(
                name: "DescriptionArabic",
                table: "myServices");

            migrationBuilder.DropColumn(
                name: "NameServArabic",
                table: "myServices");

            migrationBuilder.DropColumn(
                name: "TitleArabic",
                table: "myServices");

            migrationBuilder.DropColumn(
                name: "DescriptionArabic",
                table: "Headers");

            migrationBuilder.DropColumn(
                name: "AddressArabic",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "DescriptionArabic",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "EmailArabic",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "PhoneArabic",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "AddressArabic",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "DescriptionArabic",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "EmailArabic",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "NameArabic",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "NationalityArabic",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "PhoneArabic",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "TitleArabic",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "WorkStateArabic",
                table: "Abouts");
        }
    }
}
