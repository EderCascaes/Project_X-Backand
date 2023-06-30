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
    public class ConsultaMap: BaseDomainMap<Consulta>
    {
        public ConsultaMap() : base("tb_consulta") { }

        public override void Configure(EntityTypeBuilder<Consulta> builder)
        {
            builder.Property(x => x.Data).HasColumnName("data").IsRequired();
            builder.Property(x => x.Hora).HasColumnName("hora").HasMaxLength(5).IsRequired();
            builder.Property(x => x.Descricao).HasColumnName("descricao").HasMaxLength(300).IsRequired();
            builder.Property(x => x.IdFisioterpeuta).HasColumnName("idFisioterpeuta").IsRequired();
            builder.Property(x => x.IdPaciente).HasColumnName("idPaciente").IsRequired();

            /*  builder.HasOne(x => x.Paciente).WithOne(y => y.Consulta).HasForeignKey<Consulta>(x => x.IdPaciente);
              builder.HasOne(x => x.Fisioterapeuta).WithOne(y => y.Consulta).HasForeignKey<Consulta>(x => x.IdFisioterpeuta);*/

            builder.HasOne(x => x.Paciente).WithMany(y => y.Consultas).HasForeignKey(x => x.IdPaciente);
            builder.HasOne(x => x.Fisioterapeuta).WithMany(y => y.Consultas).HasForeignKey(x => x.IdFisioterpeuta);

        }

    }
}


/*public DateTime Data { get; set; }
public string Descricao { get; set; }
public int IdFisioterpeuta { get; set; }
public Fisioterapeuta Fisioterapeuta { get; set; }
public int IdPaciente { get; set; }
public Paciente Paciente { get; set; }
*/