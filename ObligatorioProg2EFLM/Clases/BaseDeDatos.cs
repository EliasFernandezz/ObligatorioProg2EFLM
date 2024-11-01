using System.Collections.Generic;

namespace ObligatorioProg2EFLM.Clases
{
    public abstract class BaseDeDatos
    {
        public static List<Cliente> listaClientes = new List<Cliente>();


        static BaseDeDatos()
        {
            preCargaClientes();
        }

        public static void preCargaClientes()
        {
            Cliente cliente1 = new Cliente("Rogelio", "Paez", "4763296-7", "av.italia", 096245889, "roge@gmail.com");
            Cliente cliente2 = new Cliente("Agusto", "Gomez", "5731924-9", "calle samuel", 097189425, "agustito50@gmail.com");
            Cliente cliente3 = new Cliente("Francisco", "Darboux", "4763296-7", "calle udine", 091085311, "darboux200@gmail.com");

            listaClientes.Add(cliente1);
            listaClientes.Add(cliente2);
            listaClientes.Add(cliente3);
        }

        public static void agregarCliente(string nombre, string apellido, string cedula, string direccion, int telefono, string email)
        {
            bool excCedula = false;
            bool excTelefono = false;
            bool excEmail = false;

            for (int i = 0; i <= listaClientes.Count; i++)
            {
                if (listaClientes[i].getCedula() == cedula)
                {
                    excCedula = true;
                    break;
                }

                if (listaClientes[i].getTelefono() == telefono)
                {
                    excTelefono = true;
                    break;
                }

                if (listaClientes[i].getEmail() == email)
                {
                    excEmail = true;
                    break;
                }
            }

            if (excCedula == false && excTelefono == false && excEmail == false)
            {
                Cliente nuevoCliente = new Cliente(nombre, apellido, cedula, direccion, telefono, email);
                listaClientes.Add(nuevoCliente);
            }
        }
    }
}