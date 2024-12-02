using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObligatorioProg2EFLM.Clases
{
    public class GVContablidadT
    {
        public string TecAsociado{  get; set; }
        public int OrPendiente{  get; set; }
        public int OrEnProgreso{  get; set; }
        public int OrCompletada{  get; set; }
        public int OrTotal {get; set; }
        public GVContablidadT(string TecAsociado, int OrPendiente, int OrEnProgreso, int OrCompletada) 
        {
            this.TecAsociado = TecAsociado;
            this.OrPendiente = OrPendiente;
            this.OrEnProgreso = OrEnProgreso;
            this.OrCompletada = OrCompletada;
            OrTotal = OrPendiente + OrCompletada + OrEnProgreso;
        }
        public string GetTecnico()=> TecAsociado;
        public int GetOrPendiente()=> OrPendiente;
        public int GetOrEnProgreso()=> OrEnProgreso;
        public int GetOrCompletada()=> OrCompletada;
        public int GetOrTotal() => OrTotal;

        public void SetTecnico(string TecAsociado) => this.TecAsociado=TecAsociado;
        public void SetOrPendiente(int OrPendiente) => this.OrPendiente=OrPendiente;
        public void SetOrEnProgreso(int OrEnProgreso) => this.OrEnProgreso=OrEnProgreso;
        public void SetOrCompletada(int OrCompletada) => this.OrCompletada=OrCompletada;
        public void SetOrTotal(int OrTotal)=> this.OrTotal=OrTotal; 

    }
}