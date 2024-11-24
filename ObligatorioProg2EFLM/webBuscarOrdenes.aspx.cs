using ObligatorioProg2EFLM.Clases;
using System;

namespace ObligatorioProg2EFLM
{
    public partial class webBuscarOrdenes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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