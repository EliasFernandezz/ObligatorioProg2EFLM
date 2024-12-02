using ObligatorioProg2EFLM.Clases;
using System;
using System.Collections.Generic;


namespace ObligatorioProg2EFLM
{
    public partial class webBuscarOrdenes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
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
                    DivBusqueda.Visible = false;
                }
                
            }
        }

        protected void Btn_buscar(object sender, EventArgs e)
        {
            int NumBusqueda = Convert.ToInt32(BusquedaNum.Text);
            gvVerOrdenes.DataSource = new List<OrdenesDeTrabajo> { BaseDeDatos.listaOrdenes[NumBusqueda-1]};
            gvVerOrdenes.DataBind();
            gvVerOrdenes.Visible = true;
        }
    }
}