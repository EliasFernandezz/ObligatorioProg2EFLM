using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ObligatorioProg2EFLM.Clases;

namespace ObligatorioProg2EFLM
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Logearme_Click(object sender, EventArgs e)
        {
            if (((Cedula.Text == "53410991") || (Cedula.Text == "55949512")) && ((CedContraseña.Text == "53410991") || (CedContraseña.Text == "55949512")))
            {
                Response.Redirect("webInicio.aspx");
            }
            for (int i = 0; i < BaseDeDatos.listaTecnicos.Count; i++)
            {

                if (Cedula.Text == BaseDeDatos.listaClientes[i].getCedula() && CedContraseña.Text == BaseDeDatos.listaClientes[i].getCedula())
                {
                    Response.Redirect("webInicio.aspx");
                }

            }
        }
    }
}