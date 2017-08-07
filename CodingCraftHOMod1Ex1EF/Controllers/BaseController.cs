using CodingCraftHOMod1Ex1EF.Models;
using CodingCraftHOMod1Ex1EF.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodingCraftHOMod1Ex1EF.Controllers
{
    public abstract class BaseController<T> : Controller where T : class, IEntidadePesquisa, new()
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Pesquisar(String filtro)
        {
            var lista = db.Set<T>().Where(s => s.FiltroPesquisa.Contains(filtro)).ToList();
            return View(lista);
        }
    }
}