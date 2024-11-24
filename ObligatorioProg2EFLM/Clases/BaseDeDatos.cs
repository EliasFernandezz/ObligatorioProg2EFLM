using System.Collections.Generic;

namespace ObligatorioProg2EFLM.Clases
{
    public abstract class BaseDeDatos
    {
        public static int iTecnicos = 0;
        public static List<Cliente> listaClientes = new List<Cliente>();
        public static List<Tecnico> listaTecnicos = new List<Tecnico>();

        public static string UsuarioLogeado = "";

        public static string GetUsuarioLogeado()
        {
            return UsuarioLogeado;
        }
        public static int GetiTecnicos() => iTecnicos;
        public static void SetiTecnicos(int iTecnico) => iTecnicos = iTecnico;
    }
}