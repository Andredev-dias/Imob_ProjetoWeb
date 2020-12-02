using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Imob.Migrations
{
    public partial class AlterLocatario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "Locatarios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "RG",
                table: "Locatarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sobrenome",
                table: "Locatarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "Locatarios");

            migrationBuilder.DropColumn(
                name: "RG",
                table: "Locatarios");

            migrationBuilder.DropColumn(
                name: "Sobrenome",
                table: "Locatarios");
        }
    }
}
