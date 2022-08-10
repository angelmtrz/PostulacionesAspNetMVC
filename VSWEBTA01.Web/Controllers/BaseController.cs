using VSWEBTA01.Modelos.Contexto;
using System.Web.Mvc;

namespace VSWEBTA01.Web.Controllers
{
    public class BaseController : Controller
    {

        protected VSWEBTA1Entities Contexto;

        public BaseController()
        {
            Contexto = new VSWEBTA1Entities();
        }
    }
}