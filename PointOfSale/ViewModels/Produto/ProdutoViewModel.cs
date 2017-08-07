using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using PointOfSale.ViewModels.Categoria;

namespace PointOfSale.ViewModels.Produto
{
    public class ProdutoViewModel
    {
        public Guid GuidId { get; set; }

        [Required(ErrorMessage = "Escolha uma categoria")]
        [Display(Name = "Categoria do produto")]
        public Guid CategoriaId { get; set; }

        [Required(ErrorMessage = "Informe o nome", AllowEmptyStrings = false)]
        [Display(Name = "Nome do produto")]
        [StringLength(50, ErrorMessage = "O nome deve conter no máximo 50 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o preço")]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }

        public int Quantidade { get; set; }

        public virtual CategoriaViewModel Categoria { get; set; }
        public virtual IList<ProdutoViewModel> ProdutosViewModels { get; set; }

        public ICollection<SelectListItem> Categorias { get; set; }

        public ProdutoViewModel()
        {
            this.Quantidade = 1;
        }
    }
}