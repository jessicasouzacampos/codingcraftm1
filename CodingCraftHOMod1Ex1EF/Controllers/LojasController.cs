using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using CodingCraftHOMod1Ex1EF.Models;
using System.Transactions;
using System.Linq;
using System.Collections.Generic;
using CodingCraftHOMod1Ex1EF.ViewModels;
using CodingCraftHOMod1Ex1EF.Extensions;

namespace CodingCraftHOMod1Ex1EF.Controllers
{
    public class LojasController : System.Web.Mvc.Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

       
        // GET: Lojas
        public async Task<ActionResult> Index(ProdutosPorLojaViewModel viewModel)
        {
            var loja = db.Lojas.Include(p => p.LojaProdutos.Select(o => o.Produto));
            List<ProdutosViewModel> produtos = new List<ProdutosViewModel>();

            if (viewModel.LojaId != null)
            {
               loja = loja.Where(s => s.LojaId == viewModel.LojaId);

                foreach (var item in loja.First().LojaProdutos)
                {
                    produtos.Add(new ProdutosViewModel(item.Produto.ProdutoId, item.Produto.CategoriaId, item.Produto.Nome, item.Produto.Valor, item.Quantidade));
                }
            }         

            ViewBag.LojaId = new SelectList(db.Lojas, "LojaId", "Nome", viewModel.LojaId);
            viewModel.Resultados = produtos;


            if (produtos.Count() > 0)
            {
                ArquivosHelperExtensions.SalvarExcel("EAE", produtos.ToList());
                ArquivosHelperExtensions.SalvarJson(produtos.ToList());
                ArquivosHelperExtensions.SalvarXML(produtos.ToList(), "ProdutosViewModel");
            }            

            return View(viewModel);
        }

        // GET: Lojas
        public async Task<ActionResult> Index2(ProdutosPorLojaViewModel viewModel)
        {
            var loja = db.Lojas.Include(p => p.LojaProdutos.Select(o => o.Produto).GroupBy(ol => ol.CategoriaId));

            List<ProdutosViewModel> produtos = new List<ProdutosViewModel>();

            if (viewModel.LojaId != null)
            {
                loja = loja.Where(s => s.LojaId == viewModel.LojaId);

                foreach (var item in loja.First().LojaProdutos)
                {
                    produtos.Add(new ProdutosViewModel(item.Produto.ProdutoId, item.Produto.CategoriaId, item.Produto.Nome, item.Produto.Valor, item.Quantidade));
                }
            }

            ViewBag.LojaId = new SelectList(db.Lojas, "LojaId", "Nome", viewModel.LojaId);
            viewModel.Resultados = produtos;

            return View(viewModel);
        }

        // GET: Lojas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loja loja = await db.Lojas.FindAsync(id);
            if (loja == null)
            {
                return HttpNotFound();
            }
            return View(loja);
        }

        // GET: Lojas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lojas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "LojaId,Nome")] Loja loja)
        {
            if (ModelState.IsValid)
            {
                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    db.Lojas.Add(loja);
                    await db.SaveChangesAsync();

                    scope.Complete();
                    return RedirectToAction("Index");
                }                
            }

            return View(loja);
        }

        // GET: Lojas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loja loja = await db.Lojas.FindAsync(id);
            if (loja == null)
            {
                return HttpNotFound();
            }
            return View(loja);
        }

        // POST: Lojas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "LojaId,Nome")] Loja loja)
        {
            if (ModelState.IsValid)
            {
                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    db.Entry(loja).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    scope.Complete();
                    return RedirectToAction("Index");
                }            
            }
            return View(loja);
        }

        // GET: Lojas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loja loja = await db.Lojas.FindAsync(id);
            if (loja == null)
            {
                return HttpNotFound();
            }
            return View(loja);
        }

        // POST: Lojas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                Loja loja = await db.Lojas.FindAsync(id);
                db.Lojas.Remove(loja);
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
