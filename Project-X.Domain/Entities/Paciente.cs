using Project_X.Domain.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_X.Domain.Entities
{
    public class Paciente : BaseDomain
    {
        public Paciente() { }

        public int IdPessoa { get; set; }
        public Pessoa? Pessoa { get; set; }
        public virtual List<Consulta> Consultas { get; set; }
        public virtual List<Fisioterapia> Fisioterapias { get; set; }

      //  public virtual Consulta Consulta { get; set; }
     //   public virtual Fisioterapia Fisioterapia { get; set; }
    }
}
