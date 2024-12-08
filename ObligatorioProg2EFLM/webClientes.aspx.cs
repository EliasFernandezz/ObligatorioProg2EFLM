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
                recargarGvClientes();
            }
        }

        protected void agregarCliente_click(object sender, EventArgs e)
        {
            lblErrorIngreso.Visible = false;
            lblErrorValidacion.Visible = false;
            lblErrorEdicion.Visible = false;

            string nombre = null;
            string apellido = null;
            string cedula = null;
            string direccion = null;
            string telefono = null;
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
                    telefono = txtTelefono.Text;
                    email = txtEmail.Text;

                    cedula = BaseDeDatos.puntosGuionCedula(cedula);

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
                    direccion = txtDireccion.Text;
                    telefono = txtTelefono.Text;
                    email = txtEmail.Text;

                    cedula = BaseDeDatos.puntosGuionCedula(cedula);

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

        public void validarYAgregarCliente(string nombre, string apellido, string cedula, string direccion, string telefono, string email)
        {
            bool cedulaValida;
            bool telefonoValido;
            bool cliRepetido;
            cedulaValida = BaseDeDatos.validarCedula(cedula);
            telefonoValido = validarTelefono(telefono);
            cliRepetido = repeticionCliente(cedula, telefono, email);

            if (cedulaValida == true && telefonoValido == true && cliRepetido == false)
            {
                Cliente nuevoCliente = new Cliente(nombre, apellido, cedula, direccion, telefono, email);
                BaseDeDatos.listaClientes.Add(nuevoCliente);
            }
            else if (cedulaValida == false && telefonoValido == false)
            {
                lblErrorValidacion.Text = "la cedula ingresada no es valida y el telefono no puede ser mayor a 15 digitos";
                lblErrorValidacion.Visible = true;
            }
            else if (cedulaValida == false)
            {
                lblErrorValidacion.Text = "la cedula ingresada no es valida";
                lblErrorValidacion.Visible = true;
            }
            else if (telefonoValido == false)
            {
                lblErrorValidacion.Text = "el telefono no puede ser mayor a 15 digitos";
                lblErrorValidacion.Visible = true;
            }
            else if (cliRepetido == true)
            {
                lblErrorValidacion.Text = "este cliente ya existe (cedula, telefono o email repetido)";
                lblErrorValidacion.Visible = true;
            }

        }

        public bool validarTelefono(string telefono)
        {
            long num = 0;

            if (string.IsNullOrEmpty(telefono))
            {
                return true;
            }
            else if (telefono.Length > 15 || (long.TryParse(telefono, out num)) == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool repeticionCliente(string cedula, string telefono, string email)
        {
            bool cliRepiteCedula = false;
            bool cliRepiteTelefono = false;
            bool cliRepiteEmail = false;

            bool clienteRepetido = false;

                cedula = cedula.Trim();
            

            if (string.IsNullOrEmpty(telefono) == false)
            {
                telefono = telefono.Trim();
            }

            if (string.IsNullOrEmpty(email) == false)
            {
                email = email.Trim();
            }

            for (int i = 0; i < BaseDeDatos.listaClientes.Count; i++)
            {
                if (BaseDeDatos.listaClientes[i].getCedula() == cedula)
                {
                    cliRepiteCedula = true;
                    break;
                }

                if (BaseDeDatos.listaClientes[i].getTelefono() == telefono && string.IsNullOrEmpty(telefono) == false)
                {
                    cliRepiteTelefono = true;
                    break;
                }

                if (BaseDeDatos.listaClientes[i].getEmail() == email && string.IsNullOrEmpty(email) == false)
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

        public bool repeticionClienteEdicion(string cedula, string telefono, string email)
        {
            bool cliRepiteCedula = false;
            bool cliRepiteTelefono = false;
            bool cliRepiteEmail = false;

            bool clienteRepetido = false;

            cedula = cedula.Trim();

            if (string.IsNullOrEmpty(telefono) == false)
            {
                telefono = telefono.Trim();
            }

            if (string.IsNullOrEmpty(email) == false)
            {
                email = email.Trim();
            }


            for (int i = 0; i < BaseDeDatos.listaClientes.Count - 1; i++)
            {
                if (BaseDeDatos.listaClientes[i].getCedula() == cedula)
                {
                    cliRepiteCedula = true;
                    break;
                }

                if (BaseDeDatos.listaClientes[i].getTelefono() == telefono && string.IsNullOrEmpty(telefono) == false)
                {
                    cliRepiteTelefono = true;
                    break;
                }

                if (BaseDeDatos.listaClientes[i].getEmail() == email && string.IsNullOrEmpty(email) == false)
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
            lblErrorIngreso.Visible = false;
            lblErrorValidacion.Visible = false;
            lblErrorEdicion.Visible = false;

            if (e.RowIndex >= 0 && e.RowIndex < BaseDeDatos.listaClientes.Count())
            {
                BaseDeDatos.listaClientes.RemoveAt(e.RowIndex);
                recargarGvClientes();
            }
        }

        protected void editarCliente(object sender, GridViewEditEventArgs e)
        {
            lblErrorIngreso.Visible = false;
            lblErrorValidacion.Visible = false;
            lblErrorEdicion.Visible = false;

            gvClientes.EditIndex = e.NewEditIndex;
            recargarGvClientes();
            lblEdicion.Visible = true;
        }

        protected void cancelarEdicionCliente(object sender, GridViewCancelEditEventArgs e)
        {
            lblErrorIngreso.Visible = false;
            lblErrorValidacion.Visible = false;
            lblErrorEdicion.Visible = false;

            gvClientes.EditIndex = -1;
            recargarGvClientes();
            lblEdicion.Visible = false;
        }

        protected void actualizarCliente(object sender, GridViewUpdateEventArgs e)
        {
            lblErrorIngreso.Visible = false;
            lblErrorValidacion.Visible = false;
            lblErrorEdicion.Visible = false;

            GridViewRow fila = gvClientes.Rows[e.RowIndex];

            string nombreActualizado = (fila.Cells[0].Controls[0] as TextBox).Text;
            string apellidoActualizado = (fila.Cells[1].Controls[0] as TextBox).Text;
            string cedulaActualizada = (fila.Cells[2].Controls[0] as TextBox).Text;
            string direccionActualizada = (fila.Cells[3].Controls[0] as TextBox).Text;
            string telefonoActualizado = (fila.Cells[4].Controls[0] as TextBox).Text;
            string emailActualizado = (fila.Cells[5].Controls[0] as TextBox).Text;

            cedulaActualizada = BaseDeDatos.puntosGuionCedula(cedulaActualizada);

            bool cedulaValida = BaseDeDatos.validarCedula(cedulaActualizada);
            bool telefonoValido = validarTelefono(telefonoActualizado);
            bool clienteRepetido = repeticionClienteEdicion(cedulaActualizada, telefonoActualizado, emailActualizado);

            if (cedulaValida == true && telefonoValido == true && clienteRepetido == false)
            {
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
            else if (cedulaValida == false && telefonoValido == false && clienteRepetido == true)
            {
                gvClientes.EditIndex = -1;
                recargarGvClientes();
                lblEdicion.Visible = false;
                lblErrorEdicion.Text = "Cedula invalida, telefono mayor a 15 digitos y cliente repetido";
                lblErrorEdicion.Visible = true;
            }
            else if (cedulaValida == false)
            {
                gvClientes.EditIndex = -1;
                recargarGvClientes();
                lblEdicion.Visible = false;
                lblErrorEdicion.Text = "La cedula no es valida";
                lblErrorEdicion.Visible = true;
            }
            else if (telefonoValido == false)
            {
                gvClientes.EditIndex = -1;
                recargarGvClientes();
                lblEdicion.Visible = false;
                lblErrorEdicion.Text = "El telefono no puede tener letras o ser mayor a 15 digitos";
                lblErrorEdicion.Visible = true;
            }
            else if (clienteRepetido == true)
            {
                gvClientes.EditIndex = -1;
                recargarGvClientes();
                lblEdicion.Visible = false;
                lblErrorEdicion.Text = "Este cliente ya existe";
                lblErrorEdicion.Visible = true;
            }
        }
    }
}