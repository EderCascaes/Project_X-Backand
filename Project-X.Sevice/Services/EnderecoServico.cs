using Project_X.Domain.Dto;
using Project_X.Domain.Entities;
using Project_X.Domain.Notifications;
using Project_X.Interface.Domain;
using Project_X.Interface.Repositories;
using Project_X.Interface.Services;
using Correios;

namespace Project_X.Sevice.Services
{
    public class EnderecoServico : IEnderecoServico
    {
        private readonly IEnderecoRepositorio _enderecoRepositorio;
        private readonly INotificationsService _notifications;
        public EnderecoServico(IEnderecoRepositorio enderecoRepositorio, INotificationsService notifications)
        {
            _enderecoRepositorio = enderecoRepositorio;
            _notifications = notifications;
        }



        public Task<int> Cadastro(EnderecoDto dto)
        {
            try
            {
                if (dto != null)
                    return _enderecoRepositorio.Cadastro(new Endereco
                    {
                        CEP = dto.CEP,
                        Cidade = dto.Cidade,
                        Complemento = dto.Complemento,
                        Bairro = dto.Bairro,
                        Estado = dto.Estado,
                        Logradouro = dto.Logradouro,
                        Numero = dto.Numero,
                    });

                _notifications.Add(new ApiNotifications("Erro ao cadastrar endereço : " ));

                return default;
            }
            catch (Exception ex)
            {
                _notifications.Add(new ApiNotifications("Erro ao cadastrar endereço : " + ex.Message));

                return default;

            }

        }

        public Task<int> Editar(EnderecoDto dto)
        {
            try
            {
                if (dto != null)
                    return _enderecoRepositorio.Editar(new Endereco
                    {
                        CEP = dto.CEP,
                        Cidade = dto.Cidade,
                        Complemento = dto.Complemento,
                        Bairro = dto.Bairro,
                        Estado = dto.Estado,
                        Logradouro = dto.Logradouro,
                        Numero = dto.Numero,
                    });

                _notifications.Add(new ApiNotifications("Erro ao editar endereço : "));

                return default;
            }
            catch (Exception ex)
            {
                _notifications.Add(new ApiNotifications("Erro ao Editar endereço : " + ex.Message));
                return default;
            }
        }

        public Task<int> Excluir(int id)
        {
            try
            {
                return _enderecoRepositorio.Excluir(id);
            }
            catch (Exception ex)
            {
                _notifications.Add(new ApiNotifications("Erro ao excluir endereço : " + ex.Message));
                return default;
            }
        }

        public Task<List<Endereco>> Obter(int id = 0)
        {
            try
            {
                return _enderecoRepositorio.Obter(id);
            }
            catch (Exception ex)
            {
                _notifications.Add(new ApiNotifications("Erro ao obter endereço : " + ex.Message));
                return default;
            }
        }

        public async Task<EnderecoDto> ObterEnderecoPorCep(string cep)
        {
            try
            {
                var endereco = new EnderecoDto();

                var enderecos = new Correios.NET.CorreiosService().GetAddresses(cep);

                foreach (var end in enderecos) 
                {
                    endereco.Logradouro = end.Street;
                    endereco.Bairro = end.District;
                    endereco.Cidade = end.City;
                    endereco.Estado = end.State;                 

                };

                return  endereco;
              
            }
            catch (Exception ex)
            {
                _notifications.Add(new ApiNotifications("Erro obter endereço  por cep: " + ex.Message));
                return default;
            }
        }
    }
}
