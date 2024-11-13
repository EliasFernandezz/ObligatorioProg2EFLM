using System;
using System.Collections.Generic;

namespace ObligatorioProg2EFLM.Clases
{
    public abstract class BaseDeDatos
    {
        public static List<Cliente> listaClientes = new List<Cliente>();
        public static List<Tecnico> listaTecnicos = new List<Tecnico>();


        public static bool ValidarCedula(string cedula) //validar cedula
        {
            cedula = cedula.Trim();
            cedula = cedula.Replace(".", "");
            cedula = cedula.Replace("-", "");


            if (cedula.Length != 8)
            {
                return false;
            }
            else
            {
                List<int> constante = new List<int>();
                constante.Add(2);
                constante.Add(9);
                constante.Add(8);
                constante.Add(7);
                constante.Add(6);
                constante.Add(3);
                constante.Add(4);

                string numCedula = cedula.Substring(0, 7);
                int numVerificador = Convert.ToInt32(cedula.Substring(7, 1));

                int suma = 0;
                for (int i = 0; i < 7; i++)
                {
                    suma += Convert.ToInt32(numCedula[i] * constante[i]);
                    if (numCedula[i] >= 10)
                    {
                        numCedula[i] = (numCedula[i]);
                    }
                }

                int verificadorCalculado = 10 - (suma % 10);
            }
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

        public static bool repeticionCliente(string cedula, int? telefono, string email)
        {
            bool cliRepiteCedula = false;
            bool cliRepiteTelefono = false;
            bool cliRepiteEmail = false;

            bool clienteRepetido = false;

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
                clienteRepetido = false;
            }
            else
            {
                clienteRepetido = true;
            }
            return clienteRepetido;
        }


        /*
                    Cliente nuevoCliente = new Cliente(nombre, apellido, cedula, direccion, telefono, email);
                    listaClientes.Add(nuevoCliente);
        */

        public static void validarYAgregarCliente(string nombre, string apellido, string cedula, string direccion, int? telefono, string email)
        {
            bool cliRepetido;
            cliRepetido = BaseDeDatos.repeticionCliente(cedula, telefono, email);

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

        public static bool repeticionTecnico(string cedula)
        {
            bool tecRepiteCedula = false;

            bool tecnicoRepetido = false;

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
                tecnicoRepetido = false;
            }
            else
            {
                tecnicoRepetido = true;
            }
            return tecnicoRepetido;
        }

        /*
                    Cliente nuevoTecnico = new Tecnico(nombre, apellido, cedula, especialidad);
                    listaTecnicos.Add(nuevoTecnico);
        */

        public static void validarYAgregarTecnico(string nombre, string apellido, string cedula, string especialidad)
        {
            bool tecRepetido;
            tecRepetido = BaseDeDatos.repeticionTecnico(cedula);

        }
    }
}