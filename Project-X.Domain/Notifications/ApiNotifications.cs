using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_X.Domain.Notifications
{
    public class ApiNotifications : INotification
    {
        public ApiNotifications(string message, bool itIsException = true)
        {
            Message = message;
            ItIsException = itIsException;

        }

        public string Message { get; private set; }
        public bool ItIsException { get; private set; }


    }
}