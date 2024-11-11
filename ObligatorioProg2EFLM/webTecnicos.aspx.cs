using ObligatorioProg2EFLM.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ObligatorioProg2EFLM
{
    public partial class webTecnicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (BaseDeDatos.listaTecnicos.Count == 0)
                {
                    BaseDeDatos.preCargaTecnicos();
                }

                gvTecnicos.DataSource = BaseDeDatos.listaTecnicos;
                gvTecnicos.DataBind();
            }
        }

        protected void agregarTecnico_Click(object sender, EventArgs e)
        {
            string nombre = null;
            string apellido = null;
            string cedula = null;
            string especialidad = null;

            lblError.Visible = true;

            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrEmpty(txtCedula.Text))
            {
                lblError.Visible = true;

                txtNombre.Text = "";
                txtApellido.Text = "";
                txtCedula.Text = "";
                txtEspecialidad.Text = "";
            }
            else
            {
                nombre = txtNombre.Text;
                apellido = txtApellido.Text;
                cedula = txtCedula.Text;
                especialidad = txtEspecialidad.Text;

                BaseDeDatos.agregarTecnico(nombre, apellido, cedula, especialidad);

                gvTecnicos.DataSource = BaseDeDatos.listaTecnicos;
                gvTecnicos.DataBind();

                txtNombre.Text = "";
                txtApellido.Text = "";
                txtCedula.Text = "";
                txtEspecialidad.Text = "";
            }
        }
    }
}