using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebService_sct.Data;
using WebService_sct.Negocio;

namespace WebService_sct.Modelo
{
    public class ProcesoCRUD
    {
        public void agregarProce(ProcesoN pr)
        {
            Conexion c = new Conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = cnn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.CommandText = "PRO_CREAR_PROCESO";

            cmd.Parameters.Add("IDPROCESO", OracleDbType.Int32).Value = pr.IdProceso;
            cmd.Parameters.Add("DESCRIPCION", OracleDbType.Varchar2).Value = pr.Descripcion;
            cmd.Parameters.Add("NOMBREPROCESO", OracleDbType.Varchar2).Value = pr.NombreProceso;
            cmd.Parameters.Add("FECHAINIT", OracleDbType.Date).Value = pr.Fechainit;
            cmd.Parameters.Add("FECHATER", OracleDbType.Date).Value = pr.Fechater;
            cmd.Parameters.Add("FECHAACTUAL", OracleDbType.Date).Value = pr.FechaActual;
            cmd.Parameters.Add("ESTADO", OracleDbType.Varchar2).Value = pr.Estado;
            cmd.Parameters.Add("UNIDADINT", OracleDbType.Int32).Value = pr.UnidadInt;

            cmd.ExecuteNonQuery();
            cnn.Close();
            cmd.Dispose();
            cnn.Dispose();
            c = null;

        }


        public void ModificarProce(ProcesoN p)
        {
            Conexion c = new Conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = cnn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.CommandText = "PRO_MODIFICAR_PROCESO";


            cmd.Parameters.Add("proceid", OracleDbType.Int32).Value = p.IdProceso;
            cmd.Parameters.Add("descrip", OracleDbType.Varchar2).Value = p.Descripcion;
            cmd.Parameters.Add("pronombre", OracleDbType.Varchar2).Value = p.NombreProceso;


            cmd.ExecuteNonQuery();
            cnn.Close();
            cmd.Dispose();
            cnn.Dispose();
            c = null;
        }

        public void EliminarProce(ProcesoN p)
        {
            Conexion _c = new Conexion();
            OracleConnection _conn = _c.conectar();
            _conn.Open();

            OracleCommand cmd = _conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.CommandText = "PRO_ELIMINAR_PROCESO";
            cmd.Parameters.Add("IDPROCESO", OracleDbType.Int32).Value = p.IdProceso;

            cmd.ExecuteNonQuery();
            _conn.Close();
            cmd.Dispose();
            _conn.Dispose();

            _c = null;
        }
    }
}