namespace ObligatorioProg2EFLM.Clases
{
    public class Persona
    {
        private string Nombre;
        private string Apellido;
        private string Cedula;


        public Persona(string nombre, string apellido, string cedula)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Cedula = cedula;
        }

        public string getNombre() => this.Nombre;
        public void setNombre(string nombre) => this.Nombre = nombre;

        public string getApellido() => this.Apellido;
        public void setApellido(string nombre) => this.Nombre = nombre;

        public string getCedula() => Nombre;
        public void setCedula(string nombre) => this.Nombre = nombre;
    }
}