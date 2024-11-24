using ObligatorioProg2EFLM.Clases;
using System;

namespace ObligatorioProg2EFLM
{
    public partial class SiteTecnicos : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < BaseDeDatos.listaTecnicos.Count; i++)
            {

                if (BaseDeDatos.UsuarioLogeado == BaseDeDatos.listaTecnicos[i].getCedula())
                {

                }

            }
        }
    }
}