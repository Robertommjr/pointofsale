using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Domain.Entities;
using Newtonsoft.Json;
using PointOfSale.ViewModels.Carrinho;
using PointOfSale.ViewModels.Categoria;
using PointOfSale.ViewModels.MetodoPagamento;
using PointOfSale.ViewModels.Produto;
using Service.Services;

namespace PointOfSale.Controllers
{
    public class CarrinhoController : MapController
    {
        private readonly CategoriaService _categoriaService = new CategoriaService();
        private readonly ProdutoService _produtoService = new ProdutoService();
        private readonly MetodoPagamentoService _metodoPagamentoService = new MetodoPagamentoService();

        public CarrinhoController()
        {
            AutomMapperConfig = new MapperConfiguration(cfg =>
            {
                //Produto
                cfg.CreateMap<Produto, ProdutoViewModel>();
                cfg.CreateMap<ProdutoViewModel, Produto>();

                //Categoria
                cfg.CreateMap<Categoria, CategoriaViewModel>();

                //MetodoPagamento
                cfg.CreateMap<MetodoPagamento, MetodoPagamentoViewModel>();
            });
            Mapper = AutomMapperConfig.CreateMapper();
        }

        // GET: Categorias
        public ActionResult Index()
        {
            return View();
        }

        // GET: Categorias
        public string BuscaProdutos(string produtosIds)
        {
            CarrinhoViewModel carrinoViewModel = new CarrinhoViewModel();

            var produtos = _produtoService.ObterTodosComCategoria().Where(p => produtosIds.Contains(p.GuidId.ToString()));

            carrinoViewModel.ProdutosViewModel = Mapper.Map<IEnumerable<Produto>, IList<ProdutoViewModel>>(produtos);
            carrinoViewModel.MetodosPagamentoViewModel = Mapper.Map<IList<MetodoPagamento>, IList<MetodoPagamentoViewModel>>(_metodoPagamentoService.ObterTodos());

            return JsonConvert.SerializeObject(carrinoViewModel);
        }
    }
}