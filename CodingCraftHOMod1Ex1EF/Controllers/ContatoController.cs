using AutoMapper;
using CodingCraftHOMod1Ex1EF.Models;
using CodingCraftHOMod1Ex1EF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CodingCraftHOMod1Ex1EF.Controllers
{
    public class ContatoController : System.Web.Mvc.Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Contato
        public ActionResult Index()
        {
            var clientes = db.Users.ToList();
            List<Contato> view_model = new List<Contato>();

            foreach (var item in clientes)
            {
                view_model.Add(Mapper.Map<Contato>(item));
            }

            ViewBag.Pessoas = view_model;

            return View(view_model);
        }

        // GET: Contato/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Contato/Create
        public ActionResult Create()
        {
            ViewBag.PessoaId = new SelectList(db.Users, "PessoaId", "UserName");            
            return View();
        }

        // POST: Contato/Create
        [HttpPost]
        public async Task<ActionResult> Create(Contato modelo)
        {
            try
            {
                Pessoa pessoa;

                if (ModelState.IsValid)
                {

                    if (modelo.TipoPessoa == Models.Enum.TipoPessoa.PESSOAFISICA)
                    {
                        pessoa = new PessoaFisica();
                        Mapper.Map(modelo, pessoa);
                    }
                    else
                    {
                        pessoa = new PessoaJuridica();
                        Mapper.Map(modelo, pessoa);
                    }

                    pessoa.Id = db.Users.Max(o => o.Id) + 1;

                    db.Users.Add(pessoa);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");                    
                }

                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Contato/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Contato/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contato/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Contato/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
