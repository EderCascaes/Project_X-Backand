using Project_X.Domain.Entities;
using Project_X.Domain.Notifications;
using Project_X.Interface.Domain;
using Project_X.Interface.Repositories;
using Project_X.Interface.Services;
using Project_X.Domain.Static;
using Project_X.Domain.Dto;

namespace Project_X.Sevice.Services
{
    public class FisioterapiaServico : IFisioterapiaServico
    {
        private readonly IFisioterapiaRepositorio _fisioterapiaRepositorio;
        private readonly INotificationsService _notifications;
        public FisioterapiaServico(IFisioterapiaRepositorio fisioterapiaRepositorio, INotificationsService notifications)
        {
            _fisioterapiaRepositorio = fisioterapiaRepositorio;
            _notifications = notifications;
        }

        public async Task<int> Cadastro(FisioterapiaDto fisioterapia)
        {
            try
            {
                    return await _fisioterapiaRepositorio.Cadastro(new Fisioterapia(
                        fisioterapia.DataInicio,
                        fisioterapia.Hora,
                        fisioterapia.DataFim,
                        fisioterapia.Procedimento,
                        fisioterapia.IdFisioterapeuta,
                        fisioterapia.IdPaciente,
                        fisioterapia.Quantidade,
                        fisioterapia.QtdRealizadas,
                        fisioterapia.Progresso
                        ));              

            }
            catch (Exception ex)
            {
                _notifications.Add(new ApiNotifications("Erro ao cadastrar fisioterapia : " + ex.Message));

                return default;

            }

        }

        public async Task<int> Editar(FisioterapiaDto fisioterapia)
        {
            try
            {
                return await _fisioterapiaRepositorio.Editar(new Fisioterapia(
                        fisioterapia.DataInicio,
                        fisioterapia.Hora,
                        fisioterapia.DataFim,
                        fisioterapia.Procedimento,
                        fisioterapia.IdFisioterapeuta,
                        fisioterapia.IdPaciente,
                        fisioterapia.Quantidade,
                        fisioterapia.QtdRealizadas,
                        fisioterapia.Progresso,
                        fisioterapia.Id
                        ));
            }
            catch (Exception ex)
            {
                _notifications.Add(new ApiNotifications("Erro ao Editar fisioterapia : " + ex.Message));
                return default;
            }
        }

        public async Task<int> Excluir(int id)
        {
            try
            {
                return await _fisioterapiaRepositorio.Excluir(id);
            }
            catch (Exception ex)
            {
                _notifications.Add(new ApiNotifications("Erro ao excluir fisioterapia : " + ex.Message));
                return default;
            }
        }

        public async Task<List<Fisioterapia>> Obter(int id = 0)
        {
            try
            {
                return await _fisioterapiaRepositorio.Obter(id);
            }
            catch (Exception ex)
            {
                _notifications.Add(new ApiNotifications("Erro ao obter fisioterapia : " + ex.Message));
                return default;
            }
        }

        public async Task<List<Fisioterapia>> ObterPorDoc(string doc)
        {
            try
            {
                var d = doc.RetornaNumeros();

                return await _fisioterapiaRepositorio.ObterPorDoc(d);
            }
            catch (Exception ex)
            {
                _notifications.Add(new ApiNotifications($"Erro ao obter fisioterapia(s) do CPF : {doc} " + ex.Message));
                return default;
            }
        }


    }
}
