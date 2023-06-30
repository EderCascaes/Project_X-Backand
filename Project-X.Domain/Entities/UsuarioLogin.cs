

using Project_X.Domain.Entities.Shared;

namespace Project_X.Domain.Entities
{
    public class UsuarioLogin : BaseDomain
    {
        public UsuarioLogin() { }
        public string Email { get; set; }
        public string Password { get; set; }
        public int IdPessoa { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}
