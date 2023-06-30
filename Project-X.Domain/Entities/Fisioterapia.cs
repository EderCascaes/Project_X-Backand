using Project_X.Domain.Entities.Shared;
using System.ComponentModel.DataAnnotations;

namespace Project_X.Domain.Entities
{
    public class Fisioterapia: BaseDomain
    {
        public Fisioterapia() { }

        public Fisioterapia(
            DateTime dataInicio,
            string hora,
            DateTime? dataFim, 
            string procedimento, 
            int idFisioterapeuta, 
            int idPaciente,
            int quantidade,
            int qtdRealizadas,
            string? progresso,
            int id = 0            
            )
        {
            DataInicio = dataInicio;
            DataFim = dataFim;
            Hora = hora;
            Procedimento = procedimento;
            IdFisioterapeuta = idFisioterapeuta;            
            IdPaciente = idPaciente;
            Quantidade = quantidade;
            QtdRealizadas = qtdRealizadas;
            Progresso = progresso;
            Id = id;
        }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataInicio { get; set; }
        public string Hora { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DataFim { get; set; }
        public string  Procedimento { get; set; }
        public int IdFisioterapeuta { get; set; }
        public Fisioterapeuta? Fisioterapeuta { get;}
        public int IdPaciente { get; set; }
        public Paciente? Paciente { get; set; }
        public int Quantidade { get; set; }
        public int QtdRealizadas { get; set; }
        public string? Progresso { get; set; }
    }
}
