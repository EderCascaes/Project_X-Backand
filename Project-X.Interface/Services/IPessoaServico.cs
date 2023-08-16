using Project_X.Domain.Dto;
using Project_X.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_X.Interface.Services
{
    public interface IPessoaServico
    {
        Task<int> Cadastro(PessoaDto dto);
        Task<int> Editar(PessoaDto dto);
        Task<int> Excluir(int id);
        Task<List<PessoaDto>> Obter(int id = 0);
        Task<List<PessoaDto>> ObterPorDocOuNome(string docOunome);
    }
}
