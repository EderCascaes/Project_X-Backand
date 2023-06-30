using MediatR;
using Microsoft.Extensions.Configuration;
using Project_X.Domain.Dto;
using Project_X.Domain.Entities;
using Project_X.Domain.Enums;
using Project_X.Domain.Notifications;
using Project_X.Domain.ViewModel;
using Project_X.Interface.Domain;
using Project_X.Interface.Repositories;
using Project_X.Interface.Services;
using Project_X.Repository.Repositories;
using System.IdentityModel.Tokens.Jwt;
using static Project_X.Domain.Enums.TypeNotificationEnum;



namespace Project_X.Sevice.Services
{
    public class AutenticacaoServico : IAutenticacaoServico
    {
        private readonly IAutenticacaoRepositorio _autenticacaoRepositorio;
        private readonly ITokenService _tokenService;
        protected readonly IConfiguration _configuration;
        protected readonly IPasswordService _passwordSevice;
        private readonly IMediator _mediator;
        private readonly INotificationsService _notifications;
        private readonly ApiNotifications notification;

        public AutenticacaoServico(
            IAutenticacaoRepositorio autenticacaoRepositorio,
            IConfiguration configuration,
            ITokenService tokenService,
            IPasswordService passwordSevice,
            IMediator mediator,
            INotificationsService notifications)
        {
            _autenticacaoRepositorio = autenticacaoRepositorio;
            _passwordSevice = passwordSevice;
            _configuration = configuration;
            _tokenService = tokenService;
            _mediator = mediator;
            _notifications = notifications;
        }
        public IMediator IMediator => _mediator;

        public async Task<LoginViewModel> CadastroUsuarioLogin(string token, UsuarioLoginDto dto)
        {
            try
            {
                if (!ValidaClaim(token))
                {
                    _notifications.Add(new ApiNotifications("Somente administrador pode cadastrar usuario !!! "));
                    return default;
                }

                dto.Password = _passwordSevice.Codification(dto.Password);

                var lg = await _autenticacaoRepositorio.CriarUsuarioLogin(new UsuarioLogin
                {
                    CreatedIn = DateTime.Now,
                    Password = dto.Password,
                    Email = dto.Email,
                    IdPessoa = dto.IdPessoa
                });

                //await _mediator.Publish(new ApiNotifications("Usuário cadastrado !"), default);

                return new LoginViewModel()
                {
                    CreatedIn = lg.CreatedIn,
                    Email = lg.Email

                };


            }
            catch (Exception)
            {
                await _mediator.Publish(new ApiNotifications("Erro ao cadastrarvusuário !"), default);

                return default;
            }

            #region SubMetodos

            bool ValidaClaim(string token)
            {
                var t = token.Split(" ");
                string role = "role";
                try
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var securityToken = (JwtSecurityToken)tokenHandler.ReadToken(t[1]);
                    var claimValue = securityToken.Claims.FirstOrDefault(c => c.Type == role)?.Value;

                    var listClaim = claimValue?.Split(",");
                    var claim = listClaim.Contains(((int)eRoles.adm).ToString());

                    return claim;
                }
                catch (Exception)
                {
                    //TODO: Logger.Error
                    return false;
                }
            }
            #endregion

        }

        public async Task<LoginViewModel> GetToken(UsuarioLoginDto dto)
        {
            try
            {
                var usuariologin = new UsuarioLogin()
                {
                    CreatedIn = DateTime.Now,
                    Email = dto.Email,
                    Password = _passwordSevice.Codification(dto.Password),
                    IdPessoa = dto.IdPessoa
                };

                var usuario = await _autenticacaoRepositorio.Get(usuariologin);

                if (usuario != null)
                {
                    _notifications.Add(new ApiNotifications("Token Gerado com sucesso !", false));

                    return new LoginViewModel()
                    {
                        Token = _tokenService.GerarToken(
                                usuario.Email,
                                usuario.Pessoa.Funcao
                             ),
                        Email = usuario.Email,
                        CreatedIn = usuario.CreatedIn

                    };

                }
                else
                {
                    _notifications.Add(new ApiNotifications("Usuário ou senha inválido(s) ! "));
                    return default;
                }



            }
            catch (Exception e)
            {
                _notifications.Add(new ApiNotifications("Erro ao válidar usuário e senha : " + e.Message));

                return default;

            }


        }

    }
}
