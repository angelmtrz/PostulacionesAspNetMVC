using VSWEBTA01.Modelos.Contexto;
using VSWEBTA01.Modelos.Helpers;
using VSWEBTA01.Web.Filters;
using VSWEBTA01.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VSWEBTA01.Web.Controllers
{
    [RolAuthFilter(ConstantHelpers.Rol.Administrador)]
    public class UsuarioController : BaseController
    {
        // GET: Usuario
        public ActionResult Index()
        {
            var viewModel = new UsuarioIndexViewModel();

            var lista = Contexto.usuario.ToList();

            viewModel.ListaUsuarios = lista;

            return View(viewModel);
        }
    }
}