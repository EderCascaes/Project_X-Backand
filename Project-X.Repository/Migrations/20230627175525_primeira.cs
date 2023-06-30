using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Project_X.Repository.Migrations
{
    public partial class primeira : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_endereco",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cidade = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    estado = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    logradouro = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    numero = table.Column<int>(type: "integer", maxLength: 8, nullable: false),
                    complemento = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    cep = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_endereco", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_login",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    password = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_login", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_rolePessoa",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    role = table.Column<int>(type: "integer", maxLength: 20, nullable: false),
                    cpf = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_rolePessoa", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    cpf = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_usuario", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_pessoa",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    telefone = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    dataNascimento = table.Column<DateTime>(type: "timestamp with time zone", maxLength: 10, nullable: false),
                    cpf = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    id_endereco = table.Column<int>(type: "integer", nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_pessoa", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_pessoa_tb_endereco_id_endereco",
                        column: x => x.id_endereco,
                        principalTable: "tb_endereco",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_fisioterapeuta",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    crefito = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    idPessoa = table.Column<int>(type: "integer", nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_fisioterapeuta", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_fisioterapeuta_tb_pessoa_idPessoa",
                        column: x => x.idPessoa,
                        principalTable: "tb_pessoa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_paciente",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idPessoa = table.Column<int>(type: "integer", nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_paciente", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_paciente_tb_pessoa_idPessoa",
                        column: x => x.idPessoa,
                        principalTable: "tb_pessoa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consulta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    data = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    descricao = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    idFisioterpeuta = table.Column<int>(type: "integer", nullable: false),
                    idPaciente = table.Column<int>(type: "integer", nullable: false),
                    CreatedIn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consulta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consulta_tb_fisioterapeuta_idFisioterpeuta",
                        column: x => x.idFisioterpeuta,
                        principalTable: "tb_fisioterapeuta",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consulta_tb_paciente_idPaciente",
                        column: x => x.idPaciente,
                        principalTable: "tb_paciente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_fisioterapia",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    dataInicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    dataFim = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    procedimento = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    idFisioterapeuta = table.Column<int>(type: "integer", nullable: false),
                    idPaciente = table.Column<int>(type: "integer", nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_fisioterapia", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_fisioterapia_tb_fisioterapeuta_idFisioterapeuta",
                        column: x => x.idFisioterapeuta,
                        principalTable: "tb_fisioterapeuta",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_fisioterapia_tb_paciente_idPaciente",
                        column: x => x.idPaciente,
                        principalTable: "tb_paciente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_idFisioterpeuta",
                table: "Consulta",
                column: "idFisioterpeuta");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_idPaciente",
                table: "Consulta",
                column: "idPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_tb_fisioterapeuta_idPessoa",
                table: "tb_fisioterapeuta",
                column: "idPessoa",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_fisioterapia_idFisioterapeuta",
                table: "tb_fisioterapia",
                column: "idFisioterapeuta");

            migrationBuilder.CreateIndex(
                name: "IX_tb_fisioterapia_idPaciente",
                table: "tb_fisioterapia",
                column: "idPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_tb_paciente_idPessoa",
                table: "tb_paciente",
                column: "idPessoa",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_pessoa_id_endereco",
                table: "tb_pessoa",
                column: "id_endereco",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consulta");

            migrationBuilder.DropTable(
                name: "tb_fisioterapia");

            migrationBuilder.DropTable(
                name: "tb_login");

            migrationBuilder.DropTable(
                name: "tb_rolePessoa");

            migrationBuilder.DropTable(
                name: "tb_usuario");

            migrationBuilder.DropTable(
                name: "tb_fisioterapeuta");

            migrationBuilder.DropTable(
                name: "tb_paciente");

            migrationBuilder.DropTable(
                name: "tb_pessoa");

            migrationBuilder.DropTable(
                name: "tb_endereco");
        }
    }
}
