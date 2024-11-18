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
            if (((txtCedula.Text == "53410991") || (txtCedula.Text == "55949512")) && ((txtCedula.Text == "53410991") || (txtCedula.Text == "55949512")))
            {
                Response.Redirect("webInicio.aspx");
            }
            for (int i = 0; i < BaseDeDatos.listaTecnicos.Count; i++)
            {

                if (txtCedula.Text == BaseDeDatos.listaClientes[i].getCedula() && txtContraseña.Text == BaseDeDatos.listaClientes[i].getCedula())
                {
                    Response.Redirect("webInicio.aspx");
                }

            }
        }
    }
}