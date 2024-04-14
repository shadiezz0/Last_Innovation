using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class SeedAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Users (Name, Role, Email, Password) VALUES ( 'Admin', 1 , 'Admin@gmail.com' , 'password123' )");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
