using Project_X.Domain.Dto;
using Project_X.Domain.Entities;
using Project_X.Domain.Enums;
using Project_X.Domain.Notifications;
using Project_X.Domain.Static;
using Project_X.Interface.Domain;
using Project_X.Interface.Repositories;
using Project_X.Interface.Services;
using Project_X.Repository.Repositorios;

namespace Project_X.Sevice.Services
{
    public class PessoaServico : IPessoaServico
    {

        private readonly IPessoaRepositorio _pessoaRepositorio;
        private readonly INotificationsService _notifications;
        public PessoaServico(IPessoaRepositorio pessoaRepositorio, INotificationsService notifications)
        {
            _pessoaRepositorio = pessoaRepositorio;
            _notifications = notifications;
        }

        public async Task<int> Cadastro(PessoaDto dto)
        {
            try
            {
                if (dto != null && dto.Cpf.ValidaCpf())
                {
                    return await _pessoaRepositorio.Cadastro(new Pessoa(
                         dto.Nome,
                         dto.Email,
                         dto.Telefone,
                         dto.DataNascimento,
                         dto.Cpf.NumerosCpf(),
                         dto.IdEndereco,
                         dto.Funcao
                ));

                }
                else
                {
                    _notifications.Add(new ApiNotifications($"CPF inválido : {dto.Cpf} "));

                }

                return 0;

            }
            catch (Exception ex)
            {
                _notifications.Add(new ApiNotifications("Erro ao cadastrar pessoa : " + ex.Message));

                return default;

            }

        }

        public Task<int> Editar(PessoaDto dto)
        {
            try
            {         
                return _pessoaRepositorio.Editar(new Pessoa(
                         dto.Nome,
                         dto.Email,
                         dto.Telefone,
                         dto.DataNascimento,
                         dto.Cpf.NumerosCpf(),
                         dto.IdEndereco,
                         dto.Funcao,
                         dto.Id
                ));
            }
            catch (Exception ex)
            {
                _notifications.Add(new ApiNotifications("Erro ao Editar pessoa : " + ex.Message));
                return default;
            }
        }

        public Task<int> Excluir(int id)
        {
            try
            {
                return _pessoaRepositorio.Excluir(id);
            }
            catch (Exception ex)
            {
                _notifications.Add(new ApiNotifications("Erro ao excluir pessoa : " + ex.Message));
                return default;
            }
        }

        public Task<List<Pessoa>> Obter(int id = 0)
        {
            try
            {
                return _pessoaRepositorio.Obter(id);
            }
            catch (Exception ex)
            {
                _notifications.Add(new ApiNotifications("Erro ao obter pessoa : " + ex.Message));
                return default;
            }
        }
        
        public Task<List<Pessoa>> ObterPorDocOuNome(string docOuNome)
        {
            try
            {
                return _pessoaRepositorio.ObterDocOuNome(docOuNome);
            }
            catch (Exception ex)
            {
                _notifications.Add(new ApiNotifications("Erro ao obter pessoa : " + ex.Message));
                return default;
            }
        }
    }
}
