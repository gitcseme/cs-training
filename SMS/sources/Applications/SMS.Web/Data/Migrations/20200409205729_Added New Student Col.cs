using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Web.Data.Migrations
{
    public partial class AddedNewStudentCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FatherName",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Standard",
                table: "Students",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FatherName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Standard",
                table: "Students");
        }
    }
}
