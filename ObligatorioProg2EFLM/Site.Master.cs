using ObligatorioProg2EFLM.Clases;
using System;
using System.Web.UI;

namespace ObligatorioProg2EFLM
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            foreach (var Tecnico in BaseDeDatos.listaTecnicos)
            {
                if (BaseDeDatos.UsuarioLogeado == Tecnico.getCedula())
                {
                    Response.Redirect("webBuscarOrdenes.aspx");
                }
            }
        }
        protected void Page_PreInit(object sender, EventArgs e)
        {
            this.MasterPageFile = "Site.Master";

            foreach (var Tecnico in BaseDeDatos.listaTecnicos)
            {
                
                if (BaseDeDatos.UsuarioLogeado == Tecnico.getCedula())
                {
                    this.MasterPageFile = "SiteTecnicos.Master";
                }
                
            }

        }
    }
}