using Microsoft.EntityFrameworkCore.Migrations;

namespace webcodefirst.Migrations
{
    public partial class SeAgregopelurats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Pelurats",
                table: "tblProductos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pelurats",
                table: "tblProductos");
        }
    }
}
