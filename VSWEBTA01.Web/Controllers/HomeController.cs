using VSWEBTA01.Modelos.Contexto;
using VSWEBTA01.Modelos.Helpers;
using VSWEBTA01.Web.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VSWEBTA01.Web.Controllers
{
    [RolAuthFilter(ConstantHelpers.Rol.Administrador, ConstantHelpers.Rol.Recepcionista)]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}