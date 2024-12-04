using ObligatorioProg2EFLM.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace ObligatorioProg2EFLM
{
    public partial class webTecnicos : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                recargarGvTecnicos();
            }
        }

        protected void agregarTecnico_Click(object sender, EventArgs e)
        {
            lblErrorValidacion.Visible = false;
            lblErrorIngreso.Visible = false;
            lblErrorEdicion.Visible = false;

            string nombre = null;
            string apellido = null;
            string cedula = null;
            string especialidad = null;

            if (string.IsNullOrEmpty(txtNombre.Text) == true || string.IsNullOrEmpty(txtApellido.Text) == true || string.IsNullOrEmpty(txtCedula.Text) == true || string.IsNullOrEmpty(txtEspecialidad.Text) == true)
            {
                lblErrorIngreso.Visible = true;
                vaciarCamposTecnicos();
            }
            else
            {
                lblErrorIngreso.Visible = false;
                nombre = txtNombre.Text;
                apellido = txtApellido.Text;
                cedula = txtCedula.Text;
                especialidad = txtEspecialidad.Text;

                cedula = BaseDeDatos.puntosGuionCedula(cedula);

                validarYAgregarTecnico(nombre, apellido, cedula, especialidad);

                recargarGvTecnicos();

                vaciarCamposTecnicos();


            }
        }

        protected void recargarGvTecnicos()
        {
            gvTecnicos.DataSource = BaseDeDatos.listaTecnicos;
            gvTecnicos.DataBind();
        }

        protected void vaciarCamposTecnicos()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCedula.Text = "";
            txtEspecialidad.Text = "";
        }

        public void validarYAgregarTecnico(string nombre, string apellido, string cedula, string especialidad)
        {
            bool cedulaValida;
            bool tecRepetido;
            cedulaValida = BaseDeDatos.validarCedula(cedula);
            tecRepetido = repeticionTecnico(cedula);

            if (cedulaValida == true && tecRepetido == false)
            {
                Tecnico nuevoTecnico = new Tecnico(nombre, apellido, cedula, especialidad);
                BaseDeDatos.listaTecnicos.Add(nuevoTecnico);
                recargarGvTecnicos();
            }
            else if (cedulaValida == false)
            {
                lblErrorValidacion.Text = "la cedula ingresada no es valida";
                lblErrorValidacion.Visible = true;
            }
            else if (tecRepetido == true)
            {
                lblErrorValidacion.Text = "este tecnico ya existe (cedula, telefono o email repetido)";
                lblErrorValidacion.Visible = true;
            }

        }

        public static bool repeticionTecnico(string cedula)
        {
            cedula = cedula.Trim();

            bool tecRepiteCedula = false;

            bool tecnicoRepetido = false;

            for (int i = 0; i < BaseDeDatos.listaTecnicos.Count; i++)
            {
                if (BaseDeDatos.listaTecnicos[i].getCedula() == cedula)
                {
                    tecRepiteCedula = true;
                    break;
                }
            }

            if (tecRepiteCedula == false)
            {
                tecnicoRepetido = false;
            }
            else
            {
                tecnicoRepetido = true;
            }
            return tecnicoRepetido;
        }

        public static bool repeticionTecnicoEdicion(string cedula)
        {
            cedula = cedula.Trim();

            bool tecRepiteCedula = false;

            bool tecnicoRepetido = false;

            for (int i = 0; i < BaseDeDatos.listaTecnicos.Count - 1; i++)
            {
                if (BaseDeDatos.listaTecnicos[i].getCedula() == cedula)
                {
                    tecRepiteCedula = true;
                    break;
                }
            }

            if (tecRepiteCedula == false)
            {
                tecnicoRepetido = false;
            }
            else
            {
                tecnicoRepetido = true;
            }
            return tecnicoRepetido;
        }

        protected void borrarTecnico(object sender, GridViewDeleteEventArgs e)
        {
            lblErrorValidacion.Visible = false;
            lblErrorIngreso.Visible = false;
            lblErrorEdicion.Visible = false;

            if (e.RowIndex >= 0 && e.RowIndex < BaseDeDatos.listaTecnicos.Count())
            {
                BaseDeDatos.listaTecnicos.RemoveAt(e.RowIndex);
                recargarGvTecnicos();
            }
        }

        protected void editarTecnico(object sender, GridViewEditEventArgs e)
        {
            lblErrorValidacion.Visible = false;
            lblErrorIngreso.Visible = false;
            lblErrorEdicion.Visible = false;

            gvTecnicos.EditIndex = e.NewEditIndex;
            recargarGvTecnicos();
            lblEdicion.Visible = true;
        }

        protected void actualizarTecnico(object sender, GridViewUpdateEventArgs e)
        {
            lblErrorValidacion.Visible = false;
            lblErrorIngreso.Visible = false;
            lblErrorEdicion.Visible = false;

            GridViewRow fila = gvTecnicos.Rows[e.RowIndex];

            string nombreActualizado = (fila.Cells[0].Controls[0] as TextBox).Text;
            string apellidoActualizado = (fila.Cells[1].Controls[0] as TextBox).Text;
            string cedulaActualizada = (fila.Cells[2].Controls[0] as TextBox).Text;
            string especialidadActualizada = (fila.Cells[3].Controls[0] as TextBox).Text;

            cedulaActualizada = BaseDeDatos.puntosGuionCedula(cedulaActualizada);

            bool cedulaValida = BaseDeDatos.validarCedula(cedulaActualizada);
            bool tecnicoRepetido = repeticionTecnicoEdicion(cedulaActualizada);

            if (cedulaValida == true && tecnicoRepetido == false)
            {
                BaseDeDatos.listaTecnicos[e.RowIndex].setNombre(nombreActualizado);
                BaseDeDatos.listaTecnicos[e.RowIndex].setApellido(apellidoActualizado);
                BaseDeDatos.listaTecnicos[e.RowIndex].setCedula(cedulaActualizada);
                BaseDeDatos.listaTecnicos[e.RowIndex].setEspecialidad(especialidadActualizada);

                gvTecnicos.EditIndex = -1;
                recargarGvTecnicos();
                lblEdicion.Visible = false;
            }
            else if (cedulaValida == false && tecnicoRepetido == true)
            {
                gvTecnicos.EditIndex = -1;
                recargarGvTecnicos();
                lblEdicion.Visible = false;
                lblErrorEdicion.Text = "Error: Cedula invalida y tecnico repetido";
                lblErrorEdicion.Visible = true;
            }
            else if(cedulaValida == false)
            {
                gvTecnicos.EditIndex = -1;
                recargarGvTecnicos();
                lblEdicion.Visible = false;
                lblErrorEdicion.Text = "Cedula invalida";
                lblErrorEdicion.Visible = true;
            }
            else if (tecnicoRepetido == true)
            {
                gvTecnicos.EditIndex = -1;
                recargarGvTecnicos();
                lblEdicion.Visible = false;
                lblErrorEdicion.Text = "Tecnico Repetido";
                lblErrorEdicion.Visible = true;
            }
        }

        protected void cancelarEdicionTecnico(object sender, GridViewCancelEditEventArgs e)
        {
            lblErrorValidacion.Visible = false;
            lblErrorIngreso.Visible = false;
            lblErrorEdicion.Visible = false;

            gvTecnicos.EditIndex = -1;
            recargarGvTecnicos();
            lblEdicion.Visible = false;
        }
    }
}