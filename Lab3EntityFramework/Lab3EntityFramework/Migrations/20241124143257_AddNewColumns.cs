using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab3EntityFramework.Migrations
{
    public partial class AddNewColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReaderId",
                table: "readers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "libraryBooks",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "readers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "libraryBooks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Сopies",
                table: "libraryBooks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "readers");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "libraryBooks");

            migrationBuilder.DropColumn(
                name: "Сopies",
                table: "libraryBooks");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "readers",
                newName: "ReaderId");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "libraryBooks",
                newName: "Name");
        }
    }
}
