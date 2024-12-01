using System;
using System.Collections.Generic;

namespace ObligatorioProg2EFLM.Clases
{
    public static class BaseDeDatos
    {

        public static List<Cliente> listaClientes { get; set; }
        public static List<Tecnico> listaTecnicos { get; set; }
        public static List<OrdenesDeTrabajo> listaOrdenes { get; set; }

        public static string UsuarioLogeado = "";

        static BaseDeDatos()
        {
            InicializarClientes();
            InicializarTecnicos();
            listaOrdenes = new List<OrdenesDeTrabajo>
            {
                new OrdenesDeTrabajo(1,"4.763.296-7","3.927.191-1","Se me tapó el caño", DateTime.Now,"Pendiente") //prueba para confirmar el uso correcto de pagina de inicio
            };
        }

        private static void InicializarClientes()
        {
            listaClientes = new List<Cliente>
            {
            new Cliente("Rogelio", "Paez", "4.763.296-7", "av.italia", "096245889", "roge@gmail.com"),
            new Cliente("Agusto", "Gomez", "5.731.924-0", "calle samuel", "097189425", "agustito50@gmail.com"),
            new Cliente("Francisco", "Darboux", "5.231.663-5", "calle udine", "091085311", "darboux200@gmail.com")
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

        public static bool validarCedula(string cedula)
        {
            cedula = cedula.Trim();
            cedula = cedula.Replace(".", ""); //se quitan los espacios vacios, puntos y guiones de la cedula para que conserve un largo de 8
            cedula = cedula.Replace("-", "");

            if (cedula.Length != 8)
            {
                return false;
            }
            else
            {
                List<int> constante = new List<int>(); //se crea una lista con los numeros de la constante por los que se multiplica el numero de cedula sin verificador
                constante.Add(2);
                constante.Add(9);
                constante.Add(8);
                constante.Add(7);
                constante.Add(6);
                constante.Add(3);
                constante.Add(4);

                string numSinVerificador = cedula.Substring(0, 7);
                int digitoVerificador = Convert.ToInt32(cedula.Substring(7, 1));

                int suma = 0;
                for (int i = 0; i < 7; i++)
                {
                    suma += (Convert.ToInt32(numSinVerificador[i].ToString()) * constante[i]);  //se suman las multiplicaciones de los numeros de la cedula sin verificador y la constante que
                                                                                                //estan en la misma posicion
                }

                int digitoCalculado = 10 - (suma % 10);  //se divide la suma total por 10, se toma el resto y a 10 se le resta el resto, el resultado de la resta es el digito verificador
                if (digitoCalculado == 10)
                {
                    digitoCalculado = 0;
                }

                if (digitoCalculado == digitoVerificador)
                {
                    return true; // si el digito calculado es igual al del ingreso de la cedula se retorna true
                }
                else
                {
                    return false; //de lo contrario se retorna false
                }

            }
        }

        public static string puntosGuionCedula(string cedula)
        {
            switch (cedula.Length)
            {
                case 8:
                    cedula = cedula.Substring(0, 1) + "." + cedula.Substring(1, 3) + "." + cedula.Substring(4, 3) + "-" + cedula.Substring(7, 1);
                    return cedula;

                case 11:
                    return cedula;

                default:
                    return cedula;
            }
        }

    }
}