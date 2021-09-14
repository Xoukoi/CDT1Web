using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService_sct.Modelo;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using System.Data;


namespace WebService_sct.Negocio
{
    public class ProcesoN
    {

        OracleConnection conn = null;

        private int idProceso;
        public int IdProceso { get; set; }

        private string descripcion;
        public string Descripcion
        {
            get { return descripcion; }
            set
            {
                if (value.Trim().Length > 0)
                {

                    if (value.Trim().Length <= 100)
                    {
                        descripcion = value;
                    }
                    else
                    {
                        throw new Exception("Su descripcion no debe superar los 100 caracteres por favor");
                    }

                }
                else
                {
                    throw new Exception("Su descripcion no debe estar vacía");
                }
            }
        }

        private string nombreProceso;
        public string NombreProceso { get; set; }

        private DateTime fechainit;
        public DateTime Fechainit { get; set; }

        private DateTime fechater;
        public DateTime Fechater { get; set; }

        private DateTime fechaActual;
        public DateTime FechaActual
        {
            get { return fechaActual; }
            set
            {
                DateTime fechaActual = DateTime.Now.Date;
            }
        }

        private string estado;
        public string Estado { get; set; }

        private int unidadInt;
        public int UnidadInt { get; set; }



        public ProcesoN()
        {

        }

        public ProcesoN(int idProceso, string descripcion, string nombreProceso, DateTime fechainit, DateTime fechater, DateTime fechaActual,
            string estado, int unidadInt)
        {
            this.IdProceso = idProceso;
            this.Descripcion = descripcion;
            this.NombreProceso = nombreProceso;
            this.Fechainit = fechainit;
            this.Fechater = fechater;
            this.FechaActual = fechaActual;
            this.Estado = estado;
            this.UnidadInt = unidadInt;
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



        public List<ProcesoN> ListarProceso()
        {
            abrirConexion();
            try
            {
                OracleCommand cmd = new OracleCommand("PRO_LISTAR_PROCE_ACTIVOS", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                List<ProcesoN> lista = new List<ProcesoN>();

                OracleParameter output = cmd.Parameters.Add("L_CURSOR", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.ReturnValue;

                cmd.ExecuteNonQuery();

                OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();

                while (reader.Read())
                {
                    ProcesoN pro = new ProcesoN();
                    pro.IdProceso = reader.GetInt32(0);
                    pro.Descripcion = reader.GetString(1);
                    pro.NombreProceso = reader.GetString(2);
                    pro.Fechainit = reader.GetDateTime(3);
                    pro.Fechater = reader.GetDateTime(4);
                    pro.FechaActual = reader.GetDateTime(5);
                    pro.Estado = reader.GetString(6);
                    pro.UnidadInt = reader.GetInt32(7);

                    lista.Add(pro);

                }

                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void agregarProce(ProcesoN nuevo)
        {
            ProcesoCRUD modelo = new ProcesoCRUD();
            modelo.agregarProce(nuevo);
        }

        public void modificarProce(ProcesoN nue)
        {
            ProcesoCRUD modelo = new ProcesoCRUD();
            modelo.ModificarProce(nue);
        }

        public void eliminarProce(ProcesoN nu)
        {
            ProcesoCRUD modelo = new ProcesoCRUD();
            modelo.EliminarProce(nu);
        }
    }







}