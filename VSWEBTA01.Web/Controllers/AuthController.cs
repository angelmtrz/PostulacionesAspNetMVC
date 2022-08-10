using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VSWEBTA01.Web.Controllers
{
    public class AuthController : BaseController
    {
        public ActionResult Index()
        {
            Session.Clear();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string username, string password)
        {
            var objUsuario = Contexto.usuario
                .FirstOrDefault(e => e.codigo == username && e.password == password);

            if (objUsuario != null)
            {
                if (objUsuario.bloqueado)
                {
                    ViewBag.MensajeLogin = "El usuario se encuentra bloqueado.";
                    return View();
                }

                Session["usuarioId"] = objUsuario.usuarioId;
                Session["rol"] = objUsuario.rol.nombre;
                Session["nombre"] = $"{objUsuario.apellido}, {objUsuario.nombre}";

                return RedirectToAction("Index", "Home");
            }

            ViewBag.MensajeLogin = "El usuario o contraseña son incorrectos.";
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
    }
}