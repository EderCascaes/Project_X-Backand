using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project_X.Domain.Enums.TypeNotificationEnum;


using MediatR;
using System.Data.SqlTypes;
using Project_X.Interface.Domain;
using Project_X.Domain.Notifications;

namespace Project_X.Domain.Entities.Shared
{
    public class NotificationsService: INotificationsService
    {
        public List<ApiNotifications> Notifications { get; set; } 

        public NotificationsService()
        {
            Notifications = new List<ApiNotifications>();

        }

        public bool ContainsNotification => ListNotifications.Any();

        public bool ContainsExceptions => ListNotifications.Any(x => x.ItIsException);

     
        public IReadOnlyCollection<ApiNotifications> ListNotifications => Notifications;

        public void Add(ApiNotifications notificacao)
        {
            Notifications.Add(notificacao);

        }

























        //private static List<Notification> Notifications = new List<Notification>();







/*

        public string Mensagem { get; set; }

        public TipoDeNotificacaoEnum TipoDeNotificacaoEnum { get; set; }

        public string DescricaoDoTipoDeNotificacao { get; set; }

        public bool ContainsExceptions => throw new NotImplementedException();*/



        /* public static List<Notification> AddNotifications(Notification notification)
         {
             Notifications.Add(notification);
             return Notifications.ToList();
         }

         public static List<Notification> GetNotifications()
         {
             var newList = new List<Notification>();
             newList.AddRange(Notifications);
             Notifications.Clear();

             return newList;
         }*/

    }
}
