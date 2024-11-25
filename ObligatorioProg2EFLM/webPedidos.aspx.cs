using ObligatorioProg2EFLM.Clases;
using System;
using System.Collections.Generic;
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
            }
        }

        protected void agregarOrden_Click(object sender, EventArgs e)
        {
            int numOrden = 1;
            DateTime fechaCreacion = DateTime.Now;
            string clienteSeleccionado = cboClienteAsociado.SelectedValue;
            string tecnicoSeleccionado = cboTecnicoAsociado.SelectedValue;
            string descripcion = txtDescripcionProblema.Value;
            string estado = cboEstado.SelectedValue;
            List<Comentarios> comentarios = null;

            if(clienteSeleccionado == null || tecnicoSeleccionado == null || estado == null || descripcion == null)
            {
                lblErrorIngreso.Visible = true;
                borrarCampos();
            }
            else
            {
                lblErrorIngreso.Visible = false;
                borrarCampos();


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
    }
}