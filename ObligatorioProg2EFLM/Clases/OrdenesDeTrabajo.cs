using System;
using System.Collections.Generic;

namespace ObligatorioProg2EFLM.Clases
{
    public class OrdenesDeTrabajo
    {
        public int NumOrden { get; set; } //automatico
        public string CliAsociado { get; set; } //listbox
        public string TecAsociado { get; set; } //listbox
        public string DescripProblema { get; set; }
        public DateTime FechaCreacion { get; set; } //automatico
        public string Estado { get; set; }
        public List<Comentarios> Comentarios { get; set; }

        public OrdenesDeTrabajo(int numOrden, string cliAsociado, string tecAsociado, string descripProblema,
                                DateTime fechaCreacion, string estado, List<Comentarios> listaComentarios)
        {
            this.NumOrden = numOrden;
            this.CliAsociado = cliAsociado;
            this.TecAsociado = tecAsociado;
            this.DescripProblema = descripProblema;
            this.FechaCreacion = fechaCreacion;
            this.Estado = estado;
            this.Comentarios = listaComentarios;
        }
    }
}