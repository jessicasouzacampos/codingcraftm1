using CodingCraftHOMod1Ex1EF.Models;

namespace CodingCraftHOMod1Ex1EF.Controllers
{
    public abstract class Controller : System.Web.Mvc.Controller
    {
        protected ApplicationDbContext db = new ApplicationDbContext();
    }
}