using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebService_sct.Negocio;


namespace WebService_sct
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {


        [WebMethod]
        public void AgregarTar(TareaN nu)
        {
            TareaN nuevo = new TareaN();
            nuevo.agregarTarea(nu);
        }
        [WebMethod]
        public void AgregarEstadoTar(EstadoTarN nu)
        {
            EstadoTarN nuevo = new EstadoTarN();
            nuevo.agregarEstadTarea(nu);
        }
        [WebMethod]
        public void EditarTar(TareaN nu)
        {
            TareaN nuevo = new TareaN();
            nuevo.editarTarea(nu);
        }

        [WebMethod]
        public void deshabilitarTar(TareaN nu)
        {
            TareaN nuevo = new TareaN();
            nuevo.deshabilitarTarea(nu);
        }

        [WebMethod]
        public void cambiarEstadoEjecucion(EjecucionN eje)
        {
            EjecucionN nuevo = new EjecucionN();
            nuevo.cambiarEstadoEjecucion(eje);
        }

        [WebMethod]
        public void AgregarEjecucion(EjecucionN nu)
        {
            EjecucionN nuevo = new EjecucionN();
            nuevo.agregarEjecucion(nu);
        }
        [WebMethod]
        public List<TareaN> ListarTareaaaaaas()
        {
            TareaN nuev = new TareaN();
            return nuev.listarTareaaaa();
        }
        [WebMethod]
        public List<TareaN> ListarTareaAs()
        {
            string rutes = "191105702";
            TareaN nuev = new TareaN();
            return nuev.listartareaAs(rutes);
        }

        [WebMethod]
        public List<TareaN> ListarTareaAso()
        {
            string rutes = "191105702";
            TareaN nuev = new TareaN();
            return nuev.listartareaAso(rutes);
        }
        [WebMethod]
        public List<TareaN> ListarTareaAsociadasAUnFuncionarioJefe(string rut)
        {
            string rutes = "191105702";
            TareaN nuev = new TareaN();
            return nuev.listaTareasAsociadas(rut);
        }
        [WebMethod]
        public List<NombreProceN> ListarRutsAsociadosAUnjefe(string rut)
        {
            NombreProceN nuev = new NombreProceN();
            return nuev.listarRutAso(rut);
        }
        [WebMethod]
        public List<EjecucionN> ListarEjecucionesPorConfirmar(string rut)
        {
            EjecucionN nuev = new EjecucionN();
            return nuev.listarEjecucionesPorConfirmar(rut);
        }
        [WebMethod]
        public List<EjecucionN> ListarEjecucionesAceptadas(string rut)
        {
            EjecucionN nuev = new EjecucionN();
            return nuev.listarEjecucionesAceptadas(rut);
        }

        [WebMethod]
        public List<EjecucionN> ReporteListarEjecucionesAceptadas(string rut, int ano, int mes)
        {
            EjecucionN nuev = new EjecucionN();
            return nuev.ReportelistarEjecucionesAceptadas(rut, ano, mes);
        }

        [WebMethod]
        public List<EjecucionN> ReporteListarEjecucionesRechazadas(string rut, int ano, int mes)
        {
            EjecucionN nuev = new EjecucionN();
            return nuev.ReportelistarEjecucionesRechazadas(rut, ano, mes);
        }

        [WebMethod]
        public List<EjecucionN> ReporteListarEjecucionesatrasadas(string rut, int ano, int mes)
        {
            EjecucionN nuev = new EjecucionN();
            return nuev.ReportelistarEjecucionesatrasadas(rut, ano, mes);
        }

        [WebMethod]
        public List<EjecucionN> ReporteListarEjecucionesatiempo(string rut, int ano, int mes)
        {
            EjecucionN nuev = new EjecucionN();
            return nuev.ReportelistarEjecucionesatiempo(rut, ano, mes);
        }

        [WebMethod]
        public List<EjecucionN> ListarEjecucionesTerminadas(string rut)
        {
            EjecucionN nuev = new EjecucionN();
            return nuev.listarEjecucionesTerminadas(rut);
        }
        [WebMethod]
        public List<EjecucionN> ListarEjecucionesRevisadas(string rut)
        {
            EjecucionN nuev = new EjecucionN();
            return nuev.listarEjecucionesRevisadas(rut);
        }
        [WebMethod]
        public List<NombreProceN> MostrarNombrePer(string rut)
        {
            NombreProceN nuev = new NombreProceN();
            return nuev.mostrarNombrePer(rut);
        }
        [WebMethod]
        public List<NombreProceN> MostrarApelloi(string rut)
        {
            NombreProceN nuev = new NombreProceN();
            return nuev.mostrarApellidoPer(rut);
        }


        [WebMethod]
        public List<PersonalN> ListarPersonalAsociadoAUnJefe(string rut)
        {
            //string rutes = "191105702";
            PersonalN nuev = new PersonalN();
            return nuev.listaPersonalAsociadoAUnJefe(rut);
        }

        [WebMethod]
        public TareaN BuscarTarea(int idtareaa, string rut)
        {
            string rutes = "191105702";
            TareaN nuev = new TareaN();
            return nuev.buscarTarea(idtareaa, rut);
        }

        [WebMethod]
        public List<NombreProceN> BuscarNombresProcesos()
        {
            NombreProceN nuev = new NombreProceN();
            return nuev.listarnombreProcesos();
        }

        [WebMethod]
        public List<IdTarea> BuscarIdTareas(string rut)
        {
            IdTarea nuev = new IdTarea();
            return nuev.listarIdTareas(rut);
        }
        [WebMethod]
        public List<IdTarea> BuscarIdProce(string rut)
        {
            IdTarea nuev = new IdTarea();
            return nuev.buscarIdProce(rut);

        }

        [WebMethod]
        public List<IdTarea> ContarTareas()
        {
            IdTarea nuev = new IdTarea();
            return nuev.ContarTareas();

        }
        [WebMethod]
        public List<IdTarea> ContarProcesos()
        {
            IdTarea nuev = new IdTarea();
            return nuev.ContarProcesos();

        }

        [WebMethod]
        public List<IdTarea> ContarEJecuciones()
        {
            IdTarea nuev = new IdTarea();
            return nuev.Contarejecuciones();

        }

        [WebMethod]
        public List<IdTarea> ContarTareasAceptadas(string rut, int ano, int mes)
        {
            IdTarea nuev = new IdTarea();
            return nuev.ContarTareasAceptadas(rut,ano,mes);

        }

        [WebMethod]
        public List<IdTarea> ContarTareasAtiempo(string rut)
        {
            IdTarea nuev = new IdTarea();
            return nuev.ContarTareasAtiempo(rut);

        }

        [WebMethod]
        public List<IdTarea> ContarTareasAtrasadas(string rut)
        {
            IdTarea nuev = new IdTarea();
            return nuev.ContarTareasAtrasada(rut);
            int num;
        }

        [WebMethod]
        public List<IdTarea> ContarTareasRechazadas(string rut, int ano, int mes)
        {
            IdTarea nuev = new IdTarea();
            return nuev.ContarTareasRechazadas(rut, ano, mes);

        }

        [WebMethod]
        public List<IdTarea> ContarEstadosTar()
        {
            IdTarea nuev = new IdTarea();
            return nuev.ContarEstadosTar();

        }

        [WebMethod]
        public void AgregarProce(ProcesoN nu)
        {
            ProcesoN nuevo = new ProcesoN();
            nuevo.agregarProce(nu);
        }
        [WebMethod]
        public List<ProcesoN> ListarProceso()
        {
            ProcesoN nuev = new ProcesoN();
            return nuev.ListarProceso();
        }

        [WebMethod]
        public void modificarProce(ProcesoN nu)
        {
            ProcesoN nuevo = new ProcesoN();
            nuevo.modificarProce(nu);
        }

        [WebMethod]
        public void eliminarrProce(ProcesoN nu)
        {
            ProcesoN nuevo = new ProcesoN();
            nuevo.eliminarProce(nu);
        }

    


}
}
