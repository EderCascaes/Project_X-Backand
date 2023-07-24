using Project_X.Domain.Dto;
using Project_X.Domain.Entities;
using Project_X.Domain.Notifications;
using Project_X.Domain.Static;
using Project_X.Interface.Domain;
using Project_X.Interface.Repositories;
using Project_X.Interface.Services;
using System;

namespace Project_X.Sevice.Services
{
    public class ConsultaServico : IConsultaServico
    {
        private readonly IConsultaRepositorio _consultaRepositorio;
        private readonly INotificationsService _notifications;
        public ConsultaServico(IConsultaRepositorio consultaRepositorio, INotificationsService notifications)
        {
            _consultaRepositorio = consultaRepositorio;
            _notifications = notifications;
        }

        public async Task<int> Cadastro(ConsultaDto consulta)
        {            try
            {
                var validaConsulta = await ValidadaConsulta();
                if (validaConsulta == false)
                    return default;

                var data = DateTime.Parse(consulta.Data.ToString("dd/MM/yyyy 23:00:00-03"));              

                return await _consultaRepositorio.Cadastro(new Consulta(
                 data,
                 consulta.Hora,
                 consulta.Descricao,
                 consulta.IdFisioterpeuta,
                 consulta.IdPaciente
             ));

            }
            catch (Exception ex)
            {
                _notifications.Add(new ApiNotifications("Erro ao cadastrar consulta : " + ex.Message));
                return default;
            }

            #region SubMetodo

            async Task<bool> ValidadaConsulta()
            {
                var data = DateTime.Parse(consulta.Data.ToString("dd/MM/yyyy 23:00:00-03"));
                bool v = true;
                var consultaAgendadasFisioterapeuta = await ObterValidaConsulta(data , consulta.Hora, consulta.IdFisioterpeuta, 0);
                var consultaAgendadasPaciente = await ObterValidaConsulta(data , consulta.Hora, 0, consulta.IdPaciente);

                
                    if (consultaAgendadasFisioterapeuta != null 
                        && consultaAgendadasFisioterapeuta.Data.ToString("dd/MM/yyyy") == consulta.Data.ToString("dd/MM/yyyy") 
                        && consultaAgendadasFisioterapeuta.Hora == consulta.Hora 
                        && consultaAgendadasFisioterapeuta.IdFisioterpeuta == consulta.IdFisioterpeuta)
                    {
                        v = false;
                        _notifications.Add(new ApiNotifications("Este Fisioterapeuda tem consulta agendada para essa Data neste horário "));
                    }                 
                
                     if (consultaAgendadasPaciente != null 
                        && consultaAgendadasPaciente.Data.ToString("dd/MM/yyyy") == consulta.Data.ToString("dd/MM/yyyy") 
                        && consultaAgendadasPaciente.Hora == consulta.Hora 
                        && consultaAgendadasPaciente.IdPaciente == consulta.IdPaciente)
                    {
                        v = false;
                        _notifications.Add(new ApiNotifications("Este Paciente tem consulta agendada para essa Data neste horário "));
                    }                

                return v == true ? true : false;
            }


            #endregion
        }

        public async Task<int> Editar(ConsultaDto consulta)
        {
            try
            {
                return await _consultaRepositorio.Editar(new Consulta(
                    consulta.Data,
                    consulta.Hora,
                    consulta.Descricao,
                    consulta.IdFisioterpeuta,
                    consulta.IdPaciente,
                    consulta.Id
                ));
            }
            catch (Exception ex)
            {
                _notifications.Add(new ApiNotifications("Erro ao Editar consulta : " + ex.Message));
                return default;
            }
        }

        public async Task<int> Excluir(int id)
        {
            try
            {
                return await _consultaRepositorio.Excluir(id);
            }
            catch (Exception ex)
            {
                _notifications.Add(new ApiNotifications("Erro ao excluir consulta : " + ex.Message));
                return default;
            }
        }

        public async Task<List<Consulta>> Obter(int id = 0)
        {
            try
            {
                return await _consultaRepositorio.Obter(id);
            }
            catch (Exception ex)
            {
                _notifications.Add(new ApiNotifications("Erro ao obter consulta : " + ex.Message));
                return default;
            }
        }

        public async Task<List<Consulta>> ObterPorDoc(string doc)
        {
            try
            {
                var d = doc.RetornaNumeros();

                return await _consultaRepositorio.ObterPorDoc(d);
            }
            catch (Exception ex)
            {
                _notifications.Add(new ApiNotifications($"Erro ao obter consulta(s) do CPF : {doc} " + ex.Message));
                return default;
            }
        }



        public async Task<Consulta> ObterValidaConsulta(DateTime data, string hora, int idFisioterapeuta = 0, int idPaciente = 0)
        {
            try
            {
                return await _consultaRepositorio.ObterValidaConsulta(data, hora,  idFisioterapeuta, idPaciente);
            }
            catch (Exception ex)
            {
                _notifications.Add(new ApiNotifications($"Erro ao valkidar consulta(s)  : " + ex.Message));

                return default;
            }
        }
    }
}
