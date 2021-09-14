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
    public class PersonalCRUD
    {
       public int agregarPer(PersonalN p)
        {
            Conexion c = new Conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = cnn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.CommandText = "PRO_CREAR_PERSONAL";

            cmd.Parameters.Add("RUT", OracleDbType.Varchar2).Value = p.Rut;
            cmd.Parameters.Add("NOMBRE",OracleDbType.Varchar2).Value =p.Nombre;
            cmd.Parameters.Add("TELEFONO",OracleDbType.Int32).Value = p.Telefono;
            cmd.Parameters.Add("CORREO",OracleDbType.Varchar2).Value = p.Correo;
            cmd.Parameters.Add("CONTRASENIA",OracleDbType.Varchar2).Value = p.Contrasenia;
            cmd.Parameters.Add("ESTADO",OracleDbType.Varchar2).Value = p.Estado;
            cmd.Parameters.Add("CARGO",OracleDbType.Varchar2).Value = p.Cargo;

            OracleParameter param = new OracleParameter();
            param = cmd.Parameters.Add("p_return", OracleDbType.Int32, ParameterDirection.Output);
            param.Size = 25;


            cmd.ExecuteNonQuery();
            int valorretorno = int.Parse(param.Value.ToString());
            cnn.Close();
            cmd.Dispose();
            cnn.Dispose();
            c = null;

            return valorretorno;
        }



        public int modificarPer(PersonalN p1)
        {

            try
            {

                Conexion _c = new Conexion();
                OracleConnection _conn = _c.conectar();
                _conn.Open();

                OracleCommand cmd = _conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.CommandText = "PRO_MODI_PERSONAL";

                cmd.Parameters.Add("RUT_PER",OracleDbType.Varchar2).Value = p1.Rut;
                cmd.Parameters.Add("NOM_PER",OracleDbType.Varchar2).Value= p1.Nombre;
                cmd.Parameters.Add("TELEF",OracleDbType.Int32).Value = p1.Telefono;
                cmd.Parameters.Add("CORREOO",OracleDbType.Varchar2).Value = p1.Correo;
                cmd.Parameters.Add("CONTRA",OracleDbType.Varchar2).Value = p1.Contrasenia;
                cmd.Parameters.Add("ESTAD",OracleDbType.Char).Value = p1.Estado;
                cmd.Parameters.Add("CARGOO", OracleDbType.Varchar2).Value = p1.Cargo;

                OracleParameter parameter = new OracleParameter();
                parameter = cmd.Parameters.Add("p_return", OracleDbType.Int32, ParameterDirection.Output);

                parameter.Size = 25;

                cmd.ExecuteNonQuery();
                int valorRetorno = int.Parse(parameter.Value.ToString());
                _conn.Close();
                cmd.Dispose();
                _conn.Dispose();

                _c = null;

                return valorRetorno;


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }


        }

        public int EliminarPersonal(string rut)
        {
            Conexion c = new Conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = cnn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "PRO_ELI_PERSONAL";
            cmd.Parameters.Add("p_personal_r", OracleDbType.Varchar2).Value = rut;
            OracleParameter param = new OracleParameter();
            param = cmd.Parameters.Add("p_return", OracleDbType.Int32, ParameterDirection.Output);
            param.Size = 25;
            cmd.ExecuteNonQuery();
            int valorretorno = int.Parse(param.Value.ToString());
            cnn.Close();
            cmd.Dispose();
            cnn.Dispose();
            c = null;

            return valorretorno;
        }
    }
}