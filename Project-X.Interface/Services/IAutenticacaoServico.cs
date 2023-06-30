using Project_X.Domain.Dto;
using Project_X.Domain.Entities;
using Project_X.Domain.Entities.Shared;
using Project_X.Domain.ViewModel;

namespace Project_X.Interface.Services
{
    public interface IAutenticacaoServico
    {
        // Task<UserViewModel> Auth(UserLoginDto dto);
        Task<LoginViewModel> GetToken(UsuarioLoginDto dto);
        Task<LoginViewModel> CadastroUsuarioLogin(string token, UsuarioLoginDto dto);
    }
}
