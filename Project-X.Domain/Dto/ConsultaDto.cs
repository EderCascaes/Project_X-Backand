using Project_X.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_X.Domain.Dto
{
    public class ConsultaDto
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Hora { get; set; }
        public string Descricao { get; set; }
        public int IdFisioterpeuta { get; set; }
        public int IdPaciente { get; set; }
    }
}
