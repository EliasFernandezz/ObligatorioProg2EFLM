using Microsoft.Ajax.Utilities;
using ObligatorioProg2EFLM.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace ObligatorioProg2EFLM
{
    public partial class webPedidos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                foreach (Cliente cliente in BaseDeDatos.listaClientes)
                {
                    ListItem listItemCliente = new ListItem();
                    listItemCliente.Text = cliente.getCedula();
                    listItemCliente.Value = cliente.getCedula();
                    cboClienteAsociado.Items.Add(listItemCliente);
                }

                foreach (Tecnico tecnico in BaseDeDatos.listaTecnicos)
                {
                    ListItem listItemTecnico = new ListItem();
                    listItemTecnico.Text = tecnico.getCedula();
                    listItemTecnico.Value = tecnico.getCedula();
                    cboTecnicoAsociado.Items.Add(listItemTecnico);
                }
                recargarGvOrdenes();
            }
        }

        protected void agregarOrden_Click(object sender, EventArgs e)
        {

            string clienteSeleccionado = cboClienteAsociado.SelectedValue;
            string tecnicoSeleccionado = cboTecnicoAsociado.SelectedValue;
            string descripcion = txtDescripcionProblema.Value;
            string estado = cboEstado.SelectedValue;







            if (cboClienteAsociado.SelectedValue == "" || cboTecnicoAsociado.SelectedValue == "" || cboEstado.SelectedValue == "" || string.IsNullOrEmpty(txtDescripcionProblema.Value) == true)
            {
                lblErrorIngreso.Visible = true;
                borrarCampos();
            }
            else
            {
                lblErrorIngreso.Visible = false;
                borrarCampos();

                OrdenesDeTrabajo nuevaOrden = new OrdenesDeTrabajo(BaseDeDatos.listaOrdenes.Count + 1, clienteSeleccionado, tecnicoSeleccionado, descripcion, DateTime.Now, estado);
                BaseDeDatos.listaOrdenes.Add(nuevaOrden);
                recargarGvOrdenes();
            }
        }

        protected void recargarGvOrdenes()
        {
            gvOrdenes.DataSource = BaseDeDatos.listaOrdenes;
            gvOrdenes.DataBind();
        }

        protected void borrarCampos()
        {
            cboClienteAsociado.SelectedValue = ClienteNoSeleccionado.Value;
            cboTecnicoAsociado.SelectedValue = TecnicoNoSeleccionado.Value;
            txtDescripcionProblema.Value = null;
            cboEstado.SelectedValue = EstadoNoSeleccionado.Value;
        }
        protected void clickEditarOrden(object sender, GridViewEditEventArgs e)
        {
            gvOrdenes.EditIndex = e.NewEditIndex;
            recargarGvOrdenes();
        }
        protected void clickCancelarOrden(object sender, GridViewCancelEditEventArgs e)
        {
            gvOrdenes.EditIndex = -1;
            recargarGvOrdenes();
        }

        protected void clickBorrarOrden(object sender, GridViewDeleteEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < BaseDeDatos.listaOrdenes.Count())
            {
                BaseDeDatos.listaOrdenes.RemoveAt(e.RowIndex);
                recargarGvOrdenes();
            }
        }

        protected void clickActualizarOrden(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow fila = gvOrdenes.Rows[e.RowIndex];

            string estadoActualizado = ((TextBox)fila.Cells[5].Controls[0]).Text;
            if (estadoActualizado == "Pendiente" || (estadoActualizado == "En Progreso") || (estadoActualizado == "Completada"))
            {
                BaseDeDatos.listaOrdenes[e.RowIndex].SetEstado(estadoActualizado);
                if (BaseDeDatos.listaOrdenes[e.RowIndex].GetEstado() == "Completada")
                {
                    BaseDeDatos.listaOrdenes[e.RowIndex].SetFechaFinalizada();
                }

            }
                gvOrdenes.EditIndex = -1;
                recargarGvOrdenes();
        }

        protected void clickVerComentarios(object sender, CommandEventArgs e)
        {
            lblComentarios.Text = $"Comentarios de la orden numero {BaseDeDatos.listaOrdenes[Convert.ToInt32(e.CommandArgument)].GetNumOrden()}";
            lblComentarios.Visible = true;

            gvComentariosOrden.DataSource = BaseDeDatos.listaOrdenes[Convert.ToInt32(e.CommandArgument)].GetComentarios();
            gvComentariosOrden.DataBind();
            gvComentariosOrden.Visible = true;
        }
    }
}