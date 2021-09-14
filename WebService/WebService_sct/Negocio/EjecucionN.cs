using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService_sct;
using WebService_sct.Modelo;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using System.Data;
using WebService_sct.Data;
using System.Data.Common;

namespace WebService_sct.Negocio
{
    public class EjecucionN
    {

        public int idEjec { get; set; }
        public string descrip { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaTermino { get; set; }
        public DateTime fechaEjecucion { get; set; }
        public string personal_rut { get; set; }
        public string semaforo { get; set; }
        public string notifi { get; set; }
        public int tareaId { get; set; }
        public int tipota { get; set; }
        public string nombreta { get; set; }
        public string descripcionTar { get; set; }
        public string observacionTar { get; set; }
        public string rutAdjudicador { get; set; }


        public void agregarEjecucion(EjecucionN eje)
        {

            EjecucionCRUD ejes = new EjecucionCRUD();

            ejes.agregarEjecucion(eje);
        }

        public List<EjecucionN> listarEjecucionesPorConfirmar(string rut)
        {
            EjecucionCRUD nuev = new EjecucionCRUD();
            return nuev.listaEjecucionesAsociadasPorConfirmar(rut);
        }
        public List<EjecucionN> listarEjecucionesAceptadas(string rut)
        {
            EjecucionCRUD nuev = new EjecucionCRUD();
            return nuev.listaEjecucionesAsociadasAceptadas(rut);
        }

        public List<EjecucionN> ReportelistarEjecucionesAceptadas(string rut, int ano, int mes)
        {
            EjecucionCRUD nuev = new EjecucionCRUD();
            return nuev.ReportelistaEjecucionesAsociadasAceptadas(rut, ano, mes);
        }

        public List<EjecucionN> ReportelistarEjecucionesRechazadas(string rut, int ano, int mes)
        {
            EjecucionCRUD nuev = new EjecucionCRUD();
            return nuev.ReportelistaEjecucionesAsociadasRechazadas(rut, ano, mes);
        }

        public List<EjecucionN> ReportelistarEjecucionesatiempo(string rut, int ano, int mes)
        {
            EjecucionCRUD nuev = new EjecucionCRUD();
            return nuev.ReportelistaEjecucionesAsociadasAtiempo(rut, ano, mes);
        }
        public List<EjecucionN> ReportelistarEjecucionesatrasadas(string rut, int ano, int mes)
        {
            EjecucionCRUD nuev = new EjecucionCRUD();
            return nuev.ReportelistaEjecucionesAsociadasatrasadas(rut, ano, mes);
        }

        public List<EjecucionN> listarEjecucionesTerminadas(string rut)
        {
            EjecucionCRUD nuev = new EjecucionCRUD();
            return nuev.listaEjecucionesAsociadasTerminadas(rut);
        }
        public List<EjecucionN> listarEjecucionesRevisadas(string rut)
        {
            EjecucionCRUD nuev = new EjecucionCRUD();
            return nuev.listaEjecucionesAsociadasRevisadas(rut);
        }
        public void cambiarEstadoEjecucion(EjecucionN eje)
        {
            EjecucionCRUD nuev = new EjecucionCRUD();
            nuev.CambiarEstadoEjecucion(eje);
        }


    }
}