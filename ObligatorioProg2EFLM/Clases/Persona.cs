namespace ObligatorioProg2EFLM.Clases
{
    public class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }


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