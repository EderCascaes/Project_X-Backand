using Microsoft.AspNetCore.Mvc;
using Project_X.Domain.Entities.Shared;
using Project_X.Domain.Entities;
using Project_X.Interface.Domain;
using Project_X.Interface.Services;
using Project_X.Domain.Static;
using Project_X.Domain.Dto;

namespace Project_X.WebAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PessoaController : ApiBaseController
    {
        public PessoaController(IServiceProvider serviceProvider, INotificationsService notification) : base(serviceProvider, notification)
        {
        }


        [HttpPost]
        [Route("Cadastro")]
        public async Task<ActionResult<ReturnAPI<int>>> Criar([FromBody]PessoaDto dto)
        {
            return EnviarResposta(await GetService<IPessoaServico>().Cadastro(dto));

        }

        [HttpGet]
        [Route("Obter/{id?}")]
        public async Task<ActionResult<ReturnAPI<List<Pessoa>>>> Obter(int id)
        {
            return EnviarResposta(await GetService<IPessoaServico>().Obter(id));

        }

        [HttpGet]
        [Route("docOuNome")]
        public async Task<ActionResult<ReturnAPI<List<Pessoa>>>> ObterPorDocOuNome([FromQuery]string docOuNome)
        {
            return EnviarResposta(await GetService<IPessoaServico>().ObterPorDocOuNome(docOuNome));

        }

        [HttpDelete]
        [Route("Excluir/{id}")]
        public async Task<ActionResult<ReturnAPI<int>>> Excluir(int id)
        {
            return EnviarResposta(await GetService<IPessoaServico>().Excluir(id));

        }

        [HttpPut]
        [Route("Editar")]
        public async Task<ActionResult<ReturnAPI<int>>> Editar([FromBody] PessoaDto dto)
        {
            return EnviarResposta(await GetService<IPessoaServico>().Editar(dto));

        }

    }
}
