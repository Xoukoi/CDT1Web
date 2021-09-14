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
    public class TareaN
    {
        OracleConnection conn = null;


        public int IdTarea { get; set; }
        public int tipoTarea { get; set; }
        public string nombreTa { get; set; }

        public string habilitado { get; set; }

        public string descripcion { get; set; }

        public string observacion { get; set; }

        public string adjudicador { get; set; }

        public int tar_idtar { get; set; }

        public string proce_nomb { get; set; }

        public int idProce { get; set; }



        public TareaN()
        {
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

                throw new Exception ("error de conexion"); 
            }
        }
        
         public List<TareaN> listarTareaaaa()
        {
            abrirConexion();
            try
            {
                OracleCommand cmd = new OracleCommand("PRO_LISTAR_TAREAS", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                List<TareaN> lista = new List<TareaN>();

                OracleParameter output = cmd.Parameters.Add("R_CURSOR", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.ReturnValue;

                cmd.ExecuteNonQuery();

                OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();

                while (reader.Read())
                {
                    TareaN per = new TareaN();
                    per.IdTarea = reader.GetInt32(0);
                    per.tipoTarea = reader.GetInt32(1);
                    per.descripcion = reader.GetString(2);
                    per.observacion = reader.GetString(3);
                    per.adjudicador = reader.GetString(4);
                    per.habilitado = reader.GetString(5);
                    per.tar_idtar = reader.GetInt32(1);
                    lista.Add(per);

                }

                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

       

        public List<TareaN> listartareaAs(String rute)
        {
            Conexion c = new Conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = cnn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "PRO_BUSCAR_TARE_AS";
            cmd.Parameters.Add("P_RUT", OracleDbType.Varchar2).Value = "191105702";
            OracleParameter output = cmd.Parameters.Add(new OracleParameter("Ta_aso", OracleDbType.RefCursor, ParameterDirection.Output));
            output.Direction = ParameterDirection.ReturnValue;

            cmd.ExecuteNonQuery();

            OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();
            List<TareaN> listaTareas = new List<TareaN>();
            OracleDataAdapter da = new OracleDataAdapter();
            System.Diagnostics.Debug.WriteLine("hola primero");
            while (reader.Read())
            {
                TareaN nuevo = new TareaN();

                nuevo.nombreTa = reader.GetString(0);
                nuevo.nombreTa = reader.GetString(1);
                System.Diagnostics.Debug.WriteLine(nuevo.nombreTa);
                System.Diagnostics.Debug.WriteLine("hola");
                listaTareas.Add(nuevo);
            }
            cnn.Dispose();
            return listaTareas;
        }
        public List<TareaN> listaTareasAsociadas(string rut)
        {
            Conexion c = new Conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "SELECT t.idtarea,t.tipotarea,t.nombreta, t.DESCRIPCION, t.OBSERVACION, t.ADJUDICADOR, t.HABILITADO, t.TAREA_IDTAREA, p.nombreproceso, p.IDPROCESO FROM TAREA t join PROCESO p on(t.proceso_idproceso = p.IDPROCESO) WHERE habilitado = 'habilitado' and adjudicador ='" + rut+ "' or tipotarea = 2 order by t.idtarea";
            cmd.CommandType = CommandType.Text;
            List<TareaN> listaTarea = new List<TareaN>();

            using (DbDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        int tareid_tare;
                        TareaN t = new TareaN();

                       

                        int idtare = Convert.ToInt32(dr["idtarea"]);
                        int tipota = Convert.ToInt32(dr["tipotarea"]);
                        string nombre = dr["nombreta"].ToString();
                        string habilitado = dr["HABILITADO"].ToString();
                        string descr = dr["DESCRIPCION"].ToString();
                        string obser = dr["OBSERVACION"].ToString();
                        string adju = dr["ADJUDICADOR"].ToString();
                        if (dr["TAREA_IDTAREA"] != DBNull.Value)
                        {
                            tareid_tare = Convert.ToInt32(dr["TAREA_IDTAREA"]);

                        }
                        else
                        {

                            tareid_tare = 0;
                        }
                        string procenom = dr["nombreproceso"].ToString();
                        int idproce = Convert.ToInt32(dr["IDPROCESO"]);

                        t.IdTarea = idtare;
                        t.tipoTarea = tipota;
                        t.nombreTa = nombre;
                        t.habilitado = habilitado;
                        t.descripcion = descr;
                        t.observacion = obser;
                        t.adjudicador = adju;
                        t.tar_idtar = tareid_tare;
                        t.proce_nomb = procenom;
                        t.idProce = idproce;
                        
                        listaTarea.Add(t);
                    }
                }
            }
            cnn.Dispose();
            return listaTarea;
        }



        public TareaN buscarTarea(int idtareaa, string rute)  
        {
            Conexion c = new Conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "SELECT t.idtarea,t.tipotarea,t.nombreta, t.DESCRIPCION, t.OBSERVACION, t.ADJUDICADOR, t.HABILITADO, t.TAREA_IDTAREA, p.nombreproceso FROM TAREA t join PROCESO p on(t.proceso_idproceso = p.IDPROCESO) WHERE idtarea ="+ idtareaa + "and adjudicador ='"+rute+"'";
            cmd.CommandType = CommandType.Text;
            TareaN t = new TareaN();
            using (DbDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        int tareid_tare;
                       

                        int idtare = Convert.ToInt32(dr["idtarea"]);
                        int tipota = Convert.ToInt32(dr["tipotarea"]);
                        string nombre = dr["nombreta"].ToString();
                        string habilitado = dr["HABILITADO"].ToString();
                        string descr = dr["DESCRIPCION"].ToString();
                        string obser = dr["OBSERVACION"].ToString();
                        string adju = dr["ADJUDICADOR"].ToString();

                        if (dr["TAREA_IDTAREA"] != DBNull.Value)
                        {
                            tareid_tare = Convert.ToInt32(dr["TAREA_IDTAREA"]);
                                                        
                        }
                        else
                        {

                            tareid_tare = 0;
                        }
                        string procenom = dr["nombreproceso"].ToString();

                        t.IdTarea = idtare;
                        t.tipoTarea = tipota;
                        t.nombreTa = nombre;
                        t.habilitado = habilitado;
                        t.descripcion = descr;
                        t.observacion = obser;
                        t.adjudicador = adju;
                        t.tar_idtar = tareid_tare;
                        t.proce_nomb = procenom;


                        ;
                    }
                }
            }
            cnn.Dispose();
            return t;
        }
        
        

        public List<TareaN> listartareaAso(string rute)
        {
            abrirConexion();
            try
            {
                OracleCommand cmd = new OracleCommand("PRO_BUSCAR_TARE_ASOS", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //cmd.Parameters.Add("P_RUT", OracleDbType.Varchar2).Value = "191105702";

                OracleParameter[] prm = new OracleParameter[2];
               // prm[0] = cmd.Parameters.Add("P_RUT", OracleDbType.Varchar2, ParameterDirection.Input);.Value = "191105702";

                List<TareaN> lista = new List<TareaN>();

                OracleParameter output = cmd.Parameters.Add("Ta_aso", OracleDbType.RefCursor);
                
                //cmd.Parameters.Add("P_RUT", OracleDbType.Varchar2).Value = "191105702";
                output.Direction = ParameterDirection.ReturnValue;
                //cmd.Parameters.Add("P_RUT", OracleDbType.Varchar2).Value = "191105702";

                cmd.ExecuteNonQuery();
                //cmd.Parameters.Add("P_RUT", OracleDbType.Varchar2).Value = "191105702";
                OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();

                while (reader.Read())
                {
                    TareaN nuevo = new TareaN();

                    nuevo.nombreTa = reader.GetString(0);
                    nuevo.habilitado = reader.GetString(1);
                    System.Diagnostics.Debug.WriteLine(nuevo.nombreTa);
                    System.Diagnostics.Debug.WriteLine("hola");
                    lista.Add(nuevo);

                }

                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }




        public void agregarTarea(TareaN nuevo)
        {
            TareaCRUD modelo = new TareaCRUD();
            modelo.agregarTarea(nuevo);
        }

        public void editarTarea(TareaN nuevo)
        {
            TareaCRUD modelo = new TareaCRUD();
            modelo.editarTarea(nuevo);
        }
        public void deshabilitarTarea(TareaN nuevo)
        {
            TareaCRUD modelo = new TareaCRUD();
            modelo.deshabilitarTarea(nuevo);
        }
        


    }
}