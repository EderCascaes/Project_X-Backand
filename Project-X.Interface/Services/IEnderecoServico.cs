using Project_X.Domain.Dto;
using Project_X.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_X.Interface.Services
{
    public interface IEnderecoServico
    {
        Task<int> Cadastro(EnderecoDto dto);
        Task<int> Editar(EnderecoDto dto);
        Task<int> Excluir(int id);
        Task<List<Endereco>> Obter(int id = 0);
        Task<EnderecoDto> ObterEnderecoPorCep(string cep);
    }
}
