using System;
using System.Net;
using System.Web.Mvc;
using Service.Services;

namespace PointOfSale.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly CategoriaService _categoriaService = new CategoriaService();

        // GET: Categorias
        public ActionResult Index()
        {
            return View(_categoriaService.ObterTodos());
        }

        // GET: Categorias/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Domain.Entities.Categoria categoria = _categoriaService.ObterPorId((Guid) id);

            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // GET: Categorias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categorias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GuidId,Nome")] Domain.Entities.Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                categoria.GuidId = Guid.NewGuid();
                _categoriaService.Salvar(categoria);

                return RedirectToAction("Index");
            }

            return View(categoria);
        }

        // GET: Categorias/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Domain.Entities.Categoria categoria = _categoriaService.ObterPorId((Guid) id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // POST: Categorias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GuidId,Nome")] Domain.Entities.Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _categoriaService.Atualizar(categoria);
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        // GET: Categorias/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Domain.Entities.Categoria categoria = _categoriaService.ObterPorId((Guid) id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _categoriaService.ExcluirPorId(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _categoriaService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
