using Project_X.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_X.Interface.Repositories
{
    public interface IFisioterapeutaRepositorio
    {
        Task<int> Cadastro(Fisioterapeuta fisioterapeuta);
        Task<int> Editar(Fisioterapeuta fisioterapeuta);
        Task<int> Excluir(int id);
        Task<List<Fisioterapeuta>> Obter(int id = 0);
    }
}
