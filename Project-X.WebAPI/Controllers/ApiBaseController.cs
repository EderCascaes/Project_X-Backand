using Microsoft.AspNetCore.Mvc;
using Project_X.Domain.Entities.Shared;
using Project_X.Interface.Domain;

namespace Project_X.WebAPI.Controllers
{
    public abstract class ApiBaseController : ControllerBase
    {
        protected readonly IServiceProvider ServiceProvider;
        protected readonly IConfiguration Configuration;
        protected readonly INotificationsService Notifications;
        protected T GetService<T>()
        {
            return ServiceProvider.GetService<T>();
        }


        public ApiBaseController(IServiceProvider serviceProvider, INotificationsService notification )
        {
            ServiceProvider = serviceProvider;
            Notifications = notification;
        }

        protected bool ContemNotificacao { get => Notifications.ContainsNotification; }
        protected bool ContemExecoes { get => Notifications.ContainsExceptions; }

     

        protected ActionResult<ReturnAPI<T?>> EnviarResposta<T>(T? obj) where T : new()
        {

            if (ContemNotificacao)
            {
                if (ContemExecoes)
                    return BadRequest(new ReturnAPI<T>()
                    {

                        Successful = false,
                        Notifications = Notifications.ListNotifications

                    });
                else
                    return Ok(new ReturnAPI<T>()
                    {
                        Notifications = Notifications.ListNotifications,
                        Response = obj

                    });
            }
            else            
                return Ok(new ReturnAPI<T>()
                {
                    Notifications = Notifications.ListNotifications,
                    Response = obj

                });

            
        }



        

        protected ActionResult<ReturnAPI<object>> SemResposta()
        {
            if (ContemNotificacao)
            {
                if (ContemExecoes)
                    return BadRequest(new ReturnAPI<object>()
                    {
                        Successful = false,
                        Notifications = Notifications.ListNotifications

                    });
                else
                    return Ok(new ReturnAPI<object>()
                    {
                        Notifications = Notifications.ListNotifications

                    });

            }

            return Ok(new ReturnAPI<object>() { });

        }


    }
}
