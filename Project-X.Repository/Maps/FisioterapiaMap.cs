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
    public class FisioterapiaMap : BaseDomainMap<Fisioterapia>
    {
        public FisioterapiaMap() : base("tb_fisioterapia") { }

        public override void Configure(EntityTypeBuilder<Fisioterapia> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.DataInicio).HasColumnName("dataInicio").IsRequired();
            builder.Property(x => x.Hora).HasColumnName("hora").HasMaxLength(5).IsRequired();
            builder.Property(x => x.DataFim).HasColumnName("dataFim");
            builder.Property(x => x.Procedimento).HasColumnName("procedimento").HasMaxLength(300).IsRequired();
            builder.Property(x => x.Quantidade).HasColumnName("quantidade").HasMaxLength(300).IsRequired();
            builder.Property(x => x.QtdRealizadas).HasColumnName("qtdRealizadas").HasMaxLength(300).IsRequired();
            builder.Property(x => x.Progresso).HasColumnName("progresso").HasMaxLength(300);
            builder.Property(x => x.IdPaciente).HasColumnName("idPaciente").IsRequired();
            builder.Property(x => x.IdFisioterapeuta).HasColumnName("idFisioterapeuta").IsRequired();

            builder.HasOne(x => x.Paciente).WithMany(y => y.Fisioterapias).HasForeignKey(x => x.IdPaciente);
            builder.HasOne(x => x.Fisioterapeuta).WithMany(y => y.Fisioterapias).HasForeignKey(x => x.IdFisioterapeuta);


 
        }
    }
}

/*
public DateTime DataInicio { get; set; }
public DateTime? DataFim { get; set; }
public string Procedimentos { get; set; }
public Fisioterapeuta Fisioterapeuta { get; }
public Paciente Paciente { get; set; }
 public int Quantidade { get; set; }
        public int QtdRealizadas { get; set; }
        public string? Progresso { get; set; }
 */