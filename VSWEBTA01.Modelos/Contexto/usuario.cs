//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VSWEBTA01.Modelos.Contexto
{
    using System;
    using System.Collections.Generic;
    
    public partial class usuario
    {
        public int usuarioId { get; set; }
        public string codigo { get; set; }
        public string email { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string password { get; set; }
        public bool bloqueado { get; set; }
        public int rolId { get; set; }
    
        public virtual rol rol { get; set; }
    }
}
