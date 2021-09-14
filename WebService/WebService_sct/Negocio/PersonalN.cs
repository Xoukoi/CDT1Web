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

    public class PersonalN
    {
        OracleConnection conn = null;


        public string Rut { get; set; }
        public string Nombre { get; set; }
        public string APaterno { get; set; }
        public int Telefono { get; set; }
        public string Correo { get; set; }
        public string Contrasenia { get; set; }
        public string Estado { get; set; }
        public string Cargo { get; set; }
        public int Rol_idRol { get; set; }
        public int Unidad_ID { get; set; }
        public string Personal_rut { get; set; }
        public string Unidad_nombre { get; set; }

        public PersonalN()
        {

        }

        public PersonalN(string rut, string nombre, string aPaterno, int telefono, string correo, string cargo, string unidad_nombre)
        {
            Rut = rut;
            Nombre = nombre;
            APaterno = aPaterno;
            Telefono = telefono;
            Correo = correo;
            Cargo = cargo;
            Unidad_nombre = unidad_nombre;
        }


        private void abrirConexion()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["oracleDB"].ConnectionString;
            conn = new OracleConnection(connectionString);

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {

                throw new Exception("error de conexion");
            }
        }

        public List<PersonalN> listaPersonalAsociadoAUnJefe(string rut)
        {
            Conexion c = new Conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "SELECT p.RUT, p.NOMBRE, p.APEPATE, p.TELEFONO, p.CORREO, p.CARGO, u.NOMUNI FROM PERSONAL p join UNIDADINTERNA u on(p.UNIDADINTERNA_IDUNIDAD = u.IDUNIDAD) WHERE p.ESTADO = 'habilitado' and p.PERSONAL_RUT = '"+rut+"'";
            cmd.CommandType = CommandType.Text;
            List<PersonalN> listaPersonal = new List<PersonalN>();

            using (DbDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        
                        string rute = dr["RUT"].ToString();
                        string nombr = dr["NOMBRE"].ToString();
                        string apat = dr["APEPATE"].ToString();
                        int telef  =  Convert.ToInt32(dr["TELEFONO"]);
                        string corr = dr["CORREO"].ToString();
                        string carg = dr["CARGO"].ToString();
                        string uninom = dr["NOMUNI"].ToString();

                        PersonalN p = new PersonalN(rute, nombr, apat, telef, corr, carg, uninom);

                        listaPersonal.Add(p);
                    }
                }
            }
            cnn.Dispose();
            return listaPersonal;
        }


    }
}