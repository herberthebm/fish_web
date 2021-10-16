using Microsoft.EntityFrameworkCore.Migrations;

namespace webcodefirst.Migrations
{
    public partial class SeQuitopelurats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pelurats",
                table: "tblProductos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Pelurats",
                table: "tblProductos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
