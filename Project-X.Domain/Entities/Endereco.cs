using Project_X.Domain.Entities.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_X.Domain.Entities
{
    public class Endereco :BaseDomain
    {
        public Endereco() { }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string? Complemento { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public virtual Pessoa? Pessoa { get; set; }


    }
}
