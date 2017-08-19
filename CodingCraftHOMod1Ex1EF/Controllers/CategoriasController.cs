using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using CodingCraftHOMod1Ex1EF.Models;
using System.Transactions;
using CodingCraftHOMod1Ex1EF.ViewModels;
using System.Linq;
using System.Collections.Generic;

namespace CodingCraftHOMod1Ex1EF.Controllers
{
    public class CategoriasController : System.Web.Mvc.Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Categorias
        public async Task<ActionResult> Index(LojasPorCategoriaViewModel viewModel)
        {             
            List<LojasViewModel> lojas = new List<LojasViewModel>();

            if (viewModel.CategoriaId != null)
            {
                var produtos = db.Produtos
                .Include(o => o.Categoria)
                .Include(o => o.ProdutoLojas.Select(b => b.Loja)).ToList();

                produtos = produtos.Where(s => s.CategoriaId == viewModel.CategoriaId).ToList();

               
                var resultado = produtos.GroupBy(x => new {x.ProdutoLojas}).Select(r => r.Key.ProdutoLojas);
                   
                foreach (var item in resultado)
                {
                    var resultado2 = item.GroupBy(x => new { x.Loja, x.Quantidade})
                        .Select(c => new {
                            Quantidade = c.Sum(o => o.Quantidade),
                            NomeLoja = c.Key.Loja.Nome,
                            LojaID = c.Key.Loja.LojaId,
                        });

                    foreach (var item2 in resultado2)
                    {
                        lojas.Add(new LojasViewModel(item2.LojaID, item2.NomeLoja, item2.Quantidade));
                    }

                }

                var tet = lojas.GroupBy(o => o.LojaId);         

            }


            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Nome", viewModel.CategoriaId);
            viewModel.Resultados = lojas;
            return View(viewModel);
        }

        // GET: Categorias/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = await db.Categorias.FindAsync(id);
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
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CategoriaId,Nome")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    db.Categorias.Add(categoria);
                    await db.SaveChangesAsync();
                    scope.Complete();
                    return RedirectToAction("Index");
                }
                
            }

            return View(categoria);
        }

        // GET: Categorias/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = await db.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // POST: Categorias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CategoriaId,Nome")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    db.Entry(categoria).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    scope.Complete();
                    return RedirectToAction("Index");
                }
            }
            return View(categoria);
        }

        // GET: Categorias/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = await db.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                Categoria categoria = await db.Categorias.FindAsync(id);
                db.Categorias.Remove(categoria);
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
