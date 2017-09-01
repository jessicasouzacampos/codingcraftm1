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
            // List<ProdutosViewModel> produtos = new List<ProdutosViewModel>();

            if (viewModel.NomeLoja != null)
            {
                loja = loja.Where(s => s.Nome.Contains(viewModel.NomeLoja));

                //foreach (var item in loja.First().LojaProdutos)
                //{
                //    produtos.Add(new ProdutosViewModel(item.Produto.ProdutoId, item.Produto.CategoriaId, item.Produto.Nome, item.Produto.Valor, item.Quantidade, item.ProdutoLojaId));
                //}
            }

            ViewBag.LojaId = new SelectList(db.Lojas, "LojaId", "Nome", viewModel.NomeLoja);
            viewModel.Resultados = loja.ToList();

            return View(viewModel);
        }

        public ActionResult SalvarPesquisa(ProdutosPorLojaViewModel viewModel)
        {
            if (viewModel.Resultados.Count() > 0)
            {
                string filePath = string.Empty;

                if (viewModel.FormatoEscolhido == Models.Enum.Formato.Excel)
                {
                    filePath = ArquivosHelperExtensions.SalvarExcel("ProdutosPorLoja", viewModel.Resultados.ToList());
                    Response.ContentType = "application/vnd.ms-excel";
                }
                else if (viewModel.FormatoEscolhido == Models.Enum.Formato.JSON)
                {
                    filePath = ArquivosHelperExtensions.SalvarJson(viewModel.Resultados.ToList(), "ProdutosPorLoja");
                    Response.ContentType = "application/json";
                }
                else if (viewModel.FormatoEscolhido == Models.Enum.Formato.XML)
                {
                    filePath = ArquivosHelperExtensions.SalvarXML(viewModel.Resultados.ToList(), "ProdutosViewModel", "ProdutosPorLoja");
                    Response.ContentType = "application/xml";
                }

                if (filePath != string.Empty)
                {
                    Response.AppendHeader("content-disposition", "attachment; filename=" + filePath);
                    Response.TransmitFile(filePath);
                    Response.End();
                }
            }
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
