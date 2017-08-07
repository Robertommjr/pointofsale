using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Produto
    {
        [Key]
        public Guid GuidId { get; set; }

        public Guid CategoriaId { get; set; }

        public string Nome { get; set; }

        public decimal Preco { get; set; }

        public virtual Categoria Categoria { get; set; }
    }
}
