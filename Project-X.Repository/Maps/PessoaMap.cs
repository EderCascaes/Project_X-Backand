using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_X.Domain.Entities;
using Project_X.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_X.Repository.Maps
{
    public class PessoaMap : BaseDomainMap<Pessoa>
    {
        public PessoaMap() : base("tb_pessoa") { }

        public override void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Nome).HasColumnName("nome").HasMaxLength(150).IsRequired();
            builder.Property(x => x.Email).HasColumnName("email").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Telefone).HasColumnName("telefone").HasMaxLength(13).IsRequired();
            builder.Property(x => x.DataNascimento).HasColumnName("dataNascimento").HasMaxLength(10).IsRequired();
            builder.Property(x => x.Cpf).HasColumnName("cpf").HasMaxLength(11).IsRequired();
            builder.Property(x => x.IdEndereco).HasColumnName("id_endereco").IsRequired();

            builder.HasOne(x => x.Login).WithOne(x => x.Pessoa).HasForeignKey<UsuarioLogin>(x => x.IdPessoa);

        }
    }
}

/*public string Nome { get; set; }
public string Email { get; set; }
public string Telefone { get; set; }
public DateTime DataNascimento { get; set; }
public string Cpf { get; set; }
public eRoles[] Papaeis { get; }
public int IdEndereco { get; set; }
public Endereco Endereco { get; set; }
*/