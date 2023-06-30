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
    public class RolePessoaMap : BaseDomainMap<RolePessoa>
    {
        public RolePessoaMap() : base("tb_rolePessoa") { }

        public override void Configure(EntityTypeBuilder<RolePessoa> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Role).HasColumnName("role").HasMaxLength(20).IsRequired();
            builder.Property(x => x.Cpf).HasColumnName("cpf").HasMaxLength(11).IsRequired();

           

        }
    }
}
/*
public eRoles Role { get; set; }
public string Cpf { get; set; }*/