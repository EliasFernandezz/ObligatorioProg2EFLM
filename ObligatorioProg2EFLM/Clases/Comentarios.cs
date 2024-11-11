using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObligatorioProg2EFLM.Clases
{
    public class Comentarios
    {
        public string Coment {  get; set; }
        public DateTime Ahora { get; set; }

        public Comentarios(string coment) 
        {
            this.Coment = coment;
            this.Ahora = DateTime.Now;
        }
    }
}