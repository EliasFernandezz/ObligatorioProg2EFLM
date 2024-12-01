using System;

namespace ObligatorioProg2EFLM.Clases
{
    public class Comentarios
    {
        public string Coment { get; set; }
        public DateTime Ahora { get; set; }

        public Comentarios(string coment)
        {
            this.Coment = coment;
            this.Ahora = DateTime.Now;
        }
        public string getComent()=> this.Coment;
        public void setComent(string Coment)=>this.Coment = Coment;
    }
}