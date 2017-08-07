using System.Collections.Generic;
using PointOfSale.ViewModels.MetodoPagamento;
using PointOfSale.ViewModels.Produto;

namespace PointOfSale.ViewModels.Carrinho
{
    public class CarrinhoViewModel
    {
        public IList<ProdutoViewModel> ProdutosViewModel { get; set; }
        public IList<MetodoPagamentoViewModel> MetodosPagamentoViewModel { get; set; }
    }
}