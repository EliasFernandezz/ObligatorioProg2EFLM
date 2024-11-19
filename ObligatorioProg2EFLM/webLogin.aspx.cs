using ObligatorioProg2EFLM.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ObligatorioProg2EFLM
{
    public partial class webLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Logearme_Click(object sender, EventArgs e)
        {
            if ((txtCedula.Text == "5.341.099-1" && txtContraseña.Text == "5.341.099-1") || (txtCedula.Text == "5.594.951-2" && txtContraseña.Text == "5.594.951-2"))
            {
                BaseDeDatos.UsuarioLogeado = txtCedula.Text;
                Response.Redirect("webInicio.aspx");
            }
            for (int i = 0; i < BaseDeDatos.listaTecnicos.Count; i++)
            {

                if (txtCedula.Text == BaseDeDatos.listaTecnicos[i].getCedula() && txtContraseña.Text == BaseDeDatos.listaTecnicos[i].getCedula())
                {
                    BaseDeDatos.UsuarioLogeado = txtCedula.Text;
                    Response.Redirect("webInicio.aspx");
                }

            }
        }
    }
}