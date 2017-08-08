using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Data.Context;
using Domain.Entities;
using Newtonsoft.Json;
using PointOfSale.ViewModels;
using PointOfSale.ViewModels.Categoria;
using PointOfSale.ViewModels.Produto;
using Service.Services;

namespace PointOfSale.Controllers
{
    public class ProdutosController : MapController
    {
        private readonly ProdutoService _produtoService = new ProdutoService();
        private readonly CategoriaService _categoriaService = new CategoriaService();

        public ProdutosController()
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

        // GET: Produtos
        public ActionResult Index()
        {
            var produtoVM = new ProdutoViewModel();

            produtoVM.ProdutosViewModels =
                Mapper.Map<IList<Produto>, IList<ProdutoViewModel>>(_produtoService.ObterTodosComCategoria());

            return View(produtoVM);
        }

        // GET: Produtos/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoViewModel produto = Mapper.Map<Produto, ProdutoViewModel>(_produtoService.ObterPorId((Guid)id));
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            var produtoVM = new ProdutoViewModel
            {
                Categorias = _categoriaService.ObterTodos().OrderBy(c => c.Nome).Select(option =>
                    new SelectListItem
                    {
                        Text = option.Nome,
                        Value = option.GuidId.ToString()
                    }).ToList()
            };

            return View(produtoVM);
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GuidId,CategoriaId,Nome,Preco")] ProdutoViewModel produtovm)
        {
            if (ModelState.IsValid)
            {
                var produto = Mapper.Map<ProdutoViewModel, Produto>(produtovm);
                produto.GuidId = Guid.NewGuid();

                //produto.Preco = Decimal.Parse(produtovm.Preco.Replace(".", ","));

                _produtoService.Salvar(produto);

                return RedirectToAction("Index");
            }

            produtovm.Categorias = _categoriaService.ObterTodos().OrderBy(c => c.Nome).Select(option =>
                new SelectListItem
                {
                    Text = option.Nome,
                    Value = option.GuidId.ToString()
                }).ToList();

            return View(produtovm);
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ProdutoViewModel produto = Mapper.Map<Produto, ProdutoViewModel>(_produtoService.ObterPorId((Guid)id));
            produto.Categorias = _categoriaService.ObterTodos().OrderBy(c => c.Nome).Select(option =>
                new SelectListItem
                {
                    Text = option.Nome,
                    Value = option.GuidId.ToString()
                }).ToList();

            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GuidId,CategoriaId,Nome,Preco")] ProdutoViewModel produtovm)
        {
            if (ModelState.IsValid)
            {
                var produto = Mapper.Map<ProdutoViewModel, Produto>(produtovm);
                _produtoService.Atualizar(produto);

                return RedirectToAction("Index");
            }

            produtovm.Categorias = _categoriaService.ObterTodos().OrderBy(c => c.Nome).Select(option =>
                new SelectListItem
                {
                    Text = option.Nome,
                    Value = option.GuidId.ToString()
                }).ToList();

            return View(produtovm);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoViewModel produto = Mapper.Map<Produto, ProdutoViewModel>(_produtoService.ObterPorId((Guid)id));
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _produtoService.ExcluirPorId(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _produtoService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
