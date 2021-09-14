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
    public class EstadoTarN
    {

        public int idestadotar { get; set; }
        public string estado { get; set; }
        public string descripcion { get; set; }
        public int idejecu { get; set; }
        public EstadoTarN()
        {

        }


        public void agregarEstadTarea(EstadoTarN nuevo)
        {
            EstadoTarCRUD modelo = new EstadoTarCRUD();
            modelo.agregarEstadoTar(nuevo);
        }


    }
}