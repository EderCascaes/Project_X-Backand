using Project_X.Domain.Dto;
using Project_X.Domain.Entities;

namespace Project_X.Interface.Services
{
    public  interface IPacienteServico
    {
        Task<int> Cadastro(PacienteDto dto);
        Task<int> Editar(PacienteDto dto);
        Task<int> Excluir(int id);
        Task<List<Paciente>> Obter(int id = 0);
    }
}
