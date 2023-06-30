using Project_X.Domain.Entities.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Project_X.Domain.Entities
{
    public class Consulta : BaseDomain
    {
        public Consulta(){}

        public Consulta(DateTime data, string hora,string descricao, int idFisioterpeuta, int idPaciente, int id = 0)
        {
            Data = data;
            Hora = hora;
            Descricao = descricao;
            IdFisioterpeuta = idFisioterpeuta;
            IdPaciente = idPaciente;
            Id = id;
        }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }
        public string Hora { get; set; }
        public string Descricao { get; set; }
        public int IdFisioterpeuta { get; set; }
        public Fisioterapeuta Fisioterapeuta { get; set; }
        public int IdPaciente { get; set; }
        public Paciente Paciente { get; set; }
    }
}
