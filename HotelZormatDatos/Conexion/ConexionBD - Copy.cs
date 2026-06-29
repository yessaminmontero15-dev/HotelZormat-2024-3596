using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace HotelZormat.Datos
{
    public static class ConexionBD
    {
        public static string ObtenerConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["HotelZormatDB"].ConnectionString;
        }
    }
}