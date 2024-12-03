using ObligatorioProg2EFLM.Clases;
using System;

namespace ObligatorioProg2EFLM
{
    public partial class webLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BaseDeDatos.listaOrdenes[1].SetFechaFinalizada();//no va
            }
        }
        protected void Logearme_Click(object sender, EventArgs e)
        {
            if ((txtCedula.Text == "5.341.099-1" && txtContraseña.Text == "5.341.099-1") || (txtCedula.Text == "53410991" && txtContraseña.Text == "53410991") ||
                (txtCedula.Text == "5.594.951-2" && txtContraseña.Text == "5.594.951-2") || (txtCedula.Text == "55949512" && txtContraseña.Text == "55949512")) //hacer validacion de cedulas
            {
                BaseDeDatos.UsuarioLogeado = txtCedula.Text;
                Response.Redirect("webInicio.aspx");
            }
            for (int i = 0; i < BaseDeDatos.listaTecnicos.Count; i++)
            {
                if (txtCedula.Text == BaseDeDatos.listaTecnicos[i].getCedula() && txtContraseña.Text == BaseDeDatos.listaTecnicos[i].getCedula())
                {
                    BaseDeDatos.UsuarioLogeado = txtCedula.Text;
                    Response.Redirect("webBuscarOrdenes.aspx");
                }
            }
        }
    }
}