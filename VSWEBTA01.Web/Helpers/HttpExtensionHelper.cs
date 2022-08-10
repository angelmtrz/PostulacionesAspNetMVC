using System;
using System.Web;

namespace VSWEBTA01.Web.Helpers
{
    public static class HttpExtensionHelper
    {
        public static int ToInteger(this object value)
        {
            return Convert.ToInt32(value);
        }

        public static int GetUsuarioId(this HttpSessionStateBase session)
        {
            return session["UsuarioId"].ToInteger();
        }

        public static string GetNombre(this HttpSessionStateBase session)
        {
            return session["Nombre"].ToString();
        }

        public static string GetRol(this HttpSessionStateBase session)
        {
            return (session["Rol"] ?? "").ToString();
        }

        public static bool HasRol(this HttpSessionStateBase session, string rol)
        {
            return session.GetRol() == rol;
        }
    }
}