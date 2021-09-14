using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Data.Common;
using WebService_sct.Data;
using WebService_sct.Negocio;

namespace WebService_sct.Modelo
{
    public class EstadoTarCRUD
    {
        public void agregarEstadoTar(EstadoTarN t)
        {

            Conexion c = new Conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = cnn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.CommandText = "PRO_CREAR_ESTADOTAR";


            cmd.Parameters.Add("idestar", OracleDbType.Int32).Value = t.idestadotar;
            cmd.Parameters.Add("estado", OracleDbType.Varchar2).Value = t.estado;
            cmd.Parameters.Add("descripc", OracleDbType.Varchar2).Value = t.descripcion;
            cmd.Parameters.Add("ejecu_idejecu", OracleDbType.Int32).Value = t.idejecu;


            cmd.ExecuteNonQuery();
            cnn.Close();
            cmd.Dispose();
            cnn.Dispose();
            c = null;
        }
    }
}