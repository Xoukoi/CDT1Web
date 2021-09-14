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
    public class NombreProceN
    {

        public string Nombre { get; set; }

        public NombreProceN()
        {
        }

        public List<NombreProceN> listarRutAso(string rut)
        {
            Conexion c = new Conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "SELECT RUT FROM PERSONAL where PERSONAL_RUT = '" + rut + "'";
            cmd.CommandType = CommandType.Text;
            List<NombreProceN> listaruts = new List<NombreProceN>();

            using (DbDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        NombreProceN t = new NombreProceN();

                        string nomb = dr["RUT"].ToString();
                        t.Nombre = nomb;
                        listaruts.Add(t);

                    }
                }
            }
            cnn.Dispose();
            return listaruts;
        }

        public List<NombreProceN> listarnombreProcesos()
        {
            Conexion c = new Conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "SELECT NOMBREPROCESO FROM PROCESO where estado = 'habilitado'";
            cmd.CommandType = CommandType.Text;
            List<NombreProceN> listaNombres = new List<NombreProceN>();
            
            using (DbDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        NombreProceN t = new NombreProceN();

                        string nombres = dr["NOMBREPROCESO"].ToString();
                        t.Nombre = nombres;
                        listaNombres.Add(t);

                    }
                }
            }
            cnn.Dispose();
            return listaNombres;
        }
        public List<NombreProceN> mostrarNombrePer(string rut)
        {
            Conexion c = new Conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "select NOMBRE from personal where RUT = '"+rut+"'";
            cmd.CommandType = CommandType.Text;
            List<NombreProceN> listaNombres = new List<NombreProceN>();

            using (DbDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        NombreProceN t = new NombreProceN();

                        string nombres = dr["NOMBRE"].ToString();
                        t.Nombre = nombres;
                        listaNombres.Add(t);

                    }
                }
            }
            cnn.Dispose();
            return listaNombres;
        }

        public List<NombreProceN> mostrarApellidoPer(string rut)
        {
            Conexion c = new Conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "select APEPATE from personal where RUT = '" + rut + "'";
            cmd.CommandType = CommandType.Text;
            List<NombreProceN> listaNombres = new List<NombreProceN>();

            using (DbDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        NombreProceN t = new NombreProceN();

                        string nombres = dr["APEPATE"].ToString();
                        t.Nombre = nombres;
                        listaNombres.Add(t);

                    }
                }
            }
            cnn.Dispose();
            return listaNombres;
        }

    }
}