using ObligatorioProg2EFLM.Clases;
using System;
using System.Diagnostics;
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
                    BaseDeDatos.preCargaClientes();
                }
                    gvClientes.DataSource = BaseDeDatos.listaClientes;
                    gvClientes.DataBind();
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

            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrEmpty(txtCedula.Text))
            {
                lblError.Visible = true;

                txtNombre.Text = "";
                txtApellido.Text = "";
                txtCedula.Text = "";
                txtDireccion.Text = "";
                txtTelefono.Text = "";
                txtEmail.Text = "";
            }
            else
            {
                nombre = txtNombre.Text;
                apellido = txtApellido.Text;
                cedula = txtCedula.Text;
                direccion = txtDireccion.Text;
                telefono = Convert.ToInt32(txtTelefono.Text);
                email = txtEmail.Text;


                BaseDeDatos.agregarCliente(nombre, apellido, cedula, direccion, telefono, email);

                gvClientes.DataSource = BaseDeDatos.listaClientes;
                gvClientes.DataBind();

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