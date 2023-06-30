﻿using Project_X.Domain.Dto;
using Project_X.Domain.Entities;
using Project_X.Domain.Notifications;
using Project_X.Interface.Domain;
using Project_X.Interface.Repositories;
using Project_X.Interface.Services;

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
    }
}
