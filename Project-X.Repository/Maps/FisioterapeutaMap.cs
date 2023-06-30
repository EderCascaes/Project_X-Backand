using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_X.Domain.Entities;

namespace Project_X.Repository.Maps
{
    public class FisioterapeutaMap : BaseDomainMap<Fisioterapeuta>
    {
        public FisioterapeutaMap()   : base("tb_fisioterapeuta") { }

        public override void Configure(EntityTypeBuilder<Fisioterapeuta> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.CREFITO).HasColumnName("crefito").HasMaxLength(15).IsRequired();
            builder.Property(x => x.IdPessoa).HasColumnName("idPessoa").IsRequired();

            builder.HasOne(x => x.Pessoa).WithOne(y => y.Fisioterapeuta).HasForeignKey<Fisioterapeuta>(x => x.IdPessoa);

        }

    }
}
