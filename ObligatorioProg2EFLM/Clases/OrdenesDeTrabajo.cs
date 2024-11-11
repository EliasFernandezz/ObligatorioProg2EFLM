using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObligatorioProg2EFLM.Clases
{
    public class OrdenesDeTrabajo
    {
        public int NumOrden; //automatico
        public Cliente CliAsociado; //listbox
        public Tecnico TecAsociado; //listbox
        public string DescripProblema;
        public DateTime FechaCreacion; //automatico
        public string Estado;
        public List<Comentarios> ListaComentarios;

        public OrdenesDeTrabajo(int numOrden, Cliente cliAsociado, Tecnico tecAsociado, string descripProblema, 
                                DateTime fechaCreacion, string estado, List<Comentarios> listaComentarios)
        {
            this.NumOrden = numOrden;
            this.CliAsociado = cliAsociado;
            this.TecAsociado = tecAsociado;
            this.DescripProblema = descripProblema;
            this.FechaCreacion = fechaCreacion;
            this.Estado = estado;
            this.ListaComentarios = listaComentarios;
        }
    }
}