using Project_X.Domain.Dto;
using Project_X.Domain.Entities;

namespace Project_X.Interface.Repositories
{
    public interface IFisioterapiaRepositorio
    {
        Task<int> Cadastro(Fisioterapia fisioterapia);
        Task<int> Editar(Fisioterapia fisioterapia);
        Task<int> Excluir(int id);
        Task<List<Fisioterapia>> Obter(int id = 0);
        Task<List<Fisioterapia>> ObterPorDoc(string docOuNome);
    }
}
