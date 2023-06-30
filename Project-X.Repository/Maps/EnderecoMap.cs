using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_X.Domain.Entities;

namespace Project_X.Repository.Maps
{
    public class EnderecoMap: BaseDomainMap<Endereco>
    {
        public EnderecoMap() : base("tb_endereco") { }

        public override void Configure(EntityTypeBuilder<Endereco> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Cidade).HasColumnName("cidade").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Estado).HasColumnName("estado").HasMaxLength(2).IsRequired();
            builder.Property(x => x.Logradouro).HasColumnName("logradouro").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Numero).HasColumnName("numero").HasMaxLength(8).IsRequired();
            builder.Property(x => x.Complemento).HasColumnName("complemento").HasMaxLength(100);
            builder.Property(x => x.CEP).HasColumnName("cep").HasMaxLength(9).IsRequired();

            builder.HasOne(x => x.Pessoa).WithOne(x => x.Endereco).HasForeignKey<Pessoa>(x => x.IdEndereco);

        }


    }
}

/*
public string Cidade { get; set; }
public string Estado { get; set; }
public string Logradouro { get; set; }
public int Numero { get; set; }
public string Complemento { get; set; }
public string CEP { get; set; }
*/