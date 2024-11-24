namespace ObligatorioProg2EFLM.Clases
{
    public class Tecnico : Persona
    {
        public string Especialidad { get; set; }

        public Tecnico(string nombre, string apellido, string cedula, string especialidad) : base(nombre, apellido, cedula)
        {
            this.Especialidad = especialidad;
        }

        public string getEspecialidad() => this.Especialidad;
        public void setEspecialidad(string especialidad) => this.Especialidad = especialidad;
    }
}