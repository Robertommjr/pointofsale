using System.Collections.Generic;
using PointOfSale.ViewModels.Categoria;
using PointOfSale.ViewModels.Produto;

namespace PointOfSale.ViewModels.Home
{
    public class HomeViewModel
    {
        public IList<ProdutoViewModel> ProdutosViewModel { get; set; }
        public IList<CategoriaViewModel> CategoriasViewModel { get; set; }
    }
}