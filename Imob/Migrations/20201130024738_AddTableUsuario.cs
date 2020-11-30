using Microsoft.EntityFrameworkCore.Migrations;

namespace Imob.Migrations
{
    public partial class AddTableUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "UsuarioLogado");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuarioLogado",
                table: "UsuarioLogado",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuarioLogado",
                table: "UsuarioLogado");

            migrationBuilder.RenameTable(
                name: "UsuarioLogado",
                newName: "Usuarios");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");
        }
    }
}
