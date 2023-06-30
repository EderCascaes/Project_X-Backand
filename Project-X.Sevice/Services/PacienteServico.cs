using Project_X.Domain.Dto;
using Project_X.Domain.Entities;
using Project_X.Domain.Notifications;
using Project_X.Interface.Domain;
using Project_X.Interface.Repositories;
using Project_X.Interface.Services;

namespace Project_X.Sevice.Services
{
    public class PacienteServico : IPacienteServico
    {
        private readonly IPacienteRepositorio _pacienteRepositorio;
        private readonly INotificationsService _notifications;
        public PacienteServico(IPacienteRepositorio pacienteRepositorio, INotificationsService notifications)
        {
            _pacienteRepositorio = pacienteRepositorio;
            _notifications = notifications;
        }

        public async Task<int> Cadastro(PacienteDto paciente)
        {
            try
            {
                    return await _pacienteRepositorio.Cadastro(new Paciente { IdPessoa = paciente.IdPessoa});              

            }
            catch (Exception ex)
            {
                _notifications.Add(new ApiNotifications("Erro ao cadastrar paciente : " + ex.Message));

                return default;

            }

        }

        public Task<int> Editar(PacienteDto paciente)
        {
            try
            {
                return _pacienteRepositorio.Editar(new Paciente { IdPessoa = paciente.IdPessoa });
            }
            catch (Exception ex)
            {
                _notifications.Add(new ApiNotifications("Erro ao Editar paciente : " + ex.Message));
                return default;
            }
        }

        public Task<int> Excluir(int id)
        {
            try
            {
                return _pacienteRepositorio.Excluir(id);
            }
            catch (Exception ex)
            {
                _notifications.Add(new ApiNotifications("Erro ao excluir pacirente : " + ex.Message));
                return default;
            }
        }

        public Task<List<Paciente>> Obter(int id = 0)
        {
            try
            {
                return _pacienteRepositorio.Obter(id);
            }
            catch (Exception ex)
            {
                _notifications.Add(new ApiNotifications("Erro ao obter paciente : " + ex.Message));
                return default;
            }
        }
    }
}
