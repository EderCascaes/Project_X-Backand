using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_X.Domain.Entities;

namespace Project_X.Repository.Common
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UsuarioLogin> UsuarioLogin { get; set; }
        public DbSet<Consulta> Consulta { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Fisioterapeuta> Fisioterapeuta { get; set; }
        public DbSet<Fisioterapia> Fisioterapia { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<RolePessoa> RolePessoa { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        public ApplicationDbContext()
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);  // resolver problema na data UTC no  post 


        }
    }
}
