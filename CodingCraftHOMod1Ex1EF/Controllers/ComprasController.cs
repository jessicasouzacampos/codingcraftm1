using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodingCraftHOMod1Ex1EF.Models;

namespace CodingCraftHOMod1Ex1EF.Controllers
{
    public class ComprasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Compras
        public async Task<ActionResult> Index()
        {
            var compras = db.Compras.Include(c => c.Fornecedor);
            return View(await compras.ToListAsync());
        }

        // GET: Compras/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = await db.Compras.FindAsync(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // GET: Compras/Create
        public ActionResult Create()
        {
            ViewBag.PessoaId = new SelectList(db.Pessoas, "Id", "Email");
            return View();
        }

        // POST: Compras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CompraId,PessoaId,Data")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                db.Compras.Add(compra);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PessoaId = new SelectList(db.Pessoas, "Id", "Email", compra.PessoaId);
            return View(compra);
        }

        // GET: Compras/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = await db.Compras.FindAsync(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            ViewBag.PessoaId = new SelectList(db.Pessoas, "Id", "Email", compra.PessoaId);
            return View(compra);
        }

        // POST: Compras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CompraId,PessoaId,Data")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compra).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PessoaId = new SelectList(db.Pessoas, "Id", "Email", compra.PessoaId);
            return View(compra);
        }

        // GET: Compras/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = await db.Compras.FindAsync(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // POST: Compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Compra compra = await db.Compras.FindAsync(id);
            db.Compras.Remove(compra);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
