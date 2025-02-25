using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHang
{

    internal class Modify
    {
        SqlCommand sqlCommand;
        SqlDataReader DataReader;

        public Modify()
        {
            
        }

        public List<Taikhoan> Taikhoans(string query)
        {
            List<Taikhoan> TaiKhoans = new List<Taikhoan>();
            using(SqlConnection cnn = Connections.GetConnect())
            {
                cnn.Open();
                sqlCommand = new SqlCommand(query,cnn);
                DataReader = sqlCommand.ExecuteReader();
                while(DataReader.Read())
                {
                    TaiKhoans.Add(new Taikhoan(DataReader.GetString(4), DataReader.GetString(5), DataReader.GetString(6)));
                }
                cnn.Close();
            }
            return TaiKhoans;
        }

        public List<MenuItem> GetMenuItems(string query)
        {
            List<MenuItem> menuItems = new List<MenuItem>();

            using (SqlConnection cnn = Connections.GetConnect())
            {
                cnn.Open();
                sqlCommand = new SqlCommand(query, cnn);
                DataReader = sqlCommand.ExecuteReader();

                while (DataReader.Read())
                {
                    string name = DataReader["TenMon"].ToString();
                    decimal price = Convert.ToDecimal(DataReader["Gia"]);
                    string imagePath = DataReader["MoTa"].ToString(); // Giả sử MoTa chứa tên ảnh

                    menuItems.Add(new MenuItem(name, price, imagePath));
                }
            }

            return menuItems;
        }
    }   
}
