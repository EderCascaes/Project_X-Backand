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
    public class PacienteMap: BaseDomainMap<Paciente>
    {
        public PacienteMap() : base("tb_paciente") { }

        public override void Configure(EntityTypeBuilder<Paciente> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.IdPessoa).HasColumnName("idPessoa").IsRequired();          

            builder.HasOne(x => x.Pessoa).WithOne(x => x.Paciente).HasForeignKey<Paciente>(x => x.IdPessoa);

        }
    }
}


/*public int IdPessoa { get; set; }
public Pessoa Pessoa { get; set; }
public List<Consulta> Consultas { get; set; }
public List<Fisioterapia> Fisioterapias { get; set; }*/