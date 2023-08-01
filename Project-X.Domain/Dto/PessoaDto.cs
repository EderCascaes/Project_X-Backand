

using Project_X.Domain.Static;
using System.Text.Json.Serialization;

namespace Project_X.Domain.Dto
{
    public class PessoaDto
    {
        private string v;

        public PessoaDto(int id, string nome, string email, string telefone, string dataNascimento, string cpf, int idEndereco, List<int> funcao)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            DataNascimento= dataNascimento.FormatarData();
            Cpf = cpf;
            IdEndereco = idEndereco;
            Funcoes = funcao;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        //[JsonIgnore]
     //   public string _telefone { get; set; }
        public string Telefone { get; set; }
        /*{
            GET
            {
                TRY
                {
                    RETURN FUNCOES.APLICARMASCARATELEFONE(_TELEFONE);
                }
                CATCH 
                {

                    RETURN _TELEFONE;
                }
                
            }

           SET { _TELEFONE = VALUE;  }         
        }*/
        public string DataNascimento { get; set; }

      /*  [JsonIgnore]
        public string? _cpf { get; set; }*/
        public string Cpf { get; set; }
        /* {
             get
             {
                 try
                 {
                     return Funcoes.FormatCPF(_cpf);
                 }
                 catch 
                 {

                     return _cpf;
                 }
             }
             set 
             {
                  _cpf = value;
             }
         }*/
        public int IdEndereco { get; set; }
        public List<int> Funcoes { get; set; }
    }
}
