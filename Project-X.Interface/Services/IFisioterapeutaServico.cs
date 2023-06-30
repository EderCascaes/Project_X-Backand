using Project_X.Domain.Dto;
using Project_X.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_X.Interface.Services
{
    public  interface IFisioterapeutaServico
    {
        Task<int> Cadastro(FisioterapeutaDto dto);
        Task<int> Editar(FisioterapeutaDto dto);
        Task<int> Excluir(int id);
        Task<List<Fisioterapeuta>> Obter(int id = 0);
    }
}
