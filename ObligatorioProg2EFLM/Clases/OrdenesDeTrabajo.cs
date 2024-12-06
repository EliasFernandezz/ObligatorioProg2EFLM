using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

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
        public List<Comentarios> Comentarios { get; set; } = new List<Comentarios>();
        public DateTime FechaFinalizada { get; set; }

        public OrdenesDeTrabajo()
        {

        }
        public OrdenesDeTrabajo(int numOrden, string cliAsociado, string tecAsociado, string descripProblema,
                                DateTime fechaCreacion, string estado)
        {
            this.NumOrden = numOrden;
            this.CliAsociado = cliAsociado;
            this.TecAsociado = tecAsociado;
            this.DescripProblema = descripProblema;
            this.FechaCreacion = fechaCreacion;
            this.Estado = estado;
            

        }
        public int GetNumOrden() { return this.NumOrden; }
        public void SetNumOrden(int numOrden) { this.NumOrden = numOrden; }
        public string GetCliAsociado() { return this.CliAsociado; }
        public void SetClienteAsociado(string cliente) { this.CliAsociado = cliente; }
        public string GetTecnicoAsociado() { return this.TecAsociado; }
        public void SetTecnicoAsociado(string tencico) { this.TecAsociado = tencico; }
        public string GetDescripPorblema() { return this.DescripProblema; }
        public void SetDescripProblema(string descripcion) { this.DescripProblema = descripcion; }
        public DateTime GetFechaCreacion() { return this.FechaCreacion; }
        public void SetFechaCreacion(DateTime fechaCre) { this.FechaCreacion = fechaCre; }
        public string GetEstado() { return this.Estado; }
        public void SetEstado(string estado) { this.Estado = estado; }
        public List<Comentarios> GetComentarios() { return this.Comentarios; }
        public void SetComentarios(List<Comentarios> listaComentarios) { this.Comentarios = listaComentarios; }
        public DateTime GetFechaFinalizada() { return this.FechaFinalizada; }
        public void SetFechaFinalizada() {this.FechaFinalizada = DateTime.Now; }


        public void agregarComentarios(Comentarios comentario)
        {
            this.Comentarios.Add(comentario);
        }
    }
}