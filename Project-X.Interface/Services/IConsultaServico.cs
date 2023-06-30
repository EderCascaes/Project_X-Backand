using Project_X.Domain.Dto;
using Project_X.Domain.Entities;

namespace Project_X.Interface.Services
{
    public  interface IConsultaServico
    {
        Task<int> Cadastro(ConsultaDto dto);
        Task<int> Editar(ConsultaDto dto);
        Task<int> Excluir(int id);
        Task<List<Consulta>> Obter(int id = 0);
        Task<List<Consulta>> ObterPorDoc(string doc);
        Task<Consulta> ObterValidaConsulta(DateTime data, string hora, int idFisioterapeuta = 0, int idPaciente = 0);
    }
}
