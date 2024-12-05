using ObligatorioProg2EFLM.Clases;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;


namespace ObligatorioProg2EFLM
{
    public partial class webBuscarOrdenes : System.Web.UI.Page
    {
        OrdenesDeTrabajo ordenAgregandoComentario = new OrdenesDeTrabajo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (BaseDeDatos.UsuarioLogeado == "5.341.099-1" || BaseDeDatos.UsuarioLogeado == "53410991" ||
                    BaseDeDatos.UsuarioLogeado == "5.594.951-2" || BaseDeDatos.UsuarioLogeado == "55949512")
                {

                    foreach (var Orden in BaseDeDatos.listaOrdenes)
                    {
                        OrdenRequerida.Add(Orden);
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
                    gvVerOrdenes.DataSource = OrdenRequerida;
                    gvVerOrdenes.DataBind();
                    gvVerOrdenes.Visible = true;
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

        static List<OrdenesDeTrabajo> OrdenRequerida = new List<OrdenesDeTrabajo>();

        protected void Btn_buscar(object sender, EventArgs e)
        {
            OrdenRequerida.Clear();

            int NumBusqueda = 0;
            try
            {
                NumBusqueda = Convert.ToInt32(BusquedaNum.Text);
                if (BusquedaNum.Text == string.Empty || BusquedaNum.Text == null)
                {
                    throw new FormatException();
                }
            }
            catch (FormatException)
            {
                lblOrdenNoEncontrada.Visible = true;
            }

            lblOrdenNoEncontrada.Visible = false;
            if (BaseDeDatos.UsuarioLogeado == "5.341.099-1" || BaseDeDatos.UsuarioLogeado == "53410991" ||
                BaseDeDatos.UsuarioLogeado == "5.594.951-2" || BaseDeDatos.UsuarioLogeado == "55949512")
            {

                foreach (var Orden in BaseDeDatos.listaOrdenes)
                {
                    if (NumBusqueda == Orden.GetNumOrden())
                    {
                        OrdenRequerida.Add(Orden);
                    }
                }
                if (OrdenRequerida.Count == 0)
                {
                    lblOrdenNoEncontrada.Visible = true;
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
                            if (BaseDeDatos.UsuarioLogeado == orden.GetTecnicoAsociado() && NumBusqueda == orden.GetNumOrden())
                            {
                                OrdenRequerida.Add(orden);
                            }
                        }
                    }
                }
                if (OrdenRequerida.Count == 0)
                {
                    lblOrdenNoEncontrada.Visible = true;
                }
                gvVerOrdenes.DataSource = OrdenRequerida;
                gvVerOrdenes.DataBind();
                gvVerOrdenes.Visible = true;
            }
        }

        protected void clickTextAreaComentario(object sender, CommandEventArgs e)
        {
            foreach (var tecnico in BaseDeDatos.listaTecnicos)
            {
                if (tecnico.getCedula() == BaseDeDatos.UsuarioLogeado)
                {
                    controlesAgregarComentario.Visible = true;
                }
            }
            ordenAgregandoComentario = OrdenRequerida[Convert.ToInt32(e.CommandArgument)];
        }

        protected void clickAgregarComentario(object sender, CommandEventArgs e)
        {

            Comentarios Comentario = new Comentarios(txtComentarioAgregado.Text);
            ordenAgregandoComentario.agregarComentarios(Comentario);
            txtComentarioAgregado.Text = string.Empty;
            controlesAgregarComentario.Visible = false;
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