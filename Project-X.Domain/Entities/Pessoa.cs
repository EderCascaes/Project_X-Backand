using Project_X.Domain.Entities.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_X.Domain.Entities
{
    public class Pessoa : BaseDomain
    {
        public Pessoa() { }

        public Pessoa(            
            string nome, 
            string email,
            string telefone,
            DateTime dataNascimento,
            string cpf,
            int idEndereco,
            List<int> funcao,
            int id = 0)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            DataNascimento = dataNascimento;
            Cpf = cpf;
            IdEndereco = idEndereco;
            Funcao = funcao;
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }     
        public int IdEndereco { get; set; }
        public Endereco? Endereco { get; set; }

        public virtual Fisioterapeuta? Fisioterapeuta { get; set; }
        public virtual Paciente? Paciente { get; set; }
        public virtual UsuarioLogin Login { get; set; }

        [NotMapped]
        public List<int> Funcao { get; set; } 


    }
}
