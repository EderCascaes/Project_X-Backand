using Microsoft.AspNetCore.Mvc;
using Project_X.Domain.Dto;
using Project_X.Domain.Entities;
using Project_X.Domain.Entities.Shared;
using Project_X.Interface.Domain;
using Project_X.Interface.Services;

namespace Project_X.WebAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class EnderecoController : ApiBaseController
    {
        
        public EnderecoController(IServiceProvider serviceProvider, INotificationsService notification) : base(serviceProvider, notification)
        {
        }


        [HttpPost]
        [Route("Cadastro")]
        public async Task<ActionResult<ReturnAPI<int>>> Criar([FromBody] EnderecoDto dto)
        {
            return EnviarResposta(await GetService<IEnderecoServico>().Cadastro(dto));

        }

        [HttpGet]
        [Route("Obter/{id?}")]
        public async Task<ActionResult<ReturnAPI<List<Endereco>>>> Obter(int id)
        {
            return EnviarResposta(await GetService<IEnderecoServico>().Obter(id));

        }

        [HttpDelete]
        [Route("Excluir/{id}")]
        public async Task<ActionResult<ReturnAPI<int>>> Excluir(int id)
        {
            return EnviarResposta(await GetService<IEnderecoServico>().Excluir(id));

        }

        [HttpPut]
        [Route("Editar")]
        public async Task<ActionResult<ReturnAPI<int>>> Editar([FromBody] EnderecoDto dto)
        {
            return EnviarResposta(await GetService<IEnderecoServico>().Editar(dto));

        }

        [HttpGet]
        [Route("ObterEnderecoPorCep/{cep}")]
        public async Task<ActionResult<ReturnAPI<EnderecoDto?>>> ObterEnderecoPorCep(string cep)
        {
            return EnviarResposta(await GetService<IEnderecoServico>().ObterEnderecoPorCep(cep));

        }
    }
}
