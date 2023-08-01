using Microsoft.AspNetCore.Mvc;
using Project_X.Interface.Domain;

namespace Project_X.WebAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AdmController : ApiBaseController
    {
        public AdmController(IServiceProvider serviceProvider, INotificationsService notification) : base(serviceProvider, notification)
        {
        }



    }
}
