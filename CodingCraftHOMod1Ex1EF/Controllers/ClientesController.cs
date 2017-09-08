using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using CodingCraftHOMod1Ex1EF.Models;
using CodingCraftHOMod1Ex1EF.Models;
using System.Linq;
using System;

namespace CodingCraftHOMod1Ex1EF.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Clientes
        public async Task<ActionResult> Index(PessoasPorDadosBasicosViewModel viewModel)
        {
            IQueryable<Pessoa> pessoas = db.Pessoas;

                    
            if(viewModel.Tipo == Models.Enum.TipoPessoa.PESSOAFISICA)
            {
                if (!String.IsNullOrEmpty(viewModel.TermoPesquisa))
                {
                    pessoas = db.PessoasFisicas
                    .Where(s => s.UserName.Contains(viewModel.TermoPesquisa) || s.Cpf.Contains(viewModel.TermoPesquisa));
                }
                else
                {
                    pessoas = db.PessoasFisicas;
                }
            }
            else if(viewModel.Tipo == Models.Enum.TipoPessoa.PESSOAJURIDICA)
            {
                if (!String.IsNullOrEmpty(viewModel.TermoPesquisa))
                {
                    pessoas = db.PessoasJuridicas
                    .Where(s => s.UserName.Contains(viewModel.TermoPesquisa) || s.Cnpj.Contains(viewModel.TermoPesquisa));
                }
                else
                {
                    pessoas = db.PessoasJuridicas;
                }                                       
            }                
            

            if (pessoas != null)
            {
                viewModel.Resultados = await pessoas.ToListAsync();
            }

            return View(viewModel);
        }

        // GET: Clientes/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = await db.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Users, "Id", "UserName");
            return View();
        }

        // POST: Clientes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PessoaId")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(cliente);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.Users, "Id", "UserName", cliente.PessoaId);
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }     
          

            var resultado = 
                db.PessoasFisicas
                .Select(o => new { ID = o.Id, NOME = o.UserName, CPF = o.Cpf, CNPJ = string.Empty, EMAIL = o.Email, TELEFONE = o.PhoneNumber}).Where(o => o.ID == new Guid(id)).ToList()
                .Concat(
                db.PessoasJuridicas
                .Select(o => new { ID = o.Id, NOME = o.UserName, CPF = string.Empty, CNPJ = o.Cnpj, EMAIL = o.Email, TELEFONE = o.PhoneNumber}).Where(o => o.ID == new Guid(id)).ToList());

            if (resultado == null)
            {
                return HttpNotFound();
            }
            //TODO posso fazer esse ToString()
            PessoaViewModel viewModel = new PessoaViewModel(resultado.First().ID.ToString(), resultado.First().NOME, resultado.First().CPF, resultado.First().CNPJ, resultado.First().EMAIL, resultado.First().TELEFONE);

            ViewBag.PessoaId = new SelectList(db.Users, "Id", "UserName", resultado.First().ID);
            return View(viewModel);
        }

        // POST: Clientes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,UserName,Cpf,Cnpj,Email,PhoneNumber")] PessoaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                
                if (viewModel.Cpf != null)
                {                                        
                    var pessoa = new PessoaFisica(viewModel.Cpf,viewModel.Id, viewModel.UserName, viewModel.Email, viewModel.PhoneNumber);
                    db.PessoasFisicas.Attach(pessoa);
                    db.Entry(pessoa).State = EntityState.Modified;
                    
                }
                else
                {                                        
                    var pessoa = new PessoaJuridica(viewModel.Cnpj, viewModel.Id, viewModel.UserName, viewModel.Email, viewModel.PhoneNumber);
                    db.PessoasJuridicas.Attach(pessoa);
                    db.Entry(pessoa).State = EntityState.Modified;
                }

                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PessoaId = new SelectList(db.Users, "Id", "UserName", viewModel.Id);
            return View(viewModel);
        }

        // GET: Clientes/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = await db.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Cliente cliente = await db.Clientes.FindAsync(id);
            db.Clientes.Remove(cliente);
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
