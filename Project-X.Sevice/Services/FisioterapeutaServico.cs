using Project_X.Domain.Dto;
using Project_X.Domain.Entities;
using Project_X.Domain.Notifications;
using Project_X.Interface.Domain;
using Project_X.Interface.Repositories;
using Project_X.Interface.Services;

namespace Project_X.Sevice.Services
{
    public class FisioterapeutaServico : IFisioterapeutaServico
    {
        private readonly IFisioterapeutaRepositorio _fisioterapeutaRepositorio;
        private readonly INotificationsService _notifications;
        public FisioterapeutaServico(IFisioterapeutaRepositorio fisioterapeutaRepositorio, INotificationsService notifications)
        {
            _fisioterapeutaRepositorio = fisioterapeutaRepositorio;
            _notifications = notifications;
        }

        public async Task<int> Cadastro(FisioterapeutaDto fisioterapeuta)
        {
            try
            {
               
                    return await _fisioterapeutaRepositorio.Cadastro(new Fisioterapeuta
                    {
                        CREFITO = fisioterapeuta.CREFITO,
                        IdPessoa = fisioterapeuta.IdPessoa
                    });              

            }
            catch (Exception ex)
            {
                _notifications.Add(new ApiNotifications("Erro ao cadastrar Fisioterapeuta : " + ex.Message));

                return default;

            }

        }

        public async Task<int> Editar(FisioterapeutaDto fisioterapeuta)
        {
            try
            {
                return await _fisioterapeutaRepositorio.Editar(new Fisioterapeuta
                {
                    CREFITO = fisioterapeuta.CREFITO,
                    IdPessoa = fisioterapeuta.IdPessoa
                });
            }
            catch (Exception ex)
            {
                _notifications.Add(new ApiNotifications("Erro ao Editar fisioterapeuta : " + ex.Message));
                return default;
            }
        }

        public async Task<int> Excluir(int id)
        {
            try
            {
                return await _fisioterapeutaRepositorio.Excluir(id);
            }
            catch (Exception ex)
            {
                _notifications.Add(new ApiNotifications("Erro ao excluir fisioterapeuta : " + ex.Message));
                return default;
            }
        }

        public async Task<List<Fisioterapeuta>> Obter(int id = 0)
        {
            try
            {
                return await _fisioterapeutaRepositorio.Obter(id);
            }
            catch (Exception ex)
            {
                _notifications.Add(new ApiNotifications("Erro ao obter fisioterapeuta : " + ex.Message));
                return default;
            }
        }
    }
}
