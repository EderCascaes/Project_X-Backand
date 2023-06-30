using Project_X.Interface.Domain;
using Project_X.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_X.Repository.Repositories
{
    public class BaseRepositorio
    {
        protected const int TamanhoPagina = 5;

        protected readonly ApplicationDbContext DbContext;
        protected readonly INotificationsService Notifications;

        public BaseRepositorio(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;

        }
    }
}
