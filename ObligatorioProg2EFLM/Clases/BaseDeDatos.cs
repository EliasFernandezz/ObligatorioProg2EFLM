using System;
using System.Collections.Generic;

namespace ObligatorioProg2EFLM.Clases
{
    public static class BaseDeDatos
    {

        public static List<Cliente> listaClientes { get; set; }
        public static List<Tecnico> listaTecnicos { get; set; }
        public static List<OrdenesDeTrabajo> listaOrdenes { get; set; }

        static BaseDeDatos()
        {
            InicializarClientes();
            InicializarTecnicos();
            listaOrdenes = new List<OrdenesDeTrabajo>
            {
                new OrdenesDeTrabajo(1,"4.763.296-7","3.927.191-1","Se me tapó el caño", DateTime.Now,"Pendiente")
            };
        }

        private static void InicializarClientes()
        {
            listaClientes = new List<Cliente>
            {
            new Cliente("Rogelio", "Paez", "4.763.296-7", "av.italia", 096245889, "roge@gmail.com"),
            new Cliente("Agusto", "Gomez", "5.731.924-0", "calle samuel", 097189425, "agustito50@gmail.com"),
            new Cliente("Francisco", "Darboux", "5.231.663-5", "calle udine", 091085311, "darboux200@gmail.com")
            };
        }

        private static void InicializarTecnicos()
        {
            listaTecnicos = new List<Tecnico>
            {
                new Tecnico("Mariano", "Fernandez", "3.927.191-1", "Sanitario"),
                new Tecnico("Federico", "Lamborghini", "2.118.202-3", "Instalador de aire"),
                new Tecnico("Violeta", "Sechous", "4.277.703-5", "Albañil")
            };
        }

        public static string UsuarioLogeado = "";
    }
}