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
                         dto.Telefone.RetornaNumeros(),
                         DateTime.Parse(dto.DataNascimento),
                         dto.Cpf.RetornaNumeros(),
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
                         DateTime.Parse(dto.DataNascimento),
                         dto.Cpf.RetornaNumeros(),
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

        public async Task<List<PessoaDto>> Obter(int id = 0)
        {
            try
            {
                var listaPessoaDto = new List<PessoaDto>();
                var listaPessoa = await _pessoaRepositorio.Obter(id);

                if(listaPessoa.Count > 0)
                    foreach (var pessoa in listaPessoa)
                    {
                        var p = new PessoaDto(
                              pessoa.Id,
                              pessoa.Nome,
                              pessoa.Email,
                              pessoa.Telefone,
                              pessoa.DataNascimento,
                              pessoa.Cpf,
                              pessoa.IdEndereco,
                              pessoa.Funcao
                            );

                        listaPessoaDto.Add( p );
                    }

                return listaPessoaDto;
            }
            catch (Exception ex)
            {
                _notifications.Add(new ApiNotifications("Erro ao obter pessoa : " + ex.Message));
                return default;
            }
        }
        
        public async Task<List<PessoaDto>> ObterPorDocOuNome(string docOuNome)
        {
            try
            {
                var listaPessoaDto = new List<PessoaDto>();
                var listaPessoa = await _pessoaRepositorio.ObterDocOuNome(docOuNome);

                if (listaPessoa.Count > 0)
                    foreach (var pessoa in listaPessoa)
                    {
                        var p = new PessoaDto(
                              pessoa.Id,
                              pessoa.Nome,
                              pessoa.Email,
                              pessoa.Telefone,
                              pessoa.DataNascimento,
                              pessoa.Cpf,
                              pessoa.IdEndereco,
                              pessoa.Funcao
                            );

                        listaPessoaDto.Add(p);
                    }

                return listaPessoaDto;

            }
            catch (Exception ex)
            {
                _notifications.Add(new ApiNotifications("Erro ao obter pessoa : " + ex.Message));
                return default;
            }
        }
    }
}
