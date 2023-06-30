using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_X.Domain.Dto;
using Project_X.Domain.Entities.Shared;
using Project_X.Domain.ViewModel;
using Project_X.Interface.Domain;
using Project_X.Interface.Services;
using Project_X.Sevice.Services;

namespace Project_X.WebAPI.Controllers.Security
{
    [ApiController]
    [Route("[Controller]")]    
    public class AutenticacaoController : ApiBaseController
    {
        public AutenticacaoController(IServiceProvider serviceProvider, INotificationsService notifications) : base(serviceProvider, notifications)
        {
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<ReturnAPI<LoginViewModel>>> AuthJWT([FromBody] UsuarioLoginDto dto)
        {
            var userLogin = await GetService<IAutenticacaoServico>().GetToken(dto);

            return EnviarResposta(userLogin);       
        }

       
        [HttpPost]
        [Route("Cadastro")]
        [Authorize(Policy = "RequireAdmRole")]
        public async Task<ActionResult<ReturnAPI<LoginViewModel>>> Create([FromBody] UsuarioLoginDto dto)
        {
            var userLogin = await GetService<IAutenticacaoServico>().CadastroUsuarioLogin(HttpContext.Request.Headers.Authorization.ToString(), dto);           

            return EnviarResposta(userLogin);
        }
    }
}
