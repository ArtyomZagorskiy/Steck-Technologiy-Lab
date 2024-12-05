using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab3EntityFramework.Migrations
{
    public partial class CreateLibraryDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "readers",
                columns: table => new
                {
                    ReaderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_readers", x => x.ReaderId);
                });

            migrationBuilder.CreateTable(
                name: "libraryBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReaderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_libraryBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_libraryBooks_readers_ReaderId",
                        column: x => x.ReaderId,
                        principalTable: "readers",
                        principalColumn: "ReaderId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_libraryBooks_ReaderId",
                table: "libraryBooks",
                column: "ReaderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "libraryBooks");

            migrationBuilder.DropTable(
                name: "readers");
        }
    }
}
