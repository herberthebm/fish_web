using Microsoft.EntityFrameworkCore.Migrations;

namespace webcodefirst.Migrations
{
    public partial class SeModificoExistencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Existecia",
                table: "tblProductos",
                newName: "Existencia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Existencia",
                table: "tblProductos",
                newName: "Existecia");
        }
    }
}
