using Project_X.Domain.Entities;

namespace Project_X.Interface.Repositories
{
    public interface IPacienteRepositorio
    {
        Task<int> Cadastro(Paciente paciente);
        Task<int> Editar(Paciente pacientea);
        Task<int> Excluir(int id);
        Task<List<Paciente>> Obter(int id = 0);
    }
}
