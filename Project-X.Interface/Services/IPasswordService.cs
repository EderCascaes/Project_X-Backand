using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_X.Interface.Services
{
    public  interface IPasswordService
    {
        string Decode(string passaord);
        string Codification(string password);
    }
}
