using CodingCraftHOMod1Ex1EF.ViewModels;

namespace CodingCraftHOMod1Ex1EF.Controllers
{
    public abstract class Controller : System.Web.Mvc.Controller
    {
        protected ApplicationDbContext db = new ApplicationDbContext();

    }
}