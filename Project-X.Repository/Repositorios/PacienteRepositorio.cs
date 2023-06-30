using Microsoft.EntityFrameworkCore;
using Project_X.Domain.Entities;
using Project_X.Interface.Repositories;
using Project_X.Repository.Common;
using Project_X.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_X.Repository.Repositorios
{
    public class PacienteRepositorio : BaseRepositorio, IPacienteRepositorio
    {
        public PacienteRepositorio(ApplicationDbContext dbContext) : base(dbContext) { }

        public async Task<int> Cadastro(Paciente paciente)
        {
            int id = DbContext.Paciente.Max(u => (int?)u.Id) ?? 0;

            paciente.Id = id + 1;
            paciente.CreatedIn = DateTime.Now;
            
            DbContext.Paciente.Add(paciente);
            DbContext.SaveChanges();

            return paciente.Id;
        }

        public async Task<int> Editar(Paciente paciente)
        {
            var p = await Obter(paciente.Id);

            p[0].Id = paciente.Id;       

            DbContext.Paciente.Update(p[0]);
            DbContext.SaveChanges();

            return paciente.Id;
        }

        public async Task<int> Excluir(int id)
        {
            if (id <= 0) return 0;

            var p = DbContext.Paciente.Find(id);

            if (p == null) return 0;


            DbContext.Paciente.Remove(p);
            DbContext.SaveChanges();

            return p.Id;

        }

        public async Task<List<Paciente>> Obter(int id = 0)
        {

            if (id > 0)
            {
                var listaPaciente = new List<Paciente>();
                var p = DbContext.Paciente?.Where(x => x.Id == id)
                    .Include(x => x.Pessoa)
                    .FirstOrDefault();
                listaPaciente.Add(p);
                return listaPaciente;
            }

            return DbContext.Paciente
                .Include(p => p.Pessoa)
                .ToList();
                                              
        }
    }
}
