﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Domain.Entities;
using Newtonsoft.Json;
using PointOfSale.ViewModels.Carrinho;
using PointOfSale.ViewModels.Categoria;
using PointOfSale.ViewModels.Home;
using PointOfSale.ViewModels.MetodoPagamento;
using PointOfSale.ViewModels.Produto;
using Service.Services;

namespace PointOfSale.Controllers
{
    public class HomeController : MapController
    {
        private readonly CategoriaService _categoriaService = new CategoriaService();
        private readonly ProdutoService _produtoService = new ProdutoService();
        private readonly MetodoPagamentoService _metodoPagamentoService = new MetodoPagamentoService();

        public HomeController()
        {
            AutomMapperConfig = new MapperConfiguration(cfg =>
            {
                //Produto
                cfg.CreateMap<Produto, ProdutoViewModel>();
                cfg.CreateMap<ProdutoViewModel, Produto>();

                //Categoria
                cfg.CreateMap<Categoria, CategoriaViewModel>();
            });
            Mapper = AutomMapperConfig.CreateMapper();
        }

        public ActionResult Index()
        {            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public string BuscaDados()
        {
            HomeViewModel homeViewModel =
                new HomeViewModel
                {
                    CategoriasViewModel =
                        Mapper.Map<IEnumerable<Categoria>, IList<CategoriaViewModel>>(_categoriaService.ObterTodos()
                            .OrderBy(c => c.Nome)),
                    ProdutosViewModel =
                        Mapper.Map<IList<Produto>, IList<ProdutoViewModel>>(_produtoService.ObterTodosComCategoria())
                };


            return JsonConvert.SerializeObject(homeViewModel);
        }
    }
}