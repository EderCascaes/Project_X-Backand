using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_X.Repository.Migrations
{
    public partial class sexta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Funcoes",
                table: "tb_login");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<List<int>>(
                name: "Funcoes",
                table: "tb_login",
                type: "integer[]",
                nullable: false);
        }
    }
}
