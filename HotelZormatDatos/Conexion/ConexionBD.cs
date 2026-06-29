using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace HotelZormat.Datos.Conexion
{
   
    /// Punto único de conexión a la base de datos del hotel.
    /// El día 5 (semana 02) lo conectaremos a SQL Server.

    public static class ConexionBD
    {
        private static readonly string _cadena =
            "Data Source=.\\SQLEXPRESS;Initial Catalog=HotelZormatDB;Integrated Security=True;";

        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(_cadena);
        }


         
    }
}
