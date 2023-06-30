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
    public class PacienteController : ApiBaseController
    {
        public PacienteController(IServiceProvider serviceProvider, INotificationsService notification) : base(serviceProvider, notification)
        {
        }



        [HttpPost]
        [Route("Cadastro")]
        public async Task<ActionResult<ReturnAPI<int>>> Criar([FromBody] PacienteDto dto)
        {
            return EnviarResposta(await GetService<IPacienteServico>().Cadastro(dto));

        }

        [HttpGet]
        [Route("Obter/{id?}")]
        public async Task<ActionResult<ReturnAPI<List<Paciente>>>> Obter(int id)
        {
            return EnviarResposta(await GetService<IPacienteServico>().Obter(id));

        }

        [HttpDelete]
        [Route("Excluir/{id}")]
        public async Task<ActionResult<ReturnAPI<int>>> Excluir(int id)
        {
            return EnviarResposta(await GetService<IPacienteServico>().Excluir(id));

        }

        [HttpPut]
        [Route("Editar")]
        public async Task<ActionResult<ReturnAPI<int>>> Editar([FromBody] PacienteDto dto)
        {
            return EnviarResposta(await GetService<IPacienteServico>().Editar(dto));

        }
    }
}
