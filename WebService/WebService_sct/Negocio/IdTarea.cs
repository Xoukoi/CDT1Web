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
    public class IdTarea
    {
        public int idtarea { get; set; }

        public IdTarea()
        {
        }

        public List<IdTarea> listarIdTareas(string rut)
        {
            Conexion c = new Conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "SELECT t.idtarea FROM TAREA t join PROCESO p on(t.proceso_idproceso = p.IDPROCESO) WHERE habilitado = 'habilitado' and adjudicador = '"+rut+"' or tipotarea = 2";
            cmd.CommandType = CommandType.Text;
            List<IdTarea> listaIds = new List<IdTarea>();

            using (DbDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        IdTarea t = new IdTarea();

                        int idtareas = Convert.ToInt32(dr["idtarea"]);
                        t.idtarea = idtareas;
                        listaIds.Add(t);

                    }
                }
            }
            cnn.Dispose();
            return listaIds;
        }
        public List<IdTarea> buscarIdProce(string nombreproce)
        {
            Conexion c = new Conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "Select IDPROCESO FROM PROCESO WHERE NOMBREPROCESO = '"+nombreproce+"'";
            cmd.CommandType = CommandType.Text;
            List<IdTarea> listaIds = new List<IdTarea>();

            using (DbDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        IdTarea t = new IdTarea();

                        int idtareas = Convert.ToInt32(dr["IDPROCESO"]);
                        t.idtarea = idtareas;
                        listaIds.Add(t);

                    }
                }
            }
            cnn.Dispose();
            return listaIds;
        }

        public List<IdTarea> ContarTareas()
        {
            Conexion c = new Conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "Select count(idtarea) from TAREA";
            cmd.CommandType = CommandType.Text;
            List<IdTarea> listaIds = new List<IdTarea>();

            using (DbDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        IdTarea t = new IdTarea();

                        int idtareas = Convert.ToInt32(dr["count(idtarea)"]);
                        t.idtarea = idtareas;
                        listaIds.Add(t);

                    }
                }
            }
            cnn.Dispose();
            return listaIds;
        }

        public List<IdTarea> Contarejecuciones()
        {
            Conexion c = new Conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "Select count(IDEJECUCION) from EJECUCION";
            cmd.CommandType = CommandType.Text;
            List<IdTarea> listaIds = new List<IdTarea>();

            using (DbDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        IdTarea t = new IdTarea();

                        int idtareas = Convert.ToInt32(dr["count(IDEJECUCION)"]);
                        t.idtarea = idtareas;
                        listaIds.Add(t);

                    }
                }
            }
            cnn.Dispose();
            return listaIds;
        }

        public List<IdTarea> ContarTareasAceptadas(string rut, int ano, int mes)
        {
            Conexion c = new Conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "Select count(IDEJECUCION) FROM ejecucion where PERSONAL_RUT = '"+rut+"' AND NOTIFICACION = 'aceptada' and EXTRACT(year from fechainicio)="+ ano +"and EXTRACT(month from fechainicio)="+ mes;
            cmd.CommandType = CommandType.Text;
            List<IdTarea> listaIds = new List<IdTarea>();

            using (DbDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        IdTarea t = new IdTarea();

                        int idtareas = Convert.ToInt32(dr["count(IDEJECUCION)"]);
                        t.idtarea = idtareas;
                        listaIds.Add(t);

                    }
                }
            }
            cnn.Dispose();
            return listaIds;
        }

        public List<IdTarea> ContarTareasRechazadas(string rut, int ano, int mes)
        {
            Conexion c = new Conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "Select count(IDEJECUCION) FROM ejecucion where PERSONAL_RUT = '" + rut + "' AND NOTIFICACION = 'rechazada' and EXTRACT(year from fechainicio)=" + ano + "and EXTRACT(month from fechainicio)=" + mes;
            cmd.CommandType = CommandType.Text;
            List<IdTarea> listaIds = new List<IdTarea>();

            using (DbDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        IdTarea t = new IdTarea();

                        int idtareas = Convert.ToInt32(dr["count(IDEJECUCION)"]);
                        t.idtarea = idtareas;
                        listaIds.Add(t);

                    }
                }
            }
            cnn.Dispose();
            return listaIds;
        }

        public List<IdTarea> ContarTareasAtiempo(string rut)
        {
            Conexion c = new Conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "Select count(IDEJECUCION)FROM ejecucion e JOIN ESTADOTAR t on(e.IDEJECUCION = t.EJECUCION_IDEJECUCION) where e.PERSONAL_RUT = '"+rut+"' AND t.ESTADO = 'terminada'";
            cmd.CommandType = CommandType.Text;
            List<IdTarea> listaIds = new List<IdTarea>();

            using (DbDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        IdTarea t = new IdTarea();

                        int idtareas = Convert.ToInt32(dr["count(IDEJECUCION)"]);
                        t.idtarea = idtareas;
                        listaIds.Add(t);

                    }
                }
            }
            cnn.Dispose();
            return listaIds;
        }

        public List<IdTarea> ContarTareasAtrasada(string rut)
        {
            Conexion c = new Conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "Select count(IDEJECUCION)FROM ejecucion e JOIN ESTADOTAR t on(e.IDEJECUCION = t.EJECUCION_IDEJECUCION) where e.PERSONAL_RUT = '" + rut + "' AND t.ESTADO = 'atrasada'";
            cmd.CommandType = CommandType.Text;
            List<IdTarea> listaIds = new List<IdTarea>();

            using (DbDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        IdTarea t = new IdTarea();

                        int idtareas = Convert.ToInt32(dr["count(IDEJECUCION)"]);
                        t.idtarea = idtareas;
                        listaIds.Add(t);

                    }
                }
            }
            cnn.Dispose();
            return listaIds;
        }

        public List<IdTarea> ContarEstadosTar()
        {
            Conexion c = new Conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "select count(IDESTTAR) from estadotar";
            cmd.CommandType = CommandType.Text;
            List<IdTarea> listaIds = new List<IdTarea>();

            using (DbDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        IdTarea t = new IdTarea();

                        int idtareas = Convert.ToInt32(dr["count(IDESTTAR)"]);
                        t.idtarea = idtareas;
                        listaIds.Add(t);

                    }
                }
            }
            cnn.Dispose();
            return listaIds;
        }

        public List<IdTarea> ContarProcesos()
        {
            Conexion c = new Conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "select count(IDPROCESO) from PROCESO";
            cmd.CommandType = CommandType.Text;
            List<IdTarea> listaIds = new List<IdTarea>();

            using (DbDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        IdTarea t = new IdTarea();

                        int idtareas = Convert.ToInt32(dr["count(IDPROCESO)"]);
                        t.idtarea = idtareas;
                        listaIds.Add(t);

                    }
                }
            }
            cnn.Dispose();
            return listaIds;
        }


    }
}