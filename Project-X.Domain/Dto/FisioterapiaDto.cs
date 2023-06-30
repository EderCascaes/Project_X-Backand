using Project_X.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_X.Domain.Dto
{
    public class FisioterapiaDto
    {
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public string Hora { get; set; }
        public DateTime? DataFim { get; set; }
        public string Procedimento { get; set; }
        public int IdFisioterapeuta { get; set; }
        public int IdPaciente { get; set; }
        public int Quantidade { get; set; }
        public int QtdRealizadas { get; set; }
        public string? Progresso { get; set; }
    }
}
