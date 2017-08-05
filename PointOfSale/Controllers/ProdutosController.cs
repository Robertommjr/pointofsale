using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data.Context;
using Domain.Entities;
using Newtonsoft.Json;
using PointOfSale.ViewModels;
using PointOfSale.ViewModels.Produto;
using Service.Services;

namespace PointOfSale.Controllers
{
    public class ProdutosController : Controller
    {
        ProdutoService _produtoService = new ProdutoService();
        private CategoriaService _categoriaService = new CategoriaService();

        // GET: Produtos
        public ActionResult Index()
        {


            return View(_produtoService.ObterTodos());
        }

        // GET: Produtos/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = _produtoService.ObterPorId((Guid)id);
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
                Categorias = _categoriaService.ObterTodos().Select(option =>
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
        public ActionResult Create([Bind(Include = "GuidId,CategoriaId,Nome,Preço")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                produto.GuidId = Guid.NewGuid();
                
                _produtoService.Salvar(produto);

                return RedirectToAction("Index");
            }

            return View(produto);
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = _produtoService.ObterPorId((Guid)id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GuidId,CategoriaId,Nome,Preço")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                _produtoService.Atualizar(produto);

                return RedirectToAction("Index");
            }
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = _produtoService.ObterPorId((Guid) id);
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
