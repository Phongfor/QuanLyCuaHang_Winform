using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        
        //Hàm thêm
        public bool AddMenuItem(Dictionary<string, object> data, string tableName)
        {
            if (data == null || data.Count == 0)
            {
                MessageBox.Show("Dữ liệu không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            using (SqlConnection cnn = Connections.GetConnect())
            {
                cnn.Open();



                // Tạo danh sách cột và giá trị động
                string columns = string.Join(", ", data.Keys);
                string parameters = string.Join(", ", data.Keys.Select(k => "@" + k));

                string query = $"INSERT INTO {tableName} ({columns}) VALUES ({parameters})";

                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    foreach (var item in data)
                    {
                        cmd.Parameters.AddWithValue("@" + item.Key, item.Value ?? DBNull.Value);
                    }

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; // Trả về `true` nếu thêm thành công
                }


            }
        }

        //Hàm load data gridview
        public void loadDatagrv(string tablename, DataGridView dgr)
        {
            using (SqlConnection cnn = Connections.GetConnect())
            {
                string query = $"select * from {tablename}";
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgr.DataSource = dt;
                        dgr.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
            }
        }


        //Hàm xóa theo id
        public bool DeleteID(string tablename, string columname, int recordID)
        {
            try
            {
                using (SqlConnection cnn = Connections.GetConnect())
                {
                    cnn.Open();
                    string query = $"DELETE FROM {tablename} WHERE {columname} = @RecordId";

                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@RecordId", recordID); // Sử dụng AddWithValue()

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi SQL khi xóa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi không xác định: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        //Hàm sửa
        public bool UpdateItem(string tableName, Dictionary<string, object> data, string conditionColumn, object conditionValue)
        {
            if (data == null || data.Count == 0 || string.IsNullOrEmpty(conditionColumn))
            {
                return false; // Không có dữ liệu để cập nhật
            }

            try
            {
                using (SqlConnection cnn = Connections.GetConnect())
                {
                    cnn.Open();

                    // Tạo danh sách các cặp "cột = @thamso"
                    string setClause = string.Join(", ", data.Keys.Select(k => $"{k} = @{k}"));

                    string query = $"UPDATE {tableName} SET {setClause} WHERE {conditionColumn} = @ConditionValue";

                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        // Thêm các tham số của cột cập nhật
                        foreach (var item in data)
                        {
                            cmd.Parameters.AddWithValue("@" + item.Key, item.Value ?? DBNull.Value);
                        }

                        // Thêm điều kiện WHERE
                        cmd.Parameters.AddWithValue("@ConditionValue", conditionValue ?? DBNull.Value);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0; // Trả về true nếu có ít nhất một dòng được cập nhật
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

    }   
}
