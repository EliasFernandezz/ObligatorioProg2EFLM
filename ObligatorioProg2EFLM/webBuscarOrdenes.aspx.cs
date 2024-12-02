using ObligatorioProg2EFLM.Clases;
using System;
using System.Collections.Generic;


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

        protected void Btn_buscar(object sender, EventArgs e)
        {


            List<OrdenesDeTrabajo> OrdenRequerida = new List<OrdenesDeTrabajo>();
            if (BaseDeDatos.UsuarioLogeado == "5.341.099-1" || BaseDeDatos.UsuarioLogeado == "5.594.951-2")
            {

                int NumBusqueda = Convert.ToInt32(BusquedaNum.Text);
                foreach (var Orden in OrdenRequerida)
                {
                    if (NumBusqueda == Orden.GetNumOrden())
                    {
                        OrdenRequerida.Clear();
                        OrdenRequerida.Add(Orden);
                    }
                    else
                    {

                    }
                }
                gvVerOrdenes.DataSource = OrdenRequerida;
                gvVerOrdenes.DataBind();
                gvVerOrdenes.Visible = true;

            }
            else
            {
                foreach (var tecnico in BaseDeDatos.listaTecnicos)
                {
                    if (tecnico.getCedula() == BaseDeDatos.UsuarioLogeado)
                    {
                        foreach (var orden in BaseDeDatos.listaOrdenes)
                        {
                            if (BaseDeDatos.UsuarioLogeado == orden.GetTecnicoAsociado())
                            {
                                OrdenRequerida.Add(orden);
                            }
                        }
                    }
                }
                int NumBusquedaTec = Convert.ToInt32(BusquedaNum.Text);
                foreach (var Orden in OrdenRequerida)
                {
                    if (NumBusquedaTec == Orden.GetNumOrden())
                    {
                        OrdenRequerida.Clear();
                        OrdenRequerida.Add(Orden);
                    }
                    else
                    {

                    }
                }
                gvVerOrdenes.DataSource = OrdenRequerida;
                gvVerOrdenes.DataBind();
                gvVerOrdenes.Visible = true;
            }


        }
    }
}