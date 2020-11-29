using Microsoft.EntityFrameworkCore.Migrations;

namespace Imob.Migrations
{
    public partial class AddArquivoPAth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Arquivo",
                table: "Contratos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Arquivo",
                table: "Contratos");
        }
    }
}
