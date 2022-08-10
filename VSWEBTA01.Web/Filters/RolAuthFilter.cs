using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using VSWEBTA01.Web.Helpers;

namespace VSWEBTA01.Web.Filters
{
    public class RolAuthFilter : AuthorizeAttribute 
    {
        private string[] _rol;

        public RolAuthFilter(params string[] rol)
        {
            _rol = rol; 
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (_rol.Length == 0 ||
                filterContext.HttpContext.Session["UsuarioId"] == null)
            {
                filterContext.Result = GetRedirectToRoute();
            }

            if (!_rol.Any(e => filterContext.HttpContext.Session.HasRol(e)))
            {
                filterContext.Result = GetRedirectToRoute();
            }
        }

        private RedirectToRouteResult GetRedirectToRoute()
        {
            return new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Auth", action = "Index", area = "" }));
        }
    }
}