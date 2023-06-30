

namespace Project_X.Domain.Dto
{
    public class PessoaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
        public int IdEndereco { get; set; }
        public List<int> Funcao { get; set; }
    }
}
