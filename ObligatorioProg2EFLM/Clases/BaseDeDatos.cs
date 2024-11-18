using System;
using System.Collections.Generic;
using System.Web.Caching;

namespace ObligatorioProg2EFLM.Clases
{
    public abstract class BaseDeDatos
    {
        public static List<Cliente> listaClientes = new List<Cliente>();
        public static List<Tecnico> listaTecnicos = new List<Tecnico>();

        public static string UsuarioLogeado = "";

        public static string GetUsuarioLogeado()
        {
            return UsuarioLogeado;
        }
    }
}