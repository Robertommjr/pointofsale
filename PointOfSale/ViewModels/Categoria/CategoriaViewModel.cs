using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Domain.Entities;
using PointOfSale.ViewModels.Produto;

namespace PointOfSale.ViewModels.Categoria
{
    public class CategoriaViewModel
    {
        public Guid GuidId { get; set; }

        [Required(ErrorMessage = "Informe o nome", AllowEmptyStrings = false)]
        [Display(Name = "Nome da categoria")]
        [StringLength(50, ErrorMessage = "O nome deve conter no máximo 50 caracteres")]
        public string Nome { get; set; }

        public virtual ICollection<ProdutoViewModel> Produtos { get; set; }
    }
}