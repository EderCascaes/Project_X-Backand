using Project_X.Domain.Entities;

namespace Project_X.Interface.Repositories
{
    public interface IConsultaRepositorio
    {
        Task<int> Cadastro(Consulta consulta);
        Task<int> Editar(Consulta consulta);
        Task<int> Excluir(int id);
        Task<List<Consulta>> Obter(int id = 0);
        Task<List<Consulta>> ObterPorDoc(string doc);
        Task<Consulta> ObterValidaConsulta(DateTime data,string hora, int idFisioterapeuta = 0, int idPaciente = 0);
    }
}
