using ObligatorioProg2EFLM.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace ObligatorioProg2EFLM
{
    public partial class webClientes : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (BaseDeDatos.listaClientes.Count == 0)
                {
                    Cliente cliente1 = new Cliente("Rogelio", "Paez", "4.763.296-7", "av.italia", 096245889, "roge@gmail.com");
                    Cliente cliente2 = new Cliente("Agusto", "Gomez", "5.731.924-0", "calle samuel", 097189425, "agustito50@gmail.com");
                    Cliente cliente3 = new Cliente("Francisco", "Darboux", "5.231.663-5", "calle udine", 091085311, "darboux200@gmail.com");

                    preCargaClientes(cliente1, cliente2, cliente3);
                }
                recargarGvClientes();
            }
        }

        protected void agregarCliente_click(object sender, EventArgs e)
        {
            string nombre = null;
            string apellido = null;
            string cedula = null;
            string direccion = null;
            int? telefono = null;
            string email = null;


            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrEmpty(txtCedula.Text))
            {
                lblErrorIngreso.Visible = true;

                vaciarCamposCliente();
            }
            else
            {
                if (string.IsNullOrEmpty(txtNombre.Text) == false && string.IsNullOrEmpty(txtApellido.Text) == false &&
                   string.IsNullOrEmpty(txtCedula.Text) == false && string.IsNullOrEmpty(txtDireccion.Text) == false &&
                   string.IsNullOrEmpty(txtTelefono.Text) == false && string.IsNullOrEmpty(txtEmail.Text) == false)
                {

                    lblErrorIngreso.Visible = false;

                    nombre = txtNombre.Text;
                    apellido = txtApellido.Text;
                    cedula = txtCedula.Text;
                    direccion = txtDireccion.Text;
                    telefono = Convert.ToInt32(txtTelefono.Text);
                    email = txtEmail.Text;


                    validarYAgregarCliente(nombre, apellido, cedula, direccion, telefono, email);

                    recargarGvClientes();

                    vaciarCamposCliente();
                }
                else
                {
                    lblErrorIngreso.Visible = false;

                    nombre = txtNombre.Text;
                    apellido = txtApellido.Text;
                    cedula = txtCedula.Text;

                    validarYAgregarCliente(nombre, apellido, cedula, direccion, telefono, email);

                    recargarGvClientes();

                    vaciarCamposCliente();
                }
            }

        }
        protected void recargarGvClientes()
        {
            gvClientes.DataSource = BaseDeDatos.listaClientes;
            gvClientes.DataBind();
        }

        protected void vaciarCamposCliente()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCedula.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
        }
        public void preCargaClientes(Cliente cliente1, Cliente cliente2, Cliente cliente3)
        {
            BaseDeDatos.listaClientes.Add(cliente1);
            BaseDeDatos.listaClientes.Add(cliente2);
            BaseDeDatos.listaClientes.Add(cliente3);
        }



        public void validarYAgregarCliente(string nombre, string apellido, string cedula, string direccion, int? telefono, string email)
        {
            bool cliRepetido;
            bool cedulaValida;
            cedulaValida = validarCedula(cedula);
            cliRepetido = repeticionCliente(cedula, telefono, email);

            if (cedulaValida == true && cliRepetido == false)
            {
                Cliente nuevoCliente = new Cliente(nombre, apellido, cedula, direccion, telefono, email);
                BaseDeDatos.listaClientes.Add(nuevoCliente);
            }
            else if (cedulaValida == false)
            {
                lblErrorValidacion.Text = "la cedula ingresada no es valida";
                lblErrorValidacion.Visible = true;
            }
            else if (cliRepetido == true)
            {
                lblErrorValidacion.Text = "este cliente ya existe (cedula, telefono o email repetido)";
                lblErrorValidacion.Visible = true;
            }

        }

        public bool validarCedula(string cedula)
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
                    cedula = cedula.Substring(0, 1) + "." + cedula.Substring(1, 3) + "." + cedula.Substring(4, 3) + "-" + digitoVerificador;
                    return true; // si el digito calculado es igual al del ingreso de la cedula se retorna true
                }
                else
                {
                    return false; //de lo contrario se retorna false
                }

            }
        }

        public bool repeticionCliente(string cedula, int? telefono, string email)
        {
            bool cliRepiteCedula = false;
            bool cliRepiteTelefono = false;
            bool cliRepiteEmail = false;

            bool clienteRepetido = false;

            for (int i = 0; i < BaseDeDatos.listaClientes.Count; i++)
            {
                if (BaseDeDatos.listaClientes[i].getCedula() == cedula)
                {
                    cliRepiteCedula = true;
                    break;
                }

                if (BaseDeDatos.listaClientes[i].getTelefono() == telefono)
                {
                    cliRepiteTelefono = true;
                    break;
                }

                if (BaseDeDatos.listaClientes[i].getEmail() == email)
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


        protected void borrarCliente(object sender, GridViewDeleteEventArgs e)
        {

            if (e.RowIndex >= 0 && e.RowIndex < BaseDeDatos.listaClientes.Count())
            {
                BaseDeDatos.listaClientes.RemoveAt(e.RowIndex);
                recargarGvClientes();
            }
        }

        protected void editarCliente(object sender, GridViewEditEventArgs e)
        {
            gvClientes.EditIndex = e.NewEditIndex;
            recargarGvClientes();
            lblEdicion.Visible = true;
        }

        protected void cancelarEdicionCliente(object sender, GridViewCancelEditEventArgs e)
        {
            gvClientes.EditIndex = -1;
            recargarGvClientes();
            lblEdicion.Visible = false;
        }

        protected void actualizarCliente(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow fila = gvClientes.Rows[e.RowIndex];

            string nombreActualizado = (fila.Cells[0].Controls[0] as TextBox).Text;
            string apellidoActualizado = (fila.Cells[1].Controls[0] as TextBox).Text;
            string cedulaActualizada = (fila.Cells[2].Controls[0] as TextBox).Text;
            string direccionActualizada = (fila.Cells[3].Controls[0] as TextBox).Text;
            int telefonoActualizado = Convert.ToInt32((fila.Cells[4].Controls[0] as TextBox).Text);
            string emailActualizado = (fila.Cells[5].Controls[0] as TextBox).Text;

            BaseDeDatos.listaClientes[e.RowIndex].setNombre(nombreActualizado);
            BaseDeDatos.listaClientes[e.RowIndex].setApellido(apellidoActualizado);
            BaseDeDatos.listaClientes[e.RowIndex].setCedula(cedulaActualizada);
            BaseDeDatos.listaClientes[e.RowIndex].setDireccion(direccionActualizada);
            BaseDeDatos.listaClientes[e.RowIndex].setTelefono(telefonoActualizado);
            BaseDeDatos.listaClientes[e.RowIndex].setEmail(emailActualizado);

            gvClientes.EditIndex = -1;
            recargarGvClientes();
            lblEdicion.Visible = false;
        }
    }
}