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
            string cedula = BaseDeDatos.puntosGuionCedula(txtCedula.Text);
            string contraseña = BaseDeDatos.puntosGuionCedula(txtContraseña.Text);

            if ((cedula == "5.341.099-1" && contraseña == "5.341.099-1") || (cedula == "5.594.951-2" && contraseña == "5.594.951-2"))
            {
                BaseDeDatos.UsuarioLogeado = cedula;
                Response.Redirect("webInicio.aspx");
            }
            for (int i = 0; i < BaseDeDatos.listaTecnicos.Count; i++)
            {
                if (cedula == BaseDeDatos.listaTecnicos[i].getCedula() && contraseña == BaseDeDatos.listaTecnicos[i].getCedula())
                {
                    BaseDeDatos.UsuarioLogeado = cedula;
                    Response.Redirect("webBuscarOrdenes.aspx");
                }
                else
                {
                    lblErrorIngreso.Visible = true;
                }
            }
        }
    }
}