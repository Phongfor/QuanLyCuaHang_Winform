using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHang
{

    internal static class Connections
    {
        private static string strcon = "Data Source=DESKTOP-0RA74SJ\\SQLEXPRESS;Initial Catalog=QuanLyCuaHang;Integrated Security=True";

        public static SqlConnection GetConnect()
        {           
            return new SqlConnection(strcon);
        }
    }
}
