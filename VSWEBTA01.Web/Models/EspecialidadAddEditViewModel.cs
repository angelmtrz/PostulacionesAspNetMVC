using VSWEBTA01.Modelos.Contexto;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VSWEBTA01.Web.Models
{
    public class EspecialidadAddEditViewModel
    {
        public int? especialidadId { get; set; }

        [Required]
        public string nombre { get; set; }

        [Required]
        [AllowHtml]
        public string descripcion { get; set; }

        public void CargarDatos(VSWEBTA1Entities Contexto)
        {
            if (this.especialidadId.HasValue)
            {
                var objConsulta = Contexto.especialidad.Find(this.especialidadId);
                this.especialidadId = objConsulta.especialidadId;
                this.nombre = objConsulta.nombre;
                this.descripcion = objConsulta.descripcion;
            }
        }
    }
}