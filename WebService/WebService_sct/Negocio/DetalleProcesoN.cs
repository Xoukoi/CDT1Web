using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService_sct.Negocio
{
    public class DetalleProcesoN
    {
        private DateTime fdecs;
        public DateTime Fdecs { get; set; }

        private int tarea;
        public int Tarea { get; set; }

        private int estadoTar;
        public int EstadoTar { get; set; }

        private int proceso;
        public int Proceso { get; set; }

        public DetalleProcesoN()
        {

        }
        public DetalleProcesoN(DateTime fdecs, int tarea, int estadoTar, int proceso)
        {
            this.Fdecs = fdecs;
            this.Tarea = tarea;
            this.EstadoTar = estadoTar;
            this.Proceso = proceso;
        }

    }
}