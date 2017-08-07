using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Data.EntityConfig
{
    internal class MetodoPagamentoConfig : EntityTypeConfiguration<MetodoPagamento>
    {
        public MetodoPagamentoConfig()
        {
            HasKey(metodoPagamento => metodoPagamento.GuidId);

            Property(metodoPagamento => metodoPagamento.Nome)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
