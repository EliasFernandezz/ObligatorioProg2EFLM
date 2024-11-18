using ObligatorioProg2EFLM.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ObligatorioProg2EFLM
{
    public partial class webTecnicos : System.Web.UI.Page
    {
        Tecnico tecnico1 = new Tecnico("Mariano", "Fernandez", "17239962", "Sanitario");
        Tecnico tecnico2 = new Tecnico("Federico", "Lamborghini", "87548480", "Instalador de aire");
        Tecnico tecnico3 = new Tecnico("Violeta", "Sechous", "58915463", "Albañil");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (BaseDeDatos.listaTecnicos.Count == 0)
                {
                    preCargaTecnicos();
                }

                gvTecnicos.DataSource = BaseDeDatos.listaTecnicos;
                gvTecnicos.DataBind();
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

        public void preCargaTecnicos()
        {

            BaseDeDatos.listaTecnicos.Add(tecnico1);
            BaseDeDatos.listaTecnicos.Add(tecnico2);
            BaseDeDatos.listaTecnicos.Add(tecnico3);
        }

        public static void validarYAgregarTecnico(string nombre, string apellido, string cedula, string especialidad)
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

        }

        public static bool validarCedula(string cedula)
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

    }
}