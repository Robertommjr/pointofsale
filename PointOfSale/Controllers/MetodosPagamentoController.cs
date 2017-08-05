using System;
using System.Net;
using System.Web.Mvc;
using Domain.Entities;
using Service.Services;

namespace PointOfSale.Controllers
{
    public class MetodosPagamentoController : Controller
    {
        readonly MetodoPagamentoService _metodoPagamentoService = new MetodoPagamentoService();

        // GET: MetodosPagamento
        public ActionResult Index()
        {
            return View(_metodoPagamentoService.ObterTodos());
        }

        // GET: MetodosPagamento/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetodoPagamento metodoPagamento = _metodoPagamentoService.ObterPorId((Guid) id);
            if (metodoPagamento == null)
            {
                return HttpNotFound();
            }
            return View(metodoPagamento);
        }

        // GET: MetodosPagamento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MetodosPagamento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GuidId,Nome")] MetodoPagamento metodoPagamento)
        {
            if (ModelState.IsValid)
            {
                metodoPagamento.GuidId = Guid.NewGuid();
                _metodoPagamentoService.Salvar(metodoPagamento);

                return RedirectToAction("Index");
            }

            return View(metodoPagamento);
        }

        // GET: MetodosPagamento/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetodoPagamento metodoPagamento = _metodoPagamentoService.ObterPorId((Guid) id);
            if (metodoPagamento == null)
            {
                return HttpNotFound();
            }
            return View(metodoPagamento);
        }

        // POST: MetodosPagamento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GuidId,Nome")] MetodoPagamento metodoPagamento)
        {
            if (ModelState.IsValid)
            {
                _metodoPagamentoService.Atualizar(metodoPagamento);

                return RedirectToAction("Index");
            }
            return View(metodoPagamento);
        }

        // GET: MetodosPagamento/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetodoPagamento metodoPagamento = _metodoPagamentoService.ObterPorId((Guid)id);
            if (metodoPagamento == null)
            {
                return HttpNotFound();
            }
            return View(metodoPagamento);
        }

        // POST: MetodosPagamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _metodoPagamentoService.ExcluirPorId(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _metodoPagamentoService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
