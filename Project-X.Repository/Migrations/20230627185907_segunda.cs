using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_X.Repository.Migrations
{
    public partial class segunda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "hora",
                table: "tb_fisioterapia",
                type: "character varying(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "progresso",
                table: "tb_fisioterapia",
                type: "character varying(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "qtdRealizadas",
                table: "tb_fisioterapia",
                type: "integer",
                maxLength: 300,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "quantidade",
                table: "tb_fisioterapia",
                type: "integer",
                maxLength: 300,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "hora",
                table: "Consulta",
                type: "character varying(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "hora",
                table: "tb_fisioterapia");

            migrationBuilder.DropColumn(
                name: "progresso",
                table: "tb_fisioterapia");

            migrationBuilder.DropColumn(
                name: "qtdRealizadas",
                table: "tb_fisioterapia");

            migrationBuilder.DropColumn(
                name: "quantidade",
                table: "tb_fisioterapia");

            migrationBuilder.DropColumn(
                name: "hora",
                table: "Consulta");
        }
    }
}
