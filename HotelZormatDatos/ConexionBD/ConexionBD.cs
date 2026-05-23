using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace HotelZormatDatos
{
    public static class ConexionBD
    {

        private static readonly string _cadena =
        "Data Source=.;Initial Catalog=HotelZormatDB;Integrated Segurity=True";";
        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(_cadena);
        }
    }
    
    
}
