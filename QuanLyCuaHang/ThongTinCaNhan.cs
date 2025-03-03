using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyCuaHang
{
    public partial class ThongTinCaNhan : Form
    {
        private string username;
        public ThongTinCaNhan(string user)
        {
            InitializeComponent();
            username = user;
        }

        public void LoadTTCaNhan(string user)
        {
            using (SqlConnection connection = Connections.GetConnect())
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM tblNhanVien WHERE TaiKhoan = @TaiKhoan";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TaiKhoan", user);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        txtMaNV.Text = reader["MaNV"].ToString();
                        txtTenNV.Text = reader["TenNV"].ToString();
                        txtSDTNV.Text = reader["SDT"].ToString();
                        txtNgayVaoLam.Text = Convert.ToDateTime(reader["NgayVaoLam"]).ToString("dd/MM/yyyy");
                        txtTaiKhoan.Text = reader["TaiKhoan"].ToString();
                        txtMatKhau.Text = reader["MatKhau"].ToString();
                        txtPhanQuyen.Text = reader["PhanQuyen"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin nhân viên!");
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải thông tin: " + ex.Message);
                }
            }
        }

        private void ThongTinCaNhan_Load(object sender, EventArgs e)
        {
            LoadTTCaNhan(username);
        }
    }
}


