using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Data.EntityConfig
{
    class ProdutoConfig : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfig()
        {
            HasKey(produto => produto.GuidId);

            Property(produto => produto.Nome)
                .IsRequired()
                .HasMaxLength(50);

            Property(produto => produto.Preço)
                .IsRequired();

            HasRequired(produto => produto.Categoria)
                .WithMany(categoria => categoria.Produtos)
                .HasForeignKey(produto => produto.CategoriaId);
        }
    }
}
