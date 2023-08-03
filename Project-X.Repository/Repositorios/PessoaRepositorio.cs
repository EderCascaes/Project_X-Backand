using Microsoft.EntityFrameworkCore;
using Project_X.Domain.Entities;
using Project_X.Interface.Repositories;
using Project_X.Repository.Common;
using Project_X.Repository.Repositories;
using Project_X.Domain.Static;

namespace Project_X.Repository.Repositorios
{
    public class PessoaRepositorio : BaseRepositorio, IPessoaRepositorio
    {
        public PessoaRepositorio(ApplicationDbContext dbContext) : base(dbContext) { }


        public async Task<int> Cadastro(Pessoa pessoa)
        {
            int id = DbContext.Pessoa.Max(u => (int?)u.Id) ?? 0;

            pessoa.Id = id + 1;
            pessoa.CreatedIn = DateTime.Now;

            DbContext.Pessoa.Add(pessoa);

            if (pessoa.Funcao.Count() > 0)
                foreach (var p in pessoa.Funcao)
                {
                    DbContext.RolePessoa.Add(new RolePessoa
                    {
                        CreatedIn = DateTime.Now,
                        Cpf = pessoa.Cpf,
                        Role = p
                    });
                }

            
            DbContext.SaveChanges();

            return pessoa.Id;
        }

 

        public async Task<int> Editar(Pessoa pessoa)
        {
            var p = await Obter(pessoa.Id);

            p[0].Cpf = pessoa.Cpf;
            p[0].Telefone = pessoa.Telefone;
            p[0].Email = pessoa.Email;
            p[0].DataNascimento = pessoa.DataNascimento;
            p[0].Nome = pessoa.Nome;


            if (pessoa.Funcao.Count() > 0)
            {
                var lisRolesf = DbContext.RolePessoa.Where(y => y.Cpf == pessoa.Cpf).ToList();

                foreach (var item in lisRolesf)                
                    DbContext.RolePessoa.Remove(item);
                

                foreach (var pf in pessoa.Funcao)
                {
                    DbContext.RolePessoa.Add(new RolePessoa
                    {
                        CreatedIn = DateTime.Now,
                        Cpf = pessoa.Cpf,
                        Role = pf
                    });
                }
            }

            DbContext.Pessoa.Update(p[0]);
            DbContext.SaveChanges();

            return pessoa.Id;
        }

        public async Task<int> Excluir(int id)
        {
            if (id <= 0) return 0;

            var p = DbContext.Pessoa.Find(id);

            if (p == null) return 0;


            DbContext.Pessoa.Remove(p);
            DbContext.SaveChanges();

            return p.Id;

        }

        public async Task<List<Pessoa>> Obter(int id = 0)
        {

            if (id > 0)
            {
                var listaPessoa = new List<Pessoa>();
                var p =  DbContext.Pessoa?.Where(x => x.Id == id)
                    .Include(x => x.Endereco)                    
                    .FirstOrDefault();

                if (p != null)
                {
                    p.Funcao = Funcoes.GetListaFuncoes(
                        DbContext.RolePessoa
                        .Where(x => x.Cpf == p.Cpf)
                        .Select(y => y.Role).ToArray()
                        );

                    listaPessoa.Add(p);
                }                
                return listaPessoa;

            }

            var listaPessoas = DbContext.Pessoa?.OrderBy(x => x.Nome).ToList();

            foreach (var pe in listaPessoas)
            {

                if (pe != null)
                {
                    pe.Funcao = Funcoes.GetListaFuncoes(
                        DbContext.RolePessoa
                        .Where(x => x.Cpf == pe.Cpf)
                        .Select(y => y.Role).ToArray()
                        );
                }
            }

            return DbContext.Pessoa?.OrderBy(x => x.Nome).ToList();
        }

        public async Task<List<Pessoa>> ObterDocOuNome(string docOuNome)
        {
            var listaPessoa = new List<Pessoa>();
            if (!string.IsNullOrEmpty(docOuNome))
            {
                listaPessoa = DbContext.Pessoa?.Where(x => x.Cpf == docOuNome || x.Nome.ToLower().Contains(docOuNome))
                    .Include(x => x.Endereco)
                    .ToList();                             
            }

            return listaPessoa != null ? listaPessoa : default;

        }
    }
}
