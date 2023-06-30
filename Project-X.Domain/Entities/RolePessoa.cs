using Project_X.Domain.Entities.Shared;

namespace Project_X.Domain.Entities
{
    public class RolePessoa: BaseDomain
    {
        public RolePessoa() { }
        public int Role { get; set; }
        public string  Cpf { get; set; }
       // public Pessoa Pessoa { get; set; }
    }
}
