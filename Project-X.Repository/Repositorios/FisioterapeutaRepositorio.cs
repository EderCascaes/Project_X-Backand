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
    public class FisioterapeutaRepositorio: BaseRepositorio, IFisioterapeutaRepositorio
    {
        public FisioterapeutaRepositorio(ApplicationDbContext dbContext) : base(dbContext) { }

        public async Task<int> Cadastro(Fisioterapeuta fisioterapeuta)
        {
            int id = DbContext.Fisioterapeuta.Max(u => (int?)u.Id) ?? 0;

            fisioterapeuta.Id = id + 1;
            fisioterapeuta.CreatedIn = DateTime.Now;
            
            DbContext.Fisioterapeuta.Add(fisioterapeuta);
            DbContext.SaveChanges();

            return fisioterapeuta.Id;
        }

        public async Task<int> Editar(Fisioterapeuta fisioterapeuta)
        {
            var f = await Obter(fisioterapeuta.Id);

            f[0].CREFITO = fisioterapeuta.CREFITO;           

            DbContext.Fisioterapeuta.Update(f[0]);
            DbContext.SaveChanges();

            return fisioterapeuta.Id;
        }

        public async Task<int> Excluir(int id)
        {
            if (id <= 0) return 0;

            var p = DbContext.Fisioterapeuta.Find(id);

            if (p == null) return 0;


            DbContext.Fisioterapeuta.Remove(p);
            DbContext.SaveChanges();

            return p.Id;

        }

        public async Task<List<Fisioterapeuta>> Obter(int id = 0)
        {

            if (id > 0)
            {
                var listaFisiot = new List<Fisioterapeuta>();
                var p = DbContext.Fisioterapeuta?.Where(x => x.Id == id)
                    .Include(x => x.Pessoa)
                    .FirstOrDefault();
                listaFisiot.Add(p);
                return listaFisiot;
            }

            return DbContext.Fisioterapeuta
                .Include(p => p.Pessoa)
               /* .Select(x => new Fisioterapeuta
                {
                    CREFITO = x.CREFITO
                   
                })*/
                .ToList();
                                              
        }
    }
}
