using VSWEBTA01.Modelos.Contexto;
using VSWEBTA01.Modelos.Helpers;
using VSWEBTA01.Web.Models;
using VSWEBTA01.Web.Controllers;
using VSWEBTA01.Web.Filters;
using VSWEBTA01.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Security.Application;

namespace VSWEBTA01.Web.Controllers
{
    public class EspecialidadController : BaseController
    {
        // GET: Especialidad
        [RolAuthFilter(ConstantHelpers.Rol.Administrador, ConstantHelpers.Rol.Recepcionista)]
        public ActionResult Index()
        {
            var viewModel = new EspecialidadIndexViewModel();

            var lista = Contexto.especialidad.ToList();

            viewModel.ListaEspecialidades = lista;

            return View(viewModel);
        }
        // DELETE: Especialidad
        [RolAuthFilter(ConstantHelpers.Rol.Administrador)]
        public ActionResult Delete(int especialidadId)
        {
            try
            {
                var objEspecialidad = Contexto.especialidad
                    .FirstOrDefault(e => e.especialidadId == especialidadId);

                if (objEspecialidad == null)
                {
                    TempData["MensajeEspecialidad"] = "El registro no existe en BD.";
                    return RedirectToAction("Index");
                }

                Contexto.especialidad.Remove(objEspecialidad);
                Contexto.SaveChanges();
                TempData["MensajeEspecialidad"] = "El registro fue eliminado exitosamente.";
            }
            catch (Exception ex)
            {
                TempData["MensajeEspecialidad"] = "Ocurrio un error: " + ex.Message;
            }

            return RedirectToAction("Index");
        }
        // SHOW: Especialidad
        [RolAuthFilter(ConstantHelpers.Rol.Administrador)]
        public ActionResult AddEdit(int? especialidadId)
        {
            var viewModel = new EspecialidadAddEditViewModel();

            viewModel.especialidadId = especialidadId;
            viewModel.CargarDatos(Contexto);

            return View(viewModel);
        }
        // POST: Especialidad
        [HttpPost]
        [ValidateAntiForgeryToken]
        [RolAuthFilter(ConstantHelpers.Rol.Administrador)]
        public ActionResult AddEdit(EspecialidadAddEditViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    viewModel.especialidadId = viewModel.especialidadId;
                    viewModel.CargarDatos(Contexto);

                    TryUpdateModel(viewModel);

                    TempData["MensajeAddEditEspecialidad"] = "Por favor, complete los campos requeridos.";
                    return View(viewModel);
                }

                especialidad objEspecialidad = null;

                if (viewModel.especialidadId.HasValue)
                {
                    objEspecialidad = Contexto.especialidad.Find(viewModel.especialidadId);
                }
                else
                {
                    objEspecialidad = new especialidad();
                
                    Contexto.especialidad.Add(objEspecialidad);
                }

                objEspecialidad.nombre = viewModel.nombre;

                string descripcionOriginal = viewModel.descripcion;
                string descripcionValidado = Sanitizer.GetSafeHtmlFragment(viewModel.descripcion);

                objEspecialidad.descripcion = descripcionValidado;
                objEspecialidad.nombre = viewModel.nombre;

                Contexto.SaveChanges();
                TempData["MensajeEspecialidad"] = "La consulta fue procesada exitosamente.";
            }
            catch (Exception ex)
            {
                viewModel.especialidadId = viewModel.especialidadId;
                viewModel.CargarDatos(Contexto);

                TryUpdateModel(viewModel);

                TempData["MensajeAddEditEspecialidad"] = "Hubo un error: " + ex.Message;
                return View(viewModel);
            }

            return RedirectToAction("Index");
        }
    }
}