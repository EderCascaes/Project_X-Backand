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
    public class FisioterapeutaController : ApiBaseController
    {
        public FisioterapeutaController(IServiceProvider serviceProvider, INotificationsService notification) : base(serviceProvider, notification)
        {
        }


        [HttpPost]
        [Route("Cadastro")]
        public async Task<ActionResult<ReturnAPI<int>>> Criar([FromBody] FisioterapeutaDto dto)
        {
            return EnviarResposta(await GetService<IFisioterapeutaServico>().Cadastro(dto));

        }

        [HttpGet]
        [Route("Obter/{id?}")]
        public async Task<ActionResult<ReturnAPI<List<Fisioterapeuta>>>> Obter(int id)
        {
            return EnviarResposta(await GetService<IFisioterapeutaServico>().Obter(id));

        }

        [HttpDelete]
        [Route("Excluir/{id}")]
        public async Task<ActionResult<ReturnAPI<int>>> Excluir(int id)
        {
            return EnviarResposta(await GetService<IFisioterapeutaServico>().Excluir(id));

        }

        [HttpPut]
        [Route("Editar")]
        public async Task<ActionResult<ReturnAPI<int>>> Editar([FromBody] FisioterapeutaDto dto)
        {
            return EnviarResposta(await GetService<IFisioterapeutaServico>().Editar(dto));

        }
    }
}
