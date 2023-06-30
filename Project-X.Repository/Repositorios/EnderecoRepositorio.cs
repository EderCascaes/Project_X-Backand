using Project_X.Domain.Entities;
using Project_X.Interface.Repositories;
using Project_X.Repository.Common;
using Project_X.Repository.Repositories;

namespace Project_X.Repository.Repositorios
{
    public class EnderecoRepositorio : BaseRepositorio, IEnderecoRepositorio
    {
        public EnderecoRepositorio(ApplicationDbContext dbContext) : base(dbContext) { }


        public async Task<int> Cadastro(Endereco endereco)
        {
            int id = DbContext.Endereco.Max(u => (int?)u.Id) ?? 0;

            endereco.Id = id + 1;
            endereco.CreatedIn = DateTime.Now;

            DbContext.Endereco.Add(endereco);
            DbContext.SaveChanges();

            return endereco.Id;
        }

        public async Task<int> Editar(Endereco endereco)
        {
            var e = await Obter(endereco.Id);

            e[0].Logradouro = endereco.Logradouro;
            e[0].CEP = endereco.CEP;
            e[0].Cidade = endereco.Cidade;
            e[0].Complemento = endereco.Complemento;
            e[0].Estado = endereco.Estado;
            e[0].Numero = endereco.Numero;

            DbContext.Endereco.Update(e[0]);
            DbContext.SaveChanges();

            return endereco.Id;
        }

        public async Task<int> Excluir(int id)
        {
            if (id <= 0) return 0;

            var e =  DbContext.Endereco.Find(id);

            if (e == null) return 0;


            DbContext.Endereco.Remove(e);
            DbContext.SaveChanges();

            return e.Id;

        }

        public async Task<List<Endereco>> Obter(int id = 0)
        {

            if (id > 0)
            {
                var listaEndereco = new List<Endereco>();
                var e = DbContext.Endereco?.Where(x => x.Id == id).FirstOrDefault();
                listaEndereco.Add(e);
                return listaEndereco;
            }

            return DbContext.Endereco?.OrderBy(x => x.Id).ToList();
        }
    }
}
