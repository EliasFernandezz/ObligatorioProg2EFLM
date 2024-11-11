using System.Collections.Generic;

namespace ObligatorioProg2EFLM.Clases
{
    public abstract class BaseDeDatos
    {
        public static List<Cliente> listaClientes = new List<Cliente>();
        public static List<Tecnico> listaTecnicos = new List<Tecnico>();

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
            bool cliRepiteCedula = false;
            bool cliRepiteTelefono = false;
            bool cliRepiteEmail = false;

            for (int i = 0; i < listaClientes.Count; i++)
            {
                if (listaClientes[i].getCedula() == cedula)
                {
                    cliRepiteCedula = true;
                    break;
                }

                if (listaClientes[i].getTelefono() == telefono)
                {
                    cliRepiteTelefono = true;
                    break;
                }

                if (listaClientes[i].getEmail() == email)
                {
                    cliRepiteEmail = true;
                    break;
                }
            }

            if (cliRepiteCedula == false && cliRepiteTelefono == false && cliRepiteEmail == false)
            {
                Cliente nuevoCliente = new Cliente(nombre, apellido, cedula, direccion, telefono, email);
                listaClientes.Add(nuevoCliente);
            }
        }


        public static void preCargaTecnicos()
        {
            Tecnico tecnico1 = new Tecnico("Mariano", "Fernandez", "1723996-2", "Sanitario");
            Tecnico tecnico2 = new Tecnico("Federico", "Lamborghini", "8754848-0", "Instalador de aire");
            Tecnico tecnico3 = new Tecnico("Violeta", "Sechous", "5891546-3", "Albañil");

            listaTecnicos.Add(tecnico1);
            listaTecnicos.Add(tecnico2);
            listaTecnicos.Add(tecnico3);
        }

        public static void agregarTecnico(string nombre, string apellido, string cedula, string especialidad)
        {
            bool tecRepiteCedula = false;
;
            for (int i = 0; i < listaTecnicos.Count; i++)
            {
                if (listaTecnicos[i].getCedula() == cedula)
                {
                    tecRepiteCedula = true;
                    break;
                }
            }

            if (tecRepiteCedula == false)
            {
                Tecnico nuevoTecnico = new Tecnico(nombre, apellido, cedula, especialidad);
                listaTecnicos.Add(nuevoTecnico);
            }
        }
    }
}