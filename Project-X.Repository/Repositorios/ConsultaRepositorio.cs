using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Project_X.Domain.Entities;
using Project_X.Interface.Repositories;
using Project_X.Repository.Common;
using Project_X.Repository.Repositories;

namespace Project_X.Repository.Repositorios
{
    public class ConsultaRepositorio : BaseRepositorio, IConsultaRepositorio
    {
        public ConsultaRepositorio(ApplicationDbContext dbContext) : base(dbContext) { }

        public async Task<int> Cadastro(Consulta consulta)
        {
            int id = DbContext.Consulta.Max(u => (int?)u.Id) ?? 0;

            consulta.Id = id + 1;
            consulta.CreatedIn = DateTime.Now;

            DbContext.Consulta.Add(consulta);
            
            DbContext.SaveChanges();

            return consulta.Id;
        }

        public async Task<int> Editar(Consulta consulta)
        {
            var c = await Obter(consulta.Id);

            c[0].Descricao = consulta.Descricao;
            c[0].Data = consulta.Data;
            c[0].Hora = consulta.Hora;
            c[0].IdPaciente = consulta.IdPaciente;
            c[0].IdFisioterpeuta = consulta.IdFisioterpeuta;

            DbContext.Consulta.Update(c[0]);
            DbContext.SaveChanges();

            return consulta.Id;
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

        public async Task<List<Consulta>> Obter(int id = 0)
        {

            if (id > 0)
            {
                var listaConsulta = new List<Consulta>();
                var c = DbContext.Consulta?.Where(x => x.Id == id)
                    .Include(p => p.Paciente)
                    .ThenInclude(p => p.Pessoa)
                    .Include(f => f.Fisioterapeuta)
                    .ThenInclude(p => p.Pessoa)
                    .FirstOrDefault();
                listaConsulta.Add(c);
                return listaConsulta;
            }

            return DbContext.Consulta
                    .Include(p => p.Paciente)
                    .Include(f => f.Fisioterapeuta)
                    .ToList();

        }

        public async Task<List<Consulta>> ObterPorDoc(string doc )
        {

            if (!string.IsNullOrEmpty(doc))
            {
                var listaConsulta = new List<Consulta>();
                var c = DbContext.Consulta?
                    .Where(x => x.Paciente.Pessoa.Cpf.Equals(doc) || x.Fisioterapeuta.Pessoa.Cpf.Equals(doc))
                    .Include(p => p.Paciente)
                    .ThenInclude(p => p.Pessoa)
                    .Include(f => f.Fisioterapeuta)
                    .ThenInclude(p => p.Pessoa)
                    .FirstOrDefault();
                listaConsulta.Add(c);
                return listaConsulta;
            }

            return DbContext.Consulta
                    .Include(p => p.Paciente)
                    .Include(f => f.Fisioterapeuta)
                    .ToList();

        }

        

        public async Task<Consulta> ObterValidaConsulta(DateTime data, string hora,  int idFisioterapeuta, int idPaciente)
        {

            if (data != null && idFisioterapeuta > 0 && !string.IsNullOrEmpty(hora))
            {
                var consulta = DbContext.Consulta?
                    .Where(x => x.Data == data && x.IdFisioterpeuta == idFisioterapeuta && x.Hora == hora)
                    .FirstOrDefault();

                return consulta;
            }
            else if (data != null && idPaciente > 0 && !string.IsNullOrEmpty(hora))
            {
                var consulta = DbContext.Consulta?
                    .Where(x => x.Data == data && x.IdPaciente == idPaciente && x.Hora == hora)
                    .FirstOrDefault();

                return consulta;
            }
                       

            return default;            
        }
    }
}
