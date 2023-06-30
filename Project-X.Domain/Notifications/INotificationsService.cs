using Project_X.Domain.Notifications;

namespace Project_X.Interface.Domain
{
    public interface INotificationsService
    {
        bool ContainsNotification { get; }

        bool ContainsExceptions { get; } 
        
        IReadOnlyCollection<ApiNotifications> ListNotifications { get;  }

        void Add(ApiNotifications notification);
    }
}
