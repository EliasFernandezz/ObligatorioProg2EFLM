using ObligatorioProg2EFLM.Clases;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace ObligatorioProg2EFLM
{
    public partial class webTecnicos : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (BaseDeDatos.listaTecnicos.Count == 0)
                {
                    Tecnico tecnico1 = new Tecnico("Mariano", "Fernandez", "17239962", "Sanitario");
                    Tecnico tecnico2 = new Tecnico("Federico", "Lamborghini", "87548480", "Instalador de aire");
                    Tecnico tecnico3 = new Tecnico("Violeta", "Sechous", "58915463", "Albañil");
                    preCargaTecnicos(tecnico1, tecnico2, tecnico3);

                }

                gvTecnicos.DataSource = BaseDeDatos.listaTecnicos;
                gvTecnicos.DataBind();

                if (BaseDeDatos.GetiTecnicos() == 0)
                {
                    int i = 1;
                    BaseDeDatos.SetiTecnicos(i);
                    Response.Redirect("webLogin.aspx");
                }
            }
        }

        protected void agregarTecnico_Click(object sender, EventArgs e)
        {
            string nombre = null;
            string apellido = null;
            string cedula = null;
            string especialidad = null;

            lblError.Visible = true;

            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrEmpty(txtCedula.Text))
            {
                lblError.Visible = true;

                txtNombre.Text = "";
                txtApellido.Text = "";
                txtCedula.Text = "";
                txtEspecialidad.Text = "";
            }
            else
            {
                if (string.IsNullOrEmpty(txtNombre.Text) == false && string.IsNullOrEmpty(txtApellido.Text) == false &&
                    string.IsNullOrEmpty(txtCedula.Text) == false && string.IsNullOrEmpty(txtEspecialidad.Text) == false)
                {
                    nombre = txtNombre.Text;
                    apellido = txtApellido.Text;
                    cedula = txtCedula.Text;
                    especialidad = txtEspecialidad.Text;

                    validarYAgregarTecnico(nombre, apellido, cedula, especialidad);

                    gvTecnicos.DataSource = BaseDeDatos.listaTecnicos;
                    gvTecnicos.DataBind();

                    txtNombre.Text = "";
                    txtApellido.Text = "";
                    txtCedula.Text = "";
                    txtEspecialidad.Text = "";
                }
                else
                {
                    nombre = txtNombre.Text;
                    apellido = txtApellido.Text;
                    cedula = txtCedula.Text;

                    validarYAgregarTecnico(nombre, apellido, cedula, especialidad);

                    gvTecnicos.DataSource = BaseDeDatos.listaTecnicos;
                    gvTecnicos.DataBind();

                    txtNombre.Text = "";
                    txtApellido.Text = "";
                    txtCedula.Text = "";
                    txtEspecialidad.Text = "";
                }
            }
        }

        protected void recargarGvTecnicos()
        {
            gvTecnicos.DataSource = BaseDeDatos.listaTecnicos;
            gvTecnicos.DataBind();
        }

        protected void vaciarCamposCliente()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCedula.Text = "";
            txtEspecialidad.Text = "";
        }

        public void preCargaTecnicos(Tecnico tecnico1, Tecnico tecnico2, Tecnico tecnico3)
        {

            BaseDeDatos.listaTecnicos.Add(tecnico1);
            BaseDeDatos.listaTecnicos.Add(tecnico2);
            BaseDeDatos.listaTecnicos.Add(tecnico3);
        }

        public void validarYAgregarTecnico(string nombre, string apellido, string cedula, string especialidad)
        {
            bool tecRepetido;
            bool cedulaValida;
            tecRepetido = repeticionTecnico(cedula);
            cedulaValida = validarCedula(cedula);

            if (cedulaValida == true && tecRepetido == false)
            {
                Tecnico nuevoTecnico = new Tecnico(nombre, apellido, cedula, especialidad);
                BaseDeDatos.listaTecnicos.Add(nuevoTecnico);
            }
            else if (cedulaValida == false)
            {
                lblErrorValidacion.Text = "la cedula ingresada no es valida";
                lblErrorValidacion.Visible = true;
            }
            else if (tecRepetido == true)
            {
                lblErrorValidacion.Text = "este cliente ya existe (cedula, telefono o email repetido)";
                lblErrorValidacion.Visible = true;
            }

        }

        public bool validarCedula(string cedula)
        {
            cedula = cedula.Trim();
            cedula = cedula.Replace(".", ""); //se quitan los espacios vacios, puntos y guiones de la cedula para que conserve un largo de 8
            cedula = cedula.Replace("-", "");

            if (cedula.Length != 8)
            {
                return false;
            }
            else
            {
                List<int> constante = new List<int>(); //se crea una lista con los numeros de la constante por los que se multiplica el numero de cedula sin verificador
                constante.Add(2);
                constante.Add(9);
                constante.Add(8);
                constante.Add(7);
                constante.Add(6);
                constante.Add(3);
                constante.Add(4);

                string numSinVerificador = cedula.Substring(0, 7);
                int digitoVerificador = Convert.ToInt32(cedula.Substring(7, 1));

                int suma = 0;
                for (int i = 0; i < 7; i++)
                {
                    suma += (Convert.ToInt32(numSinVerificador[i].ToString()) * constante[i]);  //se suman las multiplicaciones de los numeros de la cedula sin verificador y la constante que
                                                                                                //estan en la misma posicion
                }

                int digitoCalculado = 10 - (suma % 10);  //se divide la suma total por 10, se toma el resto y a 10 se le resta el resto, el resultado de la resta es el digito verificador
                if (digitoCalculado == 10)
                {
                    digitoCalculado = 0;
                }

                if (digitoCalculado == digitoVerificador)
                {
                    cedula = cedula.Substring(0, 1) + "." + cedula.Substring(1, 3) + "." + cedula.Substring(4, 3) + "-" + digitoVerificador;
                    return true; // si el digito calculado es igual al del ingreso de la cedula se retorna true
                }
                else
                {
                    return false; //de lo contrario se retorna false
                }

            }
        }

        public static bool repeticionTecnico(string cedula)
        {
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

        protected void borrarTecnico(object sender, GridViewDeleteEventArgs e)
        {
            BaseDeDatos.listaTecnicos.RemoveAt(e.RowIndex);
            recargarGvTecnicos();
        }

        protected void editarTecnico(object sender, GridViewEditEventArgs e)
        {
            gvTecnicos.EditIndex = e.NewEditIndex;
            recargarGvTecnicos();
            lblEdicion.Visible = true;
        }

        protected void actualizarTecnico(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow fila = gvTecnicos.Rows[e.RowIndex];

            string nombreActualizado = (fila.Cells[0].Controls[0] as TextBox).Text;
            string apellidoActualizado = (fila.Cells[1].Controls[0] as TextBox).Text;
            string cedulaActualizada = (fila.Cells[2].Controls[0] as TextBox).Text;
            string especialidadActualizada = (fila.Cells[3].Controls[0] as TextBox).Text;

            BaseDeDatos.listaTecnicos[e.RowIndex].setNombre(nombreActualizado);
            BaseDeDatos.listaTecnicos[e.RowIndex].setApellido(apellidoActualizado);
            BaseDeDatos.listaTecnicos[e.RowIndex].setCedula(cedulaActualizada);
            BaseDeDatos.listaTecnicos[e.RowIndex].setEspecialidad(especialidadActualizada);

            gvTecnicos.EditIndex = -1;
            recargarGvTecnicos();
            lblEdicion.Visible = false;
        }

        protected void cancelarEdicionTecnico(object sender, GridViewCancelEditEventArgs e)
        {
            gvTecnicos.EditIndex = -1;
            recargarGvTecnicos();
            lblEdicion.Visible = false;
        }
    }
}