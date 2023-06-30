using Microsoft.EntityFrameworkCore;
using Project_X.Domain.Entities;
using Project_X.Interface.Repositories;
using Project_X.Repository.Common;
using Project_X.Repository.Repositories;

namespace Project_X.Repository.Repositorios
{
    public class FisioterapiaRepositorio : BaseRepositorio, IFisioterapiaRepositorio
    {
        public FisioterapiaRepositorio(ApplicationDbContext dbContext) : base(dbContext) { }

        public async Task<int> Cadastro(Fisioterapia fisioterapia)
        {
            int id = DbContext.Fisioterapia.Max(u => (int?)u.Id) ?? 0;

            fisioterapia.Id = id + 1;
            fisioterapia.CreatedIn = DateTime.Now;

            DbContext.Fisioterapia.Add(fisioterapia);
            DbContext.SaveChanges();

            return fisioterapia.Id;
        }

        public async Task<int> Editar(Fisioterapia fisioterapia)
        {
            var f = await Obter(fisioterapia.Id);

            f[0].DataInicio = fisioterapia.DataInicio;
            f[0].DataFim = fisioterapia.DataFim;
            f[0].IdPaciente = fisioterapia.IdPaciente;
            f[0].IdFisioterapeuta = fisioterapia.IdFisioterapeuta;
            f[0].Procedimento = fisioterapia.Procedimento;

            DbContext.Fisioterapia.Update(f[0]);
            DbContext.SaveChanges();

            return fisioterapia.Id;
        }

        public async Task<int> Excluir(int id)
        {
            if (id <= 0) return 0;

            var p = DbContext.Consulta.Find(id);

            if (p == null) return 0;


            DbContext.Consulta.Remove(p);
            DbContext.SaveChanges();

            return p.Id;

        }

        public async Task<List<Fisioterapia>> Obter(int id = 0)
        {

            if (id > 0)
            {
                var listaFisioterapia = new List<Fisioterapia>();
                var c = DbContext.Fisioterapia?.Where(x => x.Id == id)
                    .Include(p => p.Paciente)
                    .ThenInclude(p => p.Pessoa)
                    .Include(f => f.Fisioterapeuta)
                    .ThenInclude(p => p.Pessoa)
                    .FirstOrDefault();
                listaFisioterapia.Add(c);
                return listaFisioterapia;
            }

            return DbContext.Fisioterapia
                    .Include(p => p.Paciente)
                    .Include(f => f.Fisioterapeuta)
                    .ToList();

        }

        public async Task<List<Fisioterapia>> ObterPorDoc(string docOuNome)
        {

            if (!string.IsNullOrEmpty(docOuNome))
            {
                var listaFisioterapia = new List<Fisioterapia>();
                var c = DbContext.Fisioterapia?
                    .Where(x => x.Paciente.Pessoa.Cpf.Equals(docOuNome) 
                    || x.Fisioterapeuta.Pessoa.Cpf.Equals(docOuNome)
                    || x.Paciente.Pessoa.Nome.Contains(docOuNome) 
                    || x.Fisioterapeuta.Pessoa.Nome.Contains(docOuNome))
                    .Include(p => p.Paciente)
                    .ThenInclude(p => p.Pessoa)
                    .Include(f => f.Fisioterapeuta)
                    .ThenInclude(p => p.Pessoa)
                    .FirstOrDefault();
                listaFisioterapia.Add(c);
                return listaFisioterapia;
            }

            return DbContext.Fisioterapia
                    .Include(p => p.Paciente)
                    .Include(f => f.Fisioterapeuta)
                    .ToList();

        }
    }
}
