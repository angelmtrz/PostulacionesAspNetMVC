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
    public class PostulanteController : BaseController
    {
        // GET: Postulante
        [RolAuthFilter(ConstantHelpers.Rol.Administrador, ConstantHelpers.Rol.Recepcionista)]
        public ActionResult Index()
        {
            var viewModel = new PostulanteIndexViewModel();

            var lista = Contexto.postulante.ToList();

            viewModel.ListaPostulantes = lista;

            return View(viewModel);
        }
        // GET: Postulante
        [RolAuthFilter(ConstantHelpers.Rol.Administrador, ConstantHelpers.Rol.Recepcionista)]
        public ActionResult Detail(int postulanteId)
        {
            var viewModel = new PostulanteDetailViewModel();

            viewModel.postulanteId = postulanteId;
            viewModel.postulanteDetail = Contexto.postulante.Find(postulanteId);

            return View(viewModel);
        }
        // DELETE: Postulante
        [RolAuthFilter(ConstantHelpers.Rol.Administrador, ConstantHelpers.Rol.Recepcionista)]
        public ActionResult Delete(int postulanteId)
        {
            try
            {
                var objPostulante = Contexto.postulante
                    .FirstOrDefault(e => e.postulanteId == postulanteId);

                if (objPostulante == null)
                {
                    TempData["MensajePostulante"] = "El registro no existe en BD.";
                    return RedirectToAction("Index");
                }

                Contexto.postulante.Remove(objPostulante);
                Contexto.SaveChanges();
                TempData["MensajePostulante"] = "El registro fue eliminado exitosamente.";
            }
            catch (Exception ex)
            {
                TempData["MensajePostulante"] = "Ocurrio un error: " + ex.Message;
            }

            return RedirectToAction("Index");
        }
        // SHOW: Postulante
        [RolAuthFilter(ConstantHelpers.Rol.Administrador, ConstantHelpers.Rol.Recepcionista)]
        public ActionResult AddEdit(int? postulanteId)
        {
            var viewModel = new PostulanteAddEditViewModel();

            viewModel.postulanteId = postulanteId;
            viewModel.CargarDatos(Contexto);

            return View(viewModel);
        }
        // POST: Especialidad
        [HttpPost]
        [ValidateAntiForgeryToken]
        [RolAuthFilter(ConstantHelpers.Rol.Administrador, ConstantHelpers.Rol.Recepcionista)]
        public ActionResult AddEdit(PostulanteAddEditViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    viewModel.postulanteId = viewModel.postulanteId;
                    viewModel.CargarDatos(Contexto);

                    TryUpdateModel(viewModel);

                    TempData["MensajeAddEditPostulante"] = "Por favor, complete los campos requeridos.";
                    return View(viewModel);
                }

                postulante objPostulante = null;

                if (viewModel.postulanteId.HasValue)
                {
                    objPostulante = Contexto.postulante.Find(viewModel.postulanteId);
                }
                else
                {
                    objPostulante = new postulante();
                    //objPostulante.fechaPostulacion = DateTime.Now;

                    Contexto.postulante.Add(objPostulante);
                }
                
                objPostulante.nombreCompleto = viewModel.nombreCompleto;
                objPostulante.dni = viewModel.dni;
                objPostulante.telefono = viewModel.telefono;
                objPostulante.fechaPostulacion = viewModel.fechaPostulacion;
                objPostulante.especialidadId = viewModel.especialidad;

                Contexto.SaveChanges();
                TempData["MensajeEspecialidad"] = "La consulta fue procesada exitosamente.";
            }
            catch (Exception ex)
            {
                viewModel.postulanteId = viewModel.postulanteId;
                viewModel.CargarDatos(Contexto);

                TryUpdateModel(viewModel);

                TempData["MensajeAddEditPostulante"] = "Hubo un error: " + ex.Message;
                return View(viewModel);
            }

            return RedirectToAction("Index");
        }
    }
}