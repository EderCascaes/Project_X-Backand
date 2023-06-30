﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Project_X.Repository.Common;

#nullable disable

namespace Project_X.Repository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230628164358_Quarta")]
    partial class Quarta
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Project_X.Domain.Entities.Consulta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedIn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Data")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("data");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)")
                        .HasColumnName("descricao");

                    b.Property<string>("Hora")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("character varying(5)")
                        .HasColumnName("hora");

                    b.Property<int>("IdFisioterpeuta")
                        .HasColumnType("integer")
                        .HasColumnName("idFisioterpeuta");

                    b.Property<int>("IdPaciente")
                        .HasColumnType("integer")
                        .HasColumnName("idPaciente");

                    b.HasKey("Id");

                    b.HasIndex("IdFisioterpeuta");

                    b.HasIndex("IdPaciente");

                    b.ToTable("Consulta");
                });

            modelBuilder.Entity("Project_X.Domain.Entities.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("character varying(9)")
                        .HasColumnName("cep");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("cidade");

                    b.Property<string>("Complemento")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("complemento");

                    b.Property<DateTime?>("CreatedIn")
                        .IsRequired()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("criado_em");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("character varying(2)")
                        .HasColumnName("estado");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("logradouro");

                    b.Property<int>("Numero")
                        .HasMaxLength(8)
                        .HasColumnType("integer")
                        .HasColumnName("numero");

                    b.HasKey("Id");

                    b.ToTable("tb_endereco", (string)null);
                });

            modelBuilder.Entity("Project_X.Domain.Entities.Fisioterapeuta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CREFITO")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)")
                        .HasColumnName("crefito");

                    b.Property<DateTime?>("CreatedIn")
                        .IsRequired()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("criado_em");

                    b.Property<int>("IdPessoa")
                        .HasColumnType("integer")
                        .HasColumnName("idPessoa");

                    b.HasKey("Id");

                    b.HasIndex("IdPessoa")
                        .IsUnique();

                    b.ToTable("tb_fisioterapeuta", (string)null);
                });

            modelBuilder.Entity("Project_X.Domain.Entities.Fisioterapia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedIn")
                        .IsRequired()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("criado_em");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("dataFim");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("dataInicio");

                    b.Property<string>("Hora")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("character varying(5)")
                        .HasColumnName("hora");

                    b.Property<int>("IdFisioterapeuta")
                        .HasColumnType("integer")
                        .HasColumnName("idFisioterapeuta");

                    b.Property<int>("IdPaciente")
                        .HasColumnType("integer")
                        .HasColumnName("idPaciente");

                    b.Property<string>("Procedimento")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)")
                        .HasColumnName("procedimento");

                    b.Property<string>("Progresso")
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)")
                        .HasColumnName("progresso");

                    b.Property<int>("QtdRealizadas")
                        .HasMaxLength(300)
                        .HasColumnType("integer")
                        .HasColumnName("qtdRealizadas");

                    b.Property<int>("Quantidade")
                        .HasMaxLength(300)
                        .HasColumnType("integer")
                        .HasColumnName("quantidade");

                    b.HasKey("Id");

                    b.HasIndex("IdFisioterapeuta");

                    b.HasIndex("IdPaciente");

                    b.ToTable("tb_fisioterapia", (string)null);
                });

            modelBuilder.Entity("Project_X.Domain.Entities.Login", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedIn")
                        .IsRequired()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("criado_em");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("email");

                    b.Property<int>("IdPessoa")
                        .HasColumnType("integer")
                        .HasColumnName("idPessoa");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)")
                        .HasColumnName("password");

                    b.HasKey("Id");

                    b.HasIndex("IdPessoa")
                        .IsUnique();

                    b.ToTable("tb_login", (string)null);
                });

            modelBuilder.Entity("Project_X.Domain.Entities.Paciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedIn")
                        .IsRequired()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("criado_em");

                    b.Property<int>("IdPessoa")
                        .HasColumnType("integer")
                        .HasColumnName("idPessoa");

                    b.HasKey("Id");

                    b.HasIndex("IdPessoa")
                        .IsUnique();

                    b.ToTable("tb_paciente", (string)null);
                });

            modelBuilder.Entity("Project_X.Domain.Entities.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)")
                        .HasColumnName("cpf");

                    b.Property<DateTime?>("CreatedIn")
                        .IsRequired()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("criado_em");

                    b.Property<DateTime>("DataNascimento")
                        .HasMaxLength(10)
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("dataNascimento");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("email");

                    b.Property<int>("IdEndereco")
                        .HasColumnType("integer")
                        .HasColumnName("id_endereco");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("nome");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("character varying(13)")
                        .HasColumnName("telefone");

                    b.HasKey("Id");

                    b.HasIndex("IdEndereco")
                        .IsUnique();

                    b.ToTable("tb_pessoa", (string)null);
                });

            modelBuilder.Entity("Project_X.Domain.Entities.RolePessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)")
                        .HasColumnName("cpf");

                    b.Property<DateTime?>("CreatedIn")
                        .IsRequired()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("criado_em");

                    b.Property<int>("Role")
                        .HasMaxLength(20)
                        .HasColumnType("integer")
                        .HasColumnName("role");

                    b.HasKey("Id");

                    b.ToTable("tb_rolePessoa", (string)null);
                });

            modelBuilder.Entity("Project_X.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("cpf");

                    b.Property<DateTime?>("CreatedIn")
                        .IsRequired()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("criado_em");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("tb_usuario", (string)null);
                });

            modelBuilder.Entity("Project_X.Domain.Entities.Consulta", b =>
                {
                    b.HasOne("Project_X.Domain.Entities.Fisioterapeuta", "Fisioterapeuta")
                        .WithMany("Consultas")
                        .HasForeignKey("IdFisioterpeuta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project_X.Domain.Entities.Paciente", "Paciente")
                        .WithMany("Consultas")
                        .HasForeignKey("IdPaciente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fisioterapeuta");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("Project_X.Domain.Entities.Fisioterapeuta", b =>
                {
                    b.HasOne("Project_X.Domain.Entities.Pessoa", "Pessoa")
                        .WithOne("Fisioterapeuta")
                        .HasForeignKey("Project_X.Domain.Entities.Fisioterapeuta", "IdPessoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("Project_X.Domain.Entities.Fisioterapia", b =>
                {
                    b.HasOne("Project_X.Domain.Entities.Fisioterapeuta", "Fisioterapeuta")
                        .WithMany("Fisioterapias")
                        .HasForeignKey("IdFisioterapeuta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project_X.Domain.Entities.Paciente", "Paciente")
                        .WithMany("Fisioterapias")
                        .HasForeignKey("IdPaciente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fisioterapeuta");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("Project_X.Domain.Entities.Login", b =>
                {
                    b.HasOne("Project_X.Domain.Entities.Pessoa", "Pessoa")
                        .WithOne("Login")
                        .HasForeignKey("Project_X.Domain.Entities.Login", "IdPessoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("Project_X.Domain.Entities.Paciente", b =>
                {
                    b.HasOne("Project_X.Domain.Entities.Pessoa", "Pessoa")
                        .WithOne("Paciente")
                        .HasForeignKey("Project_X.Domain.Entities.Paciente", "IdPessoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("Project_X.Domain.Entities.Pessoa", b =>
                {
                    b.HasOne("Project_X.Domain.Entities.Endereco", "Endereco")
                        .WithOne("Pessoa")
                        .HasForeignKey("Project_X.Domain.Entities.Pessoa", "IdEndereco")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("Project_X.Domain.Entities.Endereco", b =>
                {
                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("Project_X.Domain.Entities.Fisioterapeuta", b =>
                {
                    b.Navigation("Consultas");

                    b.Navigation("Fisioterapias");
                });

            modelBuilder.Entity("Project_X.Domain.Entities.Paciente", b =>
                {
                    b.Navigation("Consultas");

                    b.Navigation("Fisioterapias");
                });

            modelBuilder.Entity("Project_X.Domain.Entities.Pessoa", b =>
                {
                    b.Navigation("Fisioterapeuta");

                    b.Navigation("Login")
                        .IsRequired();

                    b.Navigation("Paciente");
                });
#pragma warning restore 612, 618
        }
    }
}
