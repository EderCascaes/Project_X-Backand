using Project_X.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_X.Interface.Repositories
{
    public interface IEnderecoRepositorio
    {
        Task<int> Cadastro(Endereco endereco);
        Task<int> Editar(Endereco endereco);
        Task<int> Excluir(int id);
        Task<List<Endereco>> Obter(int id = 0);
    }
}
