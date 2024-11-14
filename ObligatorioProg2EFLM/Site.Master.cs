using System;
using System.Web.UI;
using ObligatorioProg2EFLM.Clases;

namespace ObligatorioProg2EFLM
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (var Tecnico in BaseDeDatos.listaTecnicos)
            {
                if(BaseDeDatos.GetUsuarioLogeado() == Tecnico.getCedula())
                {
                    
                }
            }
        }
    }
}