using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_X.Repository.Migrations
{
    public partial class Quarta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idPessoa",
                table: "tb_login",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tb_login_idPessoa",
                table: "tb_login",
                column: "idPessoa",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_login_tb_pessoa_idPessoa",
                table: "tb_login",
                column: "idPessoa",
                principalTable: "tb_pessoa",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_login_tb_pessoa_idPessoa",
                table: "tb_login");

            migrationBuilder.DropIndex(
                name: "IX_tb_login_idPessoa",
                table: "tb_login");

            migrationBuilder.DropColumn(
                name: "idPessoa",
                table: "tb_login");
        }
    }
}
