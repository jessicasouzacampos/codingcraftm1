using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using CodingCraftHOMod1Ex1EF.Models;
using System.Transactions;

namespace CodingCraftHOMod1Ex1EF.Controllers
{
    public class PessoasJuridicasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PessoasJuridicas
        public async Task<ActionResult> Index()
        {
            var usuarios = db.PessoasJuridicas.Include(p => p.Cliente).Include(p => p.Fornecedor);
            return View(await usuarios.ToListAsync());
        }

        // GET: PessoasJuridicas/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PessoaJuridica pessoaJuridica = await db.PessoasJuridicas.FindAsync(id);
            if (pessoaJuridica == null)
            {
                return HttpNotFound();
            }
            return View(pessoaJuridica);
        }

        // GET: PessoasJuridicas/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Clientes, "PessoaId", "PessoaId");
            ViewBag.Id = new SelectList(db.Fornecedores, "PessoaId", "PessoaId");
            return View();
        }

        // POST: PessoasJuridicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,Cnpj")] PessoaJuridica pessoaJuridica)
        {
            if (ModelState.IsValid)
            {
                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    db.PessoasJuridicas.Add(pessoaJuridica);
                    await db.SaveChangesAsync();

                    scope.Complete();
                    return RedirectToAction("Index");
                }                
            }

            ViewBag.Id = new SelectList(db.Clientes, "PessoaId", "PessoaId", pessoaJuridica.Id);
            ViewBag.Id = new SelectList(db.Fornecedores, "PessoaId", "PessoaId", pessoaJuridica.Id);
            return View(pessoaJuridica);
        }

        // GET: PessoasJuridicas/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PessoaJuridica pessoaJuridica = await db.PessoasJuridicas.FindAsync(id);
            if (pessoaJuridica == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Clientes, "PessoaId", "PessoaId", pessoaJuridica.Id);
            ViewBag.Id = new SelectList(db.Fornecedores, "PessoaId", "PessoaId", pessoaJuridica.Id);
            return View(pessoaJuridica);
        }

        // POST: PessoasJuridicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,Cnpj")] PessoaJuridica pessoaJuridica)
        {
            if (ModelState.IsValid)
            {
                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    db.Entry(pessoaJuridica).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    scope.Complete();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Id = new SelectList(db.Clientes, "PessoaId", "PessoaId", pessoaJuridica.Id);
            ViewBag.Id = new SelectList(db.Fornecedores, "PessoaId", "PessoaId", pessoaJuridica.Id);
            return View(pessoaJuridica);
        }

        // GET: PessoasJuridicas/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PessoaJuridica pessoaJuridica = await db.PessoasJuridicas.FindAsync(id);
            if (pessoaJuridica == null)
            {
                return HttpNotFound();
            }
            return View(pessoaJuridica);
        }

        // POST: PessoasJuridicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                PessoaJuridica pessoaJuridica = await db.PessoasJuridicas.FindAsync(id);
                db.PessoasJuridicas.Remove(pessoaJuridica);
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
