using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;

namespace WebService_sct.Data
{
    public class Conexion
    {
        private OracleConnection cn { get; set; }
        public OracleConnection conectar()
        {
            if (cn==null)
            {
                string connString = "Data source=localhost;User Id=duoc4;Password=duoc4;";
                cn = new OracleConnection(connString);
            }
            return cn;
        }
    }
}