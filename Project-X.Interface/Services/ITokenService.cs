using Project_X.Domain.Entities;
using Project_X.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_X.Interface.Services
{
    public  interface ITokenService
    {
        string GerarToken(string email, List<int> roles);
        public string getJWTTokenClaim(string token);
    }
}
