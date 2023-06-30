using Project_X.Domain.Entities.Shared;
using Project_X.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_X.Domain.ViewModel
{
    public class LoginViewModel : BaseDomain
    {
        public string Email { get; set; }
      //  public string Cpf { get; set; }
       // public string Email { get; set; }
        public string Token { get; set; }
       // public List<eRoles> Funcoes { get; set; }

    }
}

