using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using CodingCraftHOMod1Ex1EF.Models;
using CodingCraftHOMod1Ex1EF.ViewModels;
using System.Transactions;
using System.Linq;
using System;
using PagedList;
using Microsoft.AspNet.Identity;
using CodingCraftHOMod1Ex1EF.Extensions;
using CodingCraftHOMod1Ex1EF.Filters;

namespace CodingCraftHOMod1Ex1EF.Controllers
{
    //[Authorize(Roles = "Admin")]
    [IdadeMinima("DateOfBirth")]
    public class ProdutosController : Controller
    {
        // GET: Produtos
        public ActionResult Index(ProdutoPesquisaViewModel viewModel, int? page)
        {          
            var produtos = db.Produtos.Include(p => p.Categoria);

            if (!String.IsNullOrEmpty(viewModel.TermoPesquisa))
            {
                produtos = produtos.Where(s => s.Nome.Contains(viewModel.TermoPesquisa) || s.Valor.ToString().Contains(viewModel.TermoPesquisa));
            }

            if (!String.IsNullOrEmpty(viewModel.UsuarioCriacao))
            {
                produtos = produtos.Where(s => s.UsuarioCriacao.Contains(viewModel.UsuarioCriacao));
            }

            if (!String.IsNullOrEmpty(viewModel.UsuarioUltimaModificacao))
            {
                produtos = produtos.Where(s => s.UsuarioUltimaModificacao.Contains(viewModel.UsuarioUltimaModificacao));
            }

            if (viewModel.CategoriaId != null)
            {
                produtos = produtos.Where(s => s.CategoriaId == viewModel.CategoriaId);
            }

            if (viewModel.ValorInicial != null)
            {
                if (viewModel.ValorFinal != null)
                {
                    produtos = produtos.Where(s => s.Valor >= viewModel.ValorInicial && s.Valor <= viewModel.ValorFinal);
                } else
                {
                    produtos = produtos.Where(s => s.Valor == viewModel.ValorInicial);
                }
            }

            if (viewModel.DataCriacaoInicial != null)
            {
                if (viewModel.DataCriacaoFinal != null)
                {
                    produtos = produtos.Where(s => s.DataCriacao >= viewModel.DataCriacaoInicial && s.DataCriacao <= viewModel.DataCriacaoFinal);
                }
                else
                {
                    produtos = produtos.Where(s => s.DataCriacao == viewModel.DataCriacaoInicial);
                }
            }

            if (viewModel.DataUltimaModificacaoInicial != null)
            {
                if (viewModel.DataUltimaModificacaoFinal != null)
                {
                    produtos = produtos.Where(s => s.DataUltimaModificacao >= viewModel.DataUltimaModificacaoInicial && 
                        s.DataUltimaModificacao <= viewModel.DataUltimaModificacaoFinal);
                }
                else
                {
                    produtos = produtos.Where(s => s.DataUltimaModificacao == viewModel.DataUltimaModificacaoInicial);
                }
            }
     
            if (!string.IsNullOrEmpty(User.Identity.Name))
            {
                SalvaPesquisaHelperExtensions.Salva<ProdutoPesquisaViewModel>(viewModel, User.Identity.GetUserId());
            }
            
            var pagina = page ?? 1;
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Nome", viewModel.CategoriaId);
            viewModel.Resultados = produtos.OrderBy(o => o.ProdutoId).ToPagedList(pagina, 5);// ToListAsync();

            return View(viewModel);
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
