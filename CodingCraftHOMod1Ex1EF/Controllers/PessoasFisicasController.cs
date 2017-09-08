using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using CodingCraftHOMod1Ex1EF.ViewModels;
using System.Transactions;

namespace CodingCraftHOMod1Ex1EF.Controllers
{
    public class PessoasFisicasController : System.Web.Mvc.Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PessoasFisicas
        public async Task<ActionResult> Index()
        {
            var usuarios = db.PessoasFisicas.Include(p => p.Cliente).Include(p => p.Fornecedor);
            return View(await usuarios.ToListAsync());
        }

        // GET: PessoasFisicas/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PessoaFisica pessoaFisica = await db.PessoasFisicas.FindAsync(id);
            if (pessoaFisica == null)
            {
                return HttpNotFound();
            }
            return View(pessoaFisica);
        }

        // GET: PessoasFisicas/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Clientes, "PessoaId", "PessoaId");
            ViewBag.Id = new SelectList(db.Fornecedores, "PessoaId", "PessoaId");
            return View();
        }

        // POST: PessoasFisicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,Cpf")] PessoaFisica pessoaFisica)
        {
            if (ModelState.IsValid)
            {
                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    db.PessoasFisicas.Add(pessoaFisica);
                    await db.SaveChangesAsync();

                    scope.Complete();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.Id = new SelectList(db.Clientes, "PessoaId", "PessoaId", pessoaFisica.Id);
            ViewBag.Id = new SelectList(db.Fornecedores, "PessoaId", "PessoaId", pessoaFisica.Id);
            return View(pessoaFisica);
        }

        // GET: PessoasFisicas/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PessoaFisica pessoaFisica = await db.PessoasFisicas.FindAsync(id);
            if (pessoaFisica == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Clientes, "PessoaId", "PessoaId", pessoaFisica.Id);
            ViewBag.Id = new SelectList(db.Fornecedores, "PessoaId", "PessoaId", pessoaFisica.Id);
            return View(pessoaFisica);
        }

        // POST: PessoasFisicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,Cpf")] PessoaFisica pessoaFisica)
        {
            if (ModelState.IsValid)
            {
                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    db.Entry(pessoaFisica).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    scope.Complete();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Id = new SelectList(db.Clientes, "PessoaId", "PessoaId", pessoaFisica.Id);
            ViewBag.Id = new SelectList(db.Fornecedores, "PessoaId", "PessoaId", pessoaFisica.Id);
            return View(pessoaFisica);
        }

        // GET: PessoasFisicas/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PessoaFisica pessoaFisica = await db.PessoasFisicas.FindAsync(id);
            if (pessoaFisica == null)
            {
                return HttpNotFound();
            }
            return View(pessoaFisica);
        }

        // POST: PessoasFisicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                PessoaFisica pessoaFisica = await db.PessoasFisicas.FindAsync(id);
                db.PessoasFisicas.Remove(pessoaFisica);
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
