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
    public class EjecucionCRUD
    {
        public void agregarEjecucion(EjecucionN eje)
        {
            DateTime thisDay = DateTime.Today;

            Conexion c = new Conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = cnn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.CommandText = "PRO_CREAR_EJECUCION";

            cmd.Parameters.Add("idejec", OracleDbType.Int32).Value = eje.idEjec;
            cmd.Parameters.Add("descripcion", OracleDbType.Varchar2).Value = eje.descrip;
            cmd.Parameters.Add("fechainicio", OracleDbType.Date).Value = eje.fechaInicio;
            cmd.Parameters.Add("fechatermino", OracleDbType.Date).Value = eje.fechaTermino;
            cmd.Parameters.Add("fechaejecucion", OracleDbType.Date).Value = eje.fechaEjecucion;
            cmd.Parameters.Add("personalrut", OracleDbType.Varchar2).Value = eje.personal_rut;
            cmd.Parameters.Add("semaforo", OracleDbType.Varchar2).Value = eje.semaforo;
            cmd.Parameters.Add("notificacion", OracleDbType.Varchar2).Value = eje.notifi;
            cmd.Parameters.Add("tareid", OracleDbType.Int32).Value = eje.tareaId;


            cmd.ExecuteNonQuery();

            cnn.Close();
            cmd.Dispose();
            cnn.Dispose();
            c = null;

        }

        public List<EjecucionN> listaEjecucionesAsociadasPorConfirmar(string rut)
        {
            Conexion c = new Conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "select e.IDEJECUCION, e.DESCRIPCIONEJE, e.FECHAINICIO, e.FECHATERMINO, e.FECHAEJEC, e.SEMAFORO, e.NOTIFICACION, t.TIPOTAREA, t.NOMBRETA, t.DESCRIPCION, t.OBSERVACION, t.ADJUDICADOR from ejecucion e JOIN tarea t on(e.TAREA_IDTAREA = t.IDTAREA) where e.notificacion = 'porconfirmar' and  e.PERSONAL_RUT ='" + rut+"'";
            cmd.CommandType = CommandType.Text;
            List<EjecucionN> listaEjecu = new List<EjecucionN>();

            using (DbDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        EjecucionN t = new EjecucionN();

                        int ideje = Convert.ToInt32(dr["IDEJECUCION"]);
                        string descripeje = dr["DESCRIPCIONEJE"].ToString();
                        DateTime fechaini = (DateTime)dr["FECHAINICIO"];
                        DateTime fechater = (DateTime)dr["FECHATERMINO"];
                        DateTime fechaeje = (DateTime)dr["FECHAEJEC"];
                        string semaforo = dr["SEMAFORO"].ToString();
                        string notificacion = dr["NOTIFICACION"].ToString();
                        int tipoTar = Convert.ToInt32(dr["TIPOTAREA"]);
                        string nombreTar = dr["NOMBRETA"].ToString();
                        string descripcionTar = dr["DESCRIPCION"].ToString();
                        string observacionTar = dr["OBSERVACION"].ToString();
                        string rutAdjudicador = dr["ADJUDICADOR"].ToString();

                        t.idEjec = ideje;
                        t.descrip = descripeje;
                        t.fechaInicio = fechaini;
                        t.fechaTermino = fechater;
                        t.fechaEjecucion = fechaeje;
                        t.semaforo = semaforo;
                        t.notifi = notificacion;
                        t.tipota = tipoTar;
                        t.nombreta = nombreTar;
                        t.descripcionTar = descripcionTar;
                        t.observacionTar = observacionTar;
                        t.rutAdjudicador = rutAdjudicador;

                        listaEjecu.Add(t);
                    }
                }
            }
            cnn.Dispose();
            return listaEjecu;
        }
        public List<EjecucionN> listaEjecucionesAsociadasAceptadas(string rut)
        {
            Conexion c = new Conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "select e.IDEJECUCION, e.DESCRIPCIONEJE, e.FECHAINICIO, e.FECHATERMINO, e.FECHAEJEC, e.SEMAFORO, e.NOTIFICACION, t.TIPOTAREA, t.NOMBRETA, t.DESCRIPCION, t.OBSERVACION, t.ADJUDICADOR from ejecucion e JOIN tarea t on(e.TAREA_IDTAREA = t.IDTAREA) where e.notificacion = 'aceptada' and  e.PERSONAL_RUT ='" + rut + "'";
            cmd.CommandType = CommandType.Text;
            List<EjecucionN> listaEjecu = new List<EjecucionN>();

            using (DbDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        EjecucionN t = new EjecucionN();

                        int ideje = Convert.ToInt32(dr["IDEJECUCION"]);
                        string descripeje = dr["DESCRIPCIONEJE"].ToString();
                        DateTime fechaini = (DateTime)dr["FECHAINICIO"];
                        DateTime fechater = (DateTime)dr["FECHATERMINO"];
                        DateTime fechaeje = (DateTime)dr["FECHAEJEC"];
                        string semaforo = dr["SEMAFORO"].ToString();
                        string notificacion = dr["NOTIFICACION"].ToString();
                        int tipoTar = Convert.ToInt32(dr["TIPOTAREA"]);
                        string nombreTar = dr["NOMBRETA"].ToString();
                        string descripcionTar = dr["DESCRIPCION"].ToString();
                        string observacionTar = dr["OBSERVACION"].ToString();
                        string rutAdjudicador = dr["ADJUDICADOR"].ToString();

                        t.idEjec = ideje;
                        t.descrip = descripeje;
                        t.fechaInicio = fechaini;
                        t.fechaTermino = fechater;
                        t.fechaEjecucion = fechaeje;
                        t.semaforo = semaforo;
                        t.notifi = notificacion;
                        t.tipota = tipoTar;
                        t.nombreta = nombreTar;
                        t.descripcionTar = descripcionTar;
                        t.observacionTar = observacionTar;
                        t.rutAdjudicador = rutAdjudicador;

                        listaEjecu.Add(t);
                    }
                }
            }
            cnn.Dispose();
            return listaEjecu;
        }


        public List<EjecucionN> ReportelistaEjecucionesAsociadasAceptadas(string rut, int ano, int mes)
        {
            Conexion c = new Conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "select e.IDEJECUCION, e.DESCRIPCIONEJE, e.FECHAINICIO, e.FECHATERMINO, e.FECHAEJEC, e.SEMAFORO, e.NOTIFICACION, t.TIPOTAREA, t.NOMBRETA, t.DESCRIPCION, t.OBSERVACION, t.ADJUDICADOR from ejecucion e JOIN tarea t on(e.TAREA_IDTAREA = t.IDTAREA) where e.notificacion = 'aceptada' and e.PERSONAL_RUT = '" + rut + "' and EXTRACT(year from fechainicio)=" + ano + " and EXTRACT(month from fechainicio)= "+mes;
            cmd.CommandType = CommandType.Text;
            List<EjecucionN> listaEjecu = new List<EjecucionN>();

            using (DbDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        EjecucionN t = new EjecucionN();

                        int ideje = Convert.ToInt32(dr["IDEJECUCION"]);
                        string descripeje = dr["DESCRIPCIONEJE"].ToString();
                        DateTime fechaini = (DateTime)dr["FECHAINICIO"];
                        DateTime fechater = (DateTime)dr["FECHATERMINO"];
                        DateTime fechaeje = (DateTime)dr["FECHAEJEC"];
                        string semaforo = dr["SEMAFORO"].ToString();
                        string notificacion = dr["NOTIFICACION"].ToString();
                        int tipoTar = Convert.ToInt32(dr["TIPOTAREA"]);
                        string nombreTar = dr["NOMBRETA"].ToString();
                        string descripcionTar = dr["DESCRIPCION"].ToString();
                        string observacionTar = dr["OBSERVACION"].ToString();
                        string rutAdjudicador = dr["ADJUDICADOR"].ToString();

                        t.idEjec = ideje;
                        t.descrip = descripeje;
                        t.fechaInicio = fechaini;
                        t.fechaTermino = fechater;
                        t.fechaEjecucion = fechaeje;
                        t.semaforo = semaforo;
                        t.notifi = notificacion;
                        t.tipota = tipoTar;
                        t.nombreta = nombreTar;
                        t.descripcionTar = descripcionTar;
                        t.observacionTar = observacionTar;
                        t.rutAdjudicador = rutAdjudicador;

                        listaEjecu.Add(t);
                    }
                }
            }
            cnn.Dispose();
            return listaEjecu;
        }

        public List<EjecucionN> ReportelistaEjecucionesAsociadasRechazadas(string rut, int ano, int mes)
        {
            Conexion c = new Conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "select e.IDEJECUCION, e.DESCRIPCIONEJE, e.FECHAINICIO, e.FECHATERMINO, e.FECHAEJEC, e.SEMAFORO, e.NOTIFICACION, t.TIPOTAREA, t.NOMBRETA, t.DESCRIPCION, t.OBSERVACION, t.ADJUDICADOR from ejecucion e JOIN tarea t on(e.TAREA_IDTAREA = t.IDTAREA) where e.notificacion = 'rechazada' and e.PERSONAL_RUT = '" + rut + "' and EXTRACT(year from fechainicio)=" + 2021 + " and EXTRACT(month from fechainicio)= " + 06;
            cmd.CommandType = CommandType.Text;
            List<EjecucionN> listaEjecu = new List<EjecucionN>();

            using (DbDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        EjecucionN t = new EjecucionN();

                        int ideje = Convert.ToInt32(dr["IDEJECUCION"]);
                        string descripeje = dr["DESCRIPCIONEJE"].ToString();
                        DateTime fechaini = (DateTime)dr["FECHAINICIO"];
                        DateTime fechater = (DateTime)dr["FECHATERMINO"];
                        DateTime fechaeje = (DateTime)dr["FECHAEJEC"];
                        string semaforo = dr["SEMAFORO"].ToString();
                        string notificacion = dr["NOTIFICACION"].ToString();
                        int tipoTar = Convert.ToInt32(dr["TIPOTAREA"]);
                        string nombreTar = dr["NOMBRETA"].ToString();
                        string descripcionTar = dr["DESCRIPCION"].ToString();
                        string observacionTar = dr["OBSERVACION"].ToString();
                        string rutAdjudicador = dr["ADJUDICADOR"].ToString();

                        t.idEjec = ideje;
                        t.descrip = descripeje;
                        t.fechaInicio = fechaini;
                        t.fechaTermino = fechater;
                        t.fechaEjecucion = fechaeje;
                        t.semaforo = semaforo;
                        t.notifi = notificacion;
                        t.tipota = tipoTar;
                        t.nombreta = nombreTar;
                        t.descripcionTar = descripcionTar;
                        t.observacionTar = observacionTar;
                        t.rutAdjudicador = rutAdjudicador;

                        listaEjecu.Add(t);
                    }
                }
            }
            cnn.Dispose();
            return listaEjecu;
        }

        public List<EjecucionN> ReportelistaEjecucionesAsociadasAtiempo(string rut, int ano, int mes)
        {
            Conexion c = new Conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "select e.IDEJECUCION, e.DESCRIPCIONEJE, e.FECHAINICIO, e.FECHATERMINO, e.FECHAEJEC, e.SEMAFORO, e.NOTIFICACION, t.TIPOTAREA, t.NOMBRETA, t.DESCRIPCION, t.OBSERVACION, t.ADJUDICADOR from ejecucion e JOIN tarea t on(e.TAREA_IDTAREA = t.IDTAREA) where e.notificacion = 'atiempo' and e.PERSONAL_RUT = '191105704' and EXTRACT(year from fechainicio)=" + 2021 + " and EXTRACT(month from fechainicio)= " + 06;
            cmd.CommandType = CommandType.Text;
            List<EjecucionN> listaEjecu = new List<EjecucionN>();

            using (DbDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        EjecucionN t = new EjecucionN();

                        int ideje = Convert.ToInt32(dr["IDEJECUCION"]);
                        string descripeje = dr["DESCRIPCIONEJE"].ToString();
                        DateTime fechaini = (DateTime)dr["FECHAINICIO"];
                        DateTime fechater = (DateTime)dr["FECHATERMINO"];
                        DateTime fechaeje = (DateTime)dr["FECHAEJEC"];
                        string semaforo = dr["SEMAFORO"].ToString();
                        string notificacion = dr["NOTIFICACION"].ToString();
                        int tipoTar = Convert.ToInt32(dr["TIPOTAREA"]);
                        string nombreTar = dr["NOMBRETA"].ToString();
                        string descripcionTar = dr["DESCRIPCION"].ToString();
                        string observacionTar = dr["OBSERVACION"].ToString();
                        string rutAdjudicador = dr["ADJUDICADOR"].ToString();

                        t.idEjec = ideje;
                        t.descrip = descripeje;
                        t.fechaInicio = fechaini;
                        t.fechaTermino = fechater;
                        t.fechaEjecucion = fechaeje;
                        t.semaforo = semaforo;
                        t.notifi = notificacion;
                        t.tipota = tipoTar;
                        t.nombreta = nombreTar;
                        t.descripcionTar = descripcionTar;
                        t.observacionTar = observacionTar;
                        t.rutAdjudicador = rutAdjudicador;

                        listaEjecu.Add(t);
                    }
                }
            }
            cnn.Dispose();
            return listaEjecu;
        }

        public List<EjecucionN> ReportelistaEjecucionesAsociadasatrasadas(string rut, int ano, int mes)
        {
            Conexion c = new Conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "select e.IDEJECUCION, e.DESCRIPCIONEJE, e.FECHAINICIO, e.FECHATERMINO, e.FECHAEJEC, e.SEMAFORO, e.NOTIFICACION, t.TIPOTAREA, t.NOMBRETA, t.DESCRIPCION, t.OBSERVACION, t.ADJUDICADOR from ejecucion e JOIN tarea t on(e.TAREA_IDTAREA = t.IDTAREA) where e.notificacion = 'atrasada' and e.PERSONAL_RUT = '191105704' and EXTRACT(year from fechainicio)=" + 2021 + " and EXTRACT(month from fechainicio)= " + 06;
            cmd.CommandType = CommandType.Text;
            List<EjecucionN> listaEjecu = new List<EjecucionN>();

            using (DbDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        EjecucionN t = new EjecucionN();

                        int ideje = Convert.ToInt32(dr["IDEJECUCION"]);
                        string descripeje = dr["DESCRIPCIONEJE"].ToString();
                        DateTime fechaini = (DateTime)dr["FECHAINICIO"];
                        DateTime fechater = (DateTime)dr["FECHATERMINO"];
                        DateTime fechaeje = (DateTime)dr["FECHAEJEC"];
                        string semaforo = dr["SEMAFORO"].ToString();
                        string notificacion = dr["NOTIFICACION"].ToString();
                        int tipoTar = Convert.ToInt32(dr["TIPOTAREA"]);
                        string nombreTar = dr["NOMBRETA"].ToString();
                        string descripcionTar = dr["DESCRIPCION"].ToString();
                        string observacionTar = dr["OBSERVACION"].ToString();
                        string rutAdjudicador = dr["ADJUDICADOR"].ToString();

                        t.idEjec = ideje;
                        t.descrip = descripeje;
                        t.fechaInicio = fechaini;
                        t.fechaTermino = fechater;
                        t.fechaEjecucion = fechaeje;
                        t.semaforo = semaforo;
                        t.notifi = notificacion;
                        t.tipota = tipoTar;
                        t.nombreta = nombreTar;
                        t.descripcionTar = descripcionTar;
                        t.observacionTar = observacionTar;
                        t.rutAdjudicador = rutAdjudicador;

                        listaEjecu.Add(t);
                    }
                }
            }
            cnn.Dispose();
            return listaEjecu;
        }

        public List<EjecucionN> listaEjecucionesAsociadasTerminadas(string rut)
        {
            Conexion c = new Conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "select e.IDEJECUCION, e.DESCRIPCIONEJE, e.FECHAEJEC, t.NOMBRETA, t.DESCRIPCION, t.observacion, e.PERSONAL_RUT from TAREA t join EJECUCION E ON(t.IDTAREA = e.TAREA_IDTAREA) where e.notificacion = 'terminada' and t.adjudicador = '" + rut+"'";
            cmd.CommandType = CommandType.Text;
            List<EjecucionN> listaEjecu = new List<EjecucionN>();

            using (DbDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        EjecucionN t = new EjecucionN();

                        int ideje = Convert.ToInt32(dr["IDEJECUCION"]);
                        string descripeje = dr["DESCRIPCIONEJE"].ToString();
                        DateTime fechaeje = (DateTime)dr["FECHAEJEC"];
                        string nombreTar = dr["NOMBRETA"].ToString();
                        string descripcionTar = dr["DESCRIPCION"].ToString();
                        string observacionTar = dr["OBSERVACION"].ToString();
                        string perRut = dr["PERSONAL_RUT"].ToString();

                        t.idEjec = ideje;
                        t.descrip = descripeje;
                        t.fechaEjecucion = fechaeje;
                        t.nombreta = nombreTar;
                        t.descripcionTar = descripcionTar;
                        t.observacionTar = observacionTar;
                        t.personal_rut = perRut;
                        listaEjecu.Add(t);
                    }
                }
            }
            cnn.Dispose();
            return listaEjecu;
        }
        public List<EjecucionN> listaEjecucionesAsociadasRevisadas(string rut)
        {
            Conexion c = new Conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "select e.IDEJECUCION, e.DESCRIPCIONEJE, e.FECHAEJEC, t.NOMBRETA, t.DESCRIPCION, t.observacion, e.PERSONAL_RUT from TAREA t join EJECUCION E ON(t.IDTAREA = e.TAREA_IDTAREA) where e.notificacion = 'revisada' and t.adjudicador = '" + rut + "'";
            cmd.CommandType = CommandType.Text;
            List<EjecucionN> listaEjecu = new List<EjecucionN>();

            using (DbDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        EjecucionN t = new EjecucionN();

                        int ideje = Convert.ToInt32(dr["IDEJECUCION"]);
                        string descripeje = dr["DESCRIPCIONEJE"].ToString();
                        DateTime fechaeje = (DateTime)dr["FECHAEJEC"];
                        string nombreTar = dr["NOMBRETA"].ToString();
                        string descripcionTar = dr["DESCRIPCION"].ToString();
                        string observacionTar = dr["OBSERVACION"].ToString();
                        string perRut = dr["PERSONAL_RUT"].ToString();

                        t.idEjec = ideje;
                        t.descrip = descripeje;
                        t.fechaEjecucion = fechaeje;
                        t.nombreta = nombreTar;
                        t.descripcionTar = descripcionTar;
                        t.observacionTar = observacionTar;
                        t.personal_rut = perRut;
                        listaEjecu.Add(t);
                    }
                }
            }
            cnn.Dispose();
            return listaEjecu;
        }

        public void CambiarEstadoEjecucion(EjecucionN t)
        {

            Conexion c = new Conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = cnn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.CommandText = "PRO_ESTADO_EJECUCION";


            cmd.Parameters.Add("idEjecu", OracleDbType.Int32).Value = t.idEjec;
            cmd.Parameters.Add("notificacio ", OracleDbType.Varchar2).Value = t.notifi;
            cmd.Parameters.Add("fechaeje ", OracleDbType.Date).Value = t.fechaEjecucion;


            cmd.ExecuteNonQuery();

            cnn.Close();
            cmd.Dispose();
            cnn.Dispose();
            c = null;

        }
    }
}