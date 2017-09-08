using CodingCraftHOMod1Ex1EF.ViewModels.Interfaces;
using System;
using System.Linq;
using System.Web.Mvc;

namespace CodingCraftHOMod1Ex1EF.Controllers
{
    public abstract class Controller<T> : Controller where T : class, IEntidadePesquisa, new()
    {
        public ActionResult Pesquisar(String filtro)
        {
            var lista = db.Set<T>().Where(s => s.TermoPesquisa.Contains(filtro)).ToList();
            return View(lista);
        }
    }
}