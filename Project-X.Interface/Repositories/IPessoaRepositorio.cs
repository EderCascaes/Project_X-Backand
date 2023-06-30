using Project_X.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_X.Interface.Repositories
{
    public interface IPessoaRepositorio
    {
        Task<int> Cadastro(Pessoa pessoa);
        Task<int> Editar(Pessoa pessoa);
        Task<int> Excluir(int id);
        Task<List<Pessoa>> Obter(int id = 0);
        Task<List<Pessoa>> ObterDocOuNome(string docOuNome);
    }
}
