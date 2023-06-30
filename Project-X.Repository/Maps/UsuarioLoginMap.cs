using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_X.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_X.Repository.Maps
{
    public class UsuarioLoginMap : BaseDomainMap<UsuarioLogin>
    {
        public UsuarioLoginMap() : base("tb_login") { }

        public override void Configure(EntityTypeBuilder<UsuarioLogin> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Email).HasColumnName("email").HasMaxLength(150).IsRequired();
            builder.Property(x => x.Password).HasColumnName("password").HasMaxLength(64).IsRequired();
            builder.Property(x => x.IdPessoa).HasColumnName("idPessoa").IsRequired();
        }

    }

}
