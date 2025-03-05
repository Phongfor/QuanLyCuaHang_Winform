using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyCuaHang
{
    public partial class DgrForm : Form
    {
        private ThongKeDoanhThu mainForm;
        public DgrForm(ThongKeDoanhThu form)
        {
            InitializeComponent();
            mainForm = form;
        }

        void loadData()
        {
            using (SqlConnection cnn = Connections.GetConnect())
            {
                string query = @"SELECT dh.[MaDonHang],[NgayDat],[Loai],[MaMon],[SoLuong],[Gia],[TongTien]
                                 FROM tblDonHang dh 
                                 INNER JOIN tblChiTietDonHang ctdh
                                 ON dh.MaDonHang = ctdh.MaDonHang";
                using (SqlDataAdapter da = new SqlDataAdapter(query,cnn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].HeaderText = "Mã hóa đơn";
                    dataGridView1.Columns[1].HeaderText = "Ngày";
                    dataGridView1.Columns[2].HeaderText = "Hình thức";
                    dataGridView1.Columns[3].HeaderText = "Mã món ăn";
                    dataGridView1.Columns[4].HeaderText = "Số lượng";
                    dataGridView1.Columns[5].HeaderText = "Giá";
                    dataGridView1.Columns[6].HeaderText = "Tổng tiền";
                    dataGridView1.ReadOnly = true;
                }
            }
        }



        private void DgrForm_Load(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
