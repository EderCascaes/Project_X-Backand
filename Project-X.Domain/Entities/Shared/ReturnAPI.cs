using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_X.Domain.Notifications;

namespace Project_X.Domain.Entities.Shared
{
    public class ReturnAPI<T> where T : new()
    {

        public ReturnAPI()
        {
            Successful = true;
            Notifications = new List<ApiNotifications>();
        }

        public bool Successful { get; set; }
        public IEnumerable<ApiNotifications> Notifications { get; set; }

        public T? Response { get; set; }

    }

}
