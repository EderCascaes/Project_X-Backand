using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_X.Domain.Entities.Shared;

namespace Project_X.Repository.Maps
{
    public class BaseDomainMap<TDomain> : IEntityTypeConfiguration<TDomain> where TDomain : BaseDomain
    {

        private readonly string _tableName;

        public BaseDomainMap(string tableName = "")
        {
            _tableName = tableName;
        }

        public virtual void Configure(EntityTypeBuilder<TDomain> builder)
        {
            if (!string.IsNullOrEmpty(_tableName))
            {
                builder.ToTable(_tableName);
            }

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();

            builder.Property(x => x.CreatedIn).HasColumnName("criado_em").IsRequired();
        }

    }
}
