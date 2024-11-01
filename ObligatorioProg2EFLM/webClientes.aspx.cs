using System;

namespace ObligatorioProg2EFLM
{
    public partial class webClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void agregarCliente(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string cedula = txtCedula.Text;
            string direccion = txtDireccion.Text;
            int telefono = Convert.ToInt32(txtTelefono.Text);
            string email = txtEmail.Text;
        }
    }
}