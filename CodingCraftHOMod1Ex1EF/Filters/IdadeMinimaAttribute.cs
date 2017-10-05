using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace CodingCraftHOMod1Ex1EF.Filters
{
    public class IdadeMinimaAttribute : AuthorizeAttribute
    {
        private string claimType;

        public IdadeMinimaAttribute(String tipo)
        {

        }
       
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var user = httpContext.User as ClaimsPrincipal;


            if (user.HasClaim(o => o.Type == ClaimTypes.DateOfBirth))
            {
                var claim = user.Claims.First(o => o.Type == ClaimTypes.DateOfBirth);
                DateTime dataNascimento = DateTime.Parse(claim.Value);

                if ((DateTime.Now.Year - dataNascimento.Year) >= 18)
                {
                    return true;
                }                                     
            }
            return false;

        }
    }
}