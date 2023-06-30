using Project_X.Domain.Dto;
using Project_X.Domain.Entities;

namespace Project_X.Interface.Services
{
    public  interface IFisioterapiaServico
    {
        Task<int> Cadastro(FisioterapiaDto dto);
        Task<int> Editar(FisioterapiaDto dto);
        Task<int> Excluir(int id);
        Task<List<Fisioterapia>> Obter(int id = 0);
        Task<List<Fisioterapia>> ObterPorDoc(string doc);
    }
}
