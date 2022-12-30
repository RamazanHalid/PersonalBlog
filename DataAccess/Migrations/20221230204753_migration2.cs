using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleEn",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "RoleTr",
                table: "Experiences");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Experiences",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Experiences");

            migrationBuilder.AddColumn<string>(
                name: "RoleEn",
                table: "Experiences",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoleTr",
                table: "Experiences",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
