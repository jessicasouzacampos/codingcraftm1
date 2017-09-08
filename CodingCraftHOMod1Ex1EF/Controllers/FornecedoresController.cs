using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using CodingCraftHOMod1Ex1EF.Models;

namespace CodingCraftHOMod1Ex1EF.Controllers
{
    public class FornecedoresController : Controller
    {
        // GET: Fornecedores
        public async Task<ActionResult> Index()
        {
            var fornecedors = db.Fornecedores.Include(f => f.Pessoa);
            return View(await fornecedors.ToListAsync());
        }

        // GET: Fornecedores/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fornecedor fornecedor = await db.Fornecedores.FindAsync(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }

        // GET: Fornecedores/Create
        public ActionResult Create()
        {
            ViewBag.PessoaId = new SelectList(db.Users, "Id", "UserName");
            return View();
        }

        // POST: Fornecedores/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PessoaId")] Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                db.Fornecedores.Add(fornecedor);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PessoaId = new SelectList(db.Users, "Id", "UserName", fornecedor.PessoaId);
            return View(fornecedor);
        }

        // GET: Fornecedores/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fornecedor fornecedor = await db.Fornecedores.FindAsync(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.PessoaId = new SelectList(db.Users, "Id", "UserName", fornecedor.PessoaId);
            return View(fornecedor);
        }

        // POST: Fornecedores/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PessoaId")] Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fornecedor).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PessoaId = new SelectList(db.Users, "Id", "UserName", fornecedor.PessoaId);
            return View(fornecedor);
        }

        // GET: Fornecedores/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fornecedor fornecedor = await db.Fornecedores.FindAsync(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }

        // POST: Fornecedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Fornecedor fornecedor = await db.Fornecedores.FindAsync(id);
            db.Fornecedores.Remove(fornecedor);
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
