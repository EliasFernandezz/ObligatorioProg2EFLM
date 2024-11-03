using ObligatorioProg2EFLM.Clases;
using System;
using System.Diagnostics;

namespace ObligatorioProg2EFLM
{
    public partial class webClientes : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BaseDeDatos.preCargaClientes();
            }
        }

        protected void agregarCliente_click(object sender, EventArgs e)
        {
            string nombre = null;
            string apellido = null;
            string cedula = null;
            string direccion = null;
            int telefono = 0;
            string email = null;

            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                rfvNombre.Text = "* Debe ingresar un nombre";
                rfvNombre.Visible = true;
            }
            else
            {
                nombre = txtNombre.Text;
            }

            if (string.IsNullOrEmpty(txtApellido.Text))
            {
                rfvApellido.Text = "* Debe ingresar un apellido";
                rfvApellido.Visible = true;
            }
            else
            {
                apellido = txtApellido.Text;
            }

            if (string.IsNullOrEmpty(txtCedula.Text))
            {
                rfvCedula.Text = "* Debe ingresar una cedula";
                rfvCedula.Visible = true;
            }
            else
            {
                cedula = txtCedula.Text;
            }

            if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                rfvDireccion.Text = "* Debe ingresar una direccion";
                rfvDireccion.Visible = true;
            }
            else
            {
                direccion = txtDireccion.Text;
            }

            if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                rfvTelefono.Text = "* Debe ingresar un telefono";
                rfvTelefono.Visible = true;
            }
            else
            {
                telefono = Convert.ToInt32(txtTelefono.Text);
            }

            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                rfvEmail.Text = "* Debe ingresar un email";
                rfvEmail.Visible = true;
            }
            else
            {
                email = txtEmail.Text;
            }


            if (nombre == txtNombre.Text && apellido == txtApellido.Text && cedula == txtCedula.Text && direccion == txtDireccion.Text
                && telefono == Convert.ToInt32(txtTelefono.Text) && email == txtEmail.Text)
            {
                BaseDeDatos.agregarCliente(nombre, apellido, cedula, direccion, telefono, email);

                txtNombre.Text = "";
                txtApellido.Text = "";
                txtCedula.Text = "";
                txtDireccion.Text = "";
                txtTelefono.Text = "";
                txtEmail.Text = "";
            }

        }
    }
}