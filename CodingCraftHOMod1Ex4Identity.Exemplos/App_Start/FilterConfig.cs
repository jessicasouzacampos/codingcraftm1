using System.Web.Mvc;

namespace CodingCraftHOMod1Ex4Identity.Exemplos
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
