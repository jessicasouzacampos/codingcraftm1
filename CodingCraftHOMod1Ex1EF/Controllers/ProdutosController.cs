﻿using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using CodingCraftHOMod1Ex1EF.Models;
using System.Transactions;
using System.Linq;

namespace CodingCraftHOMod1Ex1EF.Controllers
{
    public class ProdutosController : Controller    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Pesquisar(string filtro)
        {
            var lista = db.Produtos.Where(s => s.Nome.Contains(filtro)).ToList();
            return View(lista);
        }

        // GET: Produtos
        public async Task<ActionResult> Index()
        {
            var produtos = db.Produtos.Include(p => p.Categoria);
            return View(await produtos.ToListAsync());
        }

        // GET: Produtos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = await db.Produtos
                                      .Include(p => p.Categoria)
                                      .FirstOrDefaultAsync(p => p.ProdutoId == id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Nome");
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProdutoId,CategoriaId,Nome,Valor")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    db.Produtos.Add(produto);
                    await db.SaveChangesAsync();

                    scope.Complete();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Nome", produto.CategoriaId);
            return View(produto);
        }

        // GET: Produtos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = await db.Produtos
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(p => p.ProdutoId == id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Nome", produto.CategoriaId);
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProdutoId,CategoriaId,Nome,Valor")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    db.Entry(produto).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    scope.Complete();
                    return RedirectToAction("Index");
                }               
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Nome", produto.CategoriaId);
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = await db.Produtos.FindAsync(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                Produto produto = await db.Produtos.FindAsync(id);
                db.Produtos.Remove(produto);
                await db.SaveChangesAsync();

                scope.Complete();
                return RedirectToAction("Index");
            }            
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
