using VSWEBTA01.Modelos.Contexto;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VSWEBTA01.Web.Models
{
    public class PostulanteAddEditViewModel
    {

        public int? postulanteId { get; set; }

        [Required]
        public string nombreCompleto { get; set; }

        [Required]
        public string dni { get; set; }

        [Required]
        public string telefono { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime fechaPostulacion { get; set; }

        [Required]
        public int especialidad { get; set; }

        public List<especialidad> ListEspecialidades { get; set; }

        public void CargarDatos(VSWEBTA1Entities Contexto)
        {
            this.ListEspecialidades = Contexto.especialidad.OrderBy(e => e.nombre).ToList();

            if (this.postulanteId.HasValue)
            {
                var objConsulta = Contexto.postulante.Find(this.postulanteId);
                this.postulanteId = objConsulta.postulanteId;
                this.nombreCompleto = objConsulta.nombreCompleto;
                this.dni = objConsulta.dni;
                this.telefono = objConsulta.telefono;
                this.fechaPostulacion = objConsulta.fechaPostulacion;
                this.especialidad = objConsulta.especialidadId;
            }
        }

    }
}