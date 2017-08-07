using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EntityConfig
{
    internal class CategoriaConfig : EntityTypeConfiguration<Categoria>
    {
        public CategoriaConfig()
        {
            HasKey(categoria => categoria.GuidId);

            Property(categoria => categoria.Nome)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
