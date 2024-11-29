using ObligatorioProg2EFLM.Clases;
using System;

namespace ObligatorioProg2EFLM
{
    public partial class webInicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            gvOrdenes.DataSource = BaseDeDatos.listaOrdenes;
            gvOrdenes.DataBind();
        }
    }
}