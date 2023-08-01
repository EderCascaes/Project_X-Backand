using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_X.Repository.Migrations
{
    public partial class ajustebairro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "bairro",
                table: "tb_endereco",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bairro",
                table: "tb_endereco");
        }
    }
}
