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
    public class ConsultaController : ApiBaseController
    {
        public ConsultaController(IServiceProvider serviceProvider, INotificationsService notification) : base(serviceProvider, notification)
        {
        }


        [HttpPost]
        [Route("Cadastro")]
        public async Task<ActionResult<ReturnAPI<int>>> Criar([FromBody] ConsultaDto dto)
        {
            return EnviarResposta(await GetService<IConsultaServico>().Cadastro(dto));

        }

        [HttpGet]
        [Route("Obter/{id?}")]
        public async Task<ActionResult<ReturnAPI<List<Consulta>>>> Obter(int id)
        {
            return EnviarResposta(await GetService<IConsultaServico>().Obter(id));

        }

        [HttpGet]
        [Route("ObterPorDocumento")]
        public async Task<ActionResult<ReturnAPI<List<Consulta>>>> ObterPorDoc([FromQuery]string doc)
        {
            return EnviarResposta(await GetService<IConsultaServico>().ObterPorDoc(doc));

        }

        [HttpDelete]
        [Route("Excluir/{id}")]
        public async Task<ActionResult<ReturnAPI<int>>> Excluir(int id)
        {
            return EnviarResposta(await GetService<IConsultaServico>().Excluir(id));

        }

        [HttpPut]
        [Route("Editar")]
        public async Task<ActionResult<ReturnAPI<int>>> Editar([FromBody] ConsultaDto dto)
        {
            return EnviarResposta(await GetService<IConsultaServico>().Editar(dto));

        }
    }
}
