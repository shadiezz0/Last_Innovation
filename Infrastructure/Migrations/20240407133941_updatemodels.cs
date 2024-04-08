using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatemodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Services",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Contacts",
                newName: "Image");

            migrationBuilder.AddColumn<string>(
                name: "Desc_Serv",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameServ",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "MyWorks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "MyWorks",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desc_Serv",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "NameServ",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "MyWorks");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "MyWorks");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Services",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Contacts",
                newName: "Description");
        }
    }
}
