namespace ObligatorioProg2EFLM.Clases
{
    public class Cliente : Persona
    {
        public string Direccion { get; set; }
        public int? Telefono { get; set; }
        public string Email { get; set; }

        public Cliente(string nombre, string apellido, string cedula, string direccion, int? telefono, string email)
                       : base(nombre, apellido, cedula)
        {
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Email = email;
        }

        public string getDireccion() => this.Direccion;
        public void setDireccion(string direccion) => this.Direccion = direccion;

        public int? getTelefono() => this.Telefono;
        public void setTelefono(int telefono) => this.Telefono = telefono;

        public string getEmail() => this.Email;
        public void setEmail(string email) => this.Email = email;
    }
}