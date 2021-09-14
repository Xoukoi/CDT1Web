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
    public class TareaCRUD
    {
        public void agregarTarea(TareaN t)
        {
            int? taridd = 0;
            if (t.tar_idtar == 0)
            {
                taridd = null;
                
            }
            else
            {
                taridd = t.tar_idtar;
            }
            
            Conexion c = new Conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = cnn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.CommandText = "PRO_CREAR_TAREAS";
            

            cmd.Parameters.Add("tareaid", OracleDbType.Int32).Value = t.IdTarea;
            cmd.Parameters.Add("tipota", OracleDbType.Int32).Value = t.tipoTarea;
            cmd.Parameters.Add("tanombre", OracleDbType.Varchar2).Value = t.nombreTa;
            cmd.Parameters.Add("descripc", OracleDbType.Varchar2).Value = t.descripcion;
            cmd.Parameters.Add("obser", OracleDbType.Varchar2).Value = t.observacion;
            cmd.Parameters.Add("adjudi", OracleDbType.Varchar2).Value = t.adjudicador;
            cmd.Parameters.Add("habi", OracleDbType.Varchar2).Value = t.habilitado;

            cmd.Parameters.Add("tareaid_tare", OracleDbType.Int32).Value = taridd;
            cmd.Parameters.Add("proce", OracleDbType.Int32).Value = t.idProce;



            cmd.ExecuteNonQuery();
            cnn.Close();
            cmd.Dispose();
            cnn.Dispose();
            c = null;

        }

        public void editarTarea(TareaN t)
        {

            Conexion c = new Conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = cnn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.CommandText = "PRO_MODIF_TAREAS2";


            cmd.Parameters.Add("tareaid", OracleDbType.Int32).Value = t.IdTarea;
            cmd.Parameters.Add("tanombre", OracleDbType.Varchar2).Value = t.nombreTa;
            cmd.Parameters.Add("descripc", OracleDbType.Varchar2).Value = t.descripcion;
            cmd.Parameters.Add("obser", OracleDbType.Varchar2).Value = t.observacion;

            cmd.ExecuteNonQuery();
            cnn.Close();
            cmd.Dispose();
            cnn.Dispose();
            c = null;

        }
        
        public void deshabilitarTarea(TareaN t)
        {

            Conexion c = new Conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = cnn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.CommandText = "PRO_DESHABILITAR_TAREAS";


            cmd.Parameters.Add("tareaid", OracleDbType.Int32).Value = t.IdTarea;
            cmd.Parameters.Add("habi", OracleDbType.Varchar2).Value = t.habilitado;



            cmd.ExecuteNonQuery();
            cnn.Close();
            cmd.Dispose();
            cnn.Dispose();
            c = null;

        }


        



    }
}