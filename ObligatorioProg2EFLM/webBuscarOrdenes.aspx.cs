using ObligatorioProg2EFLM.Clases;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;


namespace ObligatorioProg2EFLM
{
    public partial class webBuscarOrdenes : System.Web.UI.Page
    {
        OrdenesDeTrabajo ordenAgregandoComentario;
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
            if (BaseDeDatos.UsuarioLogeado == "5.341.099-1" || BaseDeDatos.UsuarioLogeado == "53410991" ||
                BaseDeDatos.UsuarioLogeado == "5.594.951-2" || BaseDeDatos.UsuarioLogeado == "55949512")
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

        protected void clickTextAreaComentario(object sender, CommandEventArgs e)
        {
            controlesAgregarComentario.Visible = true;
            ordenAgregandoComentario = BaseDeDatos.listaOrdenes[Convert.ToInt32(e.CommandArgument)];
        }

        protected void clickAgregarComentario(object sender, CommandEventArgs e)
        {

            Comentarios Comentario = new Comentarios(txtComentarioAgregado.Text);
            ordenAgregandoComentario.agregarComentarios(Comentario);

            for (int i = 0; i < BaseDeDatos.listaOrdenes.Count; i++)
            {

                if (BaseDeDatos.listaOrdenes[i].GetNumOrden() == ordenAgregandoComentario.GetNumOrden())
                {

                    BaseDeDatos.listaOrdenes[i] = ordenAgregandoComentario;
                }

            }


        }
    }
}