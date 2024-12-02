using Microsoft.Ajax.Utilities;
using ObligatorioProg2EFLM.Clases;
using System;
using System.Collections.Generic;

namespace ObligatorioProg2EFLM
{
    public partial class webReporteDeActividad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<OrdenesDeTrabajo> ordenesDeTrabajos = new List<OrdenesDeTrabajo>();
                DateTime hoy = DateTime.Now;
                foreach (var Orden in BaseDeDatos.listaOrdenes)
                {
                    if (Orden.GetFechaFinalizada() > hoy.AddMonths(-1))
                    {
                        ordenesDeTrabajos.Add(Orden);
                    }
                }
                gvOrdenesCompletas.DataSource = ordenesDeTrabajos;
                gvOrdenesCompletas.DataBind();


                List<GVContablidadT> CantOrdenesTecnicos = new List<GVContablidadT>();
                foreach (var Tecnico in BaseDeDatos.listaTecnicos)
                {
                    int Pendiente = 0;
                    int EnProgreso = 0;
                    int Completada = 0;

                    foreach (var orden in BaseDeDatos.listaOrdenes)
                    {
                        if (Tecnico.getCedula() == orden.GetTecnicoAsociado())
                        {
                            if (orden.GetEstado() == "Pendiente")
                            {
                                Pendiente++;
                            }
                            else if (orden.GetEstado() == "En Progreso")
                            {
                                EnProgreso++;
                            }
                            else
                                Completada++;

                        }



                    }
                    

                    GVContablidadT ObjetoContabilidad = new GVContablidadT(Tecnico.getCedula(), Pendiente, EnProgreso, Completada);
                    CantOrdenesTecnicos.Add(ObjetoContabilidad);

                }

                gvContabilidadxTecnico.DataSource = CantOrdenesTecnicos;
                gvContabilidadxTecnico.DataBind();





            }
        }
    }
}