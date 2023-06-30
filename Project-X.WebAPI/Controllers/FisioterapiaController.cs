using Microsoft.AspNetCore.Mvc;
using Project_X.Domain.Entities.Shared;
using Project_X.Domain.Entities;
using Project_X.Interface.Domain;
using Project_X.Interface.Services;
using Project_X.Domain.Dto;

namespace Project_X.WebAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class FisioterapiaController : ApiBaseController
    {

        public FisioterapiaController(IServiceProvider serviceProvider, INotificationsService notification) : base(serviceProvider, notification)
        {
        }


        [HttpPost]
        [Route("Cadastro")]
        public async Task<ActionResult<ReturnAPI<int>>> Criar([FromBody] FisioterapiaDto dto)
        {
            return EnviarResposta(await GetService<IFisioterapiaServico>().Cadastro(dto));

        }

        [HttpGet]
        [Route("Obter/{id?}")]
        public async Task<ActionResult<ReturnAPI<List<Fisioterapia>>>> Obter(int id)
        {
            return EnviarResposta(await GetService<IFisioterapiaServico>().Obter(id));

        }

        [HttpGet]
        [Route("ObterDocOuNome")]
        public async Task<ActionResult<ReturnAPI<List<Fisioterapia>>>> ObterPorDoc([FromQuery] string docOuNome)
        {
            return EnviarResposta(await GetService<IFisioterapiaServico>().ObterPorDoc(docOuNome));

        }

        [HttpDelete]
        [Route("Excluir/{id}")]
        public async Task<ActionResult<ReturnAPI<int>>> Excluir(int id)
        {
            return EnviarResposta(await GetService<IFisioterapiaServico>().Excluir(id));

        }

        [HttpPut]
        [Route("Editar")]
        public async Task<ActionResult<ReturnAPI<int>>> Editar([FromBody] FisioterapiaDto dto)
        {
            return EnviarResposta(await GetService<IFisioterapiaServico>().Editar(dto));

        }
    }
}
