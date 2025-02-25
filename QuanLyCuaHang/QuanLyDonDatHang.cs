using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHang
{
    public partial class QuanLyDonDatHang : Form
    {
        public QuanLyDonDatHang()
        {
            InitializeComponent();
            LoadMenu();
            lbCaPhe.Click += lblDanhMuc_Click;
            lbDoAnNhanh.Click += lblDanhMuc_Click;
            lbDoNgot.Click += lblDanhMuc_Click;
            lbNuocngot.Click += lblDanhMuc_Click;
            lbTraSua.Click += lblDanhMuc_Click;          
        }

        Modify modify = new Modify();
        private Label selectedLabel = null;
        private void HienThiMonTheoDanhMuc(String Danhmuc)
        {
            flpContainer.Controls.Clear(); // Xóa danh sách cũ

            // Truy vấn dữ liệu từ database theo danh mục
            string query = "SELECT MaMon, TenMon, Gia, MoTa FROM tblMonAn a join tblDanhMuc b on a.MaDanhMuc=b.MaDanhMuc WHERE b.TenDanhMuc = N'"+Danhmuc+"'";

            string defaultImagePath = @"D:\học kì 2 năm 2\C#\QuanLyCuaHang\QuanLyCuaHang_Winform\img_Icon\fast-food.jpg";
            try
            {
                using (SqlConnection cnn = Connections.GetConnect())
                {
                    cnn.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, cnn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        foreach (DataRow row in dt.Rows)
                        {
                            FoodItem monAn = new FoodItem();
                            monAn.TenMon = row["TenMon"].ToString();
                            monAn.Gia = Convert.ToDecimal(row["Gia"]);

                            // Lấy đường dẫn hình ảnh từ cột 'MoTa'
                            string imagePath = Path.Combine(@"D:\học kì 2 năm 2\C#\QuanLyCuaHang\QuanLyCuaHang_Winform\img_Icon", row["MoTa"].ToString());

                            if (!File.Exists(imagePath))
                            {
                                imagePath = defaultImagePath;
                            }

                            // Kiểm tra ảnh hợp lệ trước khi load
                            try
                            {
                                monAn.Anh = Image.FromFile(imagePath);
                            }
                            catch
                            {
                                monAn.Anh = Image.FromFile(defaultImagePath);
                            }

                            monAn.ItemClicked += (s, e) =>
                            {
                                ThemMonVaoHoaDon(monAn.TenMon, monAn.Gia);
                            };
                            flpContainer.Controls.Add(monAn);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải menu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Hàm lấy mã món từ tên món
        private int GetMaMon(string tenMon)
        {
            using (SqlConnection conn = Connections.GetConnect())
            {
                conn.Open();
                string query = "SELECT MaMon FROM tblMonAn WHERE TenMon = @TenMon";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenMon", tenMon);
                return (int)cmd.ExecuteScalar();
            }
        }
        private void TinhTongTien()
        {
            decimal tongTien = 0;
            decimal giamGia = 0;

            // Tính tổng tiền trước giảm giá
            foreach (DataGridViewRow row in dgHoaDon.Rows)
            {
                if (row.Cells["ThanhTien"].Value != null)
                {
                    tongTien += Convert.ToDecimal(row.Cells["ThanhTien"].Value);
                }
            }

            // Chuyển đổi giảm giá về số
            if (!string.IsNullOrEmpty(txtGiamGia.Text))
            {
                string giamGiaText = txtGiamGia.Text.Trim();
                decimal.TryParse(giamGiaText, out giamGia);
                giamGia /= 100; 
            }         
            decimal tongSauGiam = tongTien * (1 - giamGia);
            lbTongTien.Text = $"{tongSauGiam:N0}đ";
        }
        private void ThemMonVaoHoaDon(string tenMon, decimal gia)
        {
            foreach (DataGridViewRow row in dgHoaDon.Rows)
            {
                if (row.Cells["TenMon"].Value != null && row.Cells["TenMon"].Value.ToString() == tenMon)
                {
                    int soLuong = row.Cells["SoLuong"].Value != null ? Convert.ToInt32(row.Cells["SoLuong"].Value) : 0;
                    row.Cells["SoLuong"].Value = soLuong + 1;
                    row.Cells["ThanhTien"].Value = (soLuong + 1) * gia;
                    TinhTongTien();
                    return;
                }
            }
            // Nếu món chưa tồn tại, thêm mới vào hóa đơn
            dgHoaDon.Rows.Add(tenMon, 1, gia);
            TinhTongTien();
        }

        private void XoaMonAn()
        {
            dgHoaDon.CellClick += dgHoaDon_CellClick;
            if (dgHoaDon.SelectedRows.Count > 0) // Kiểm tra xem có dòng nào được chọn không
            {
                foreach (DataGridViewRow row in dgHoaDon.SelectedRows)
                {
                    if (!row.IsNewRow) // Không xóa hàng trống mặc định
                    {
                        dgHoaDon.Rows.Remove(row);
                    }
                }
                TinhTongTien(); // Cập nhật lại tổng tiền sau khi xóa
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một món để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadMenu()
        {
            string query = "SELECT MaMon, TenMon, Gia, MoTa FROM tblMonAn";
            flpContainer.Controls.Clear();
            string defaultImagePath = @"D:\học kì 2 năm 2\C#\QuanLyCuaHang\QuanLyCuaHang_Winform\img_Icon\fast-food.jpg";           
            try
            {
                using (SqlConnection cnn = Connections.GetConnect())
                {
                    cnn.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, cnn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        foreach (DataRow row in dt.Rows)
                        {
                            FoodItem monAn = new FoodItem();
                            monAn.TenMon = row["TenMon"].ToString();
                            monAn.Gia = Convert.ToDecimal(row["Gia"]);

                            // Lấy đường dẫn hình ảnh từ cột 'MoTa'
                            string imagePath = Path.Combine(@"D:\học kì 2 năm 2\C#\QuanLyCuaHang\QuanLyCuaHang_Winform\img_Icon", row["MoTa"].ToString());

                            if (!File.Exists(imagePath))
                            {
                                imagePath = defaultImagePath;
                            }

                            // Kiểm tra ảnh hợp lệ trước khi load
                            try
                            {
                                monAn.Anh = Image.FromFile(imagePath);
                            }
                            catch
                            {
                                monAn.Anh = Image.FromFile(defaultImagePath);
                            }

                            monAn.ItemClicked += (s, e) =>
                            {                            
                                ThemMonVaoHoaDon(monAn.TenMon, monAn.Gia);
                            };
                            flpContainer.Controls.Add(monAn);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải menu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Tìm kiếm Món
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            string searchText = txtSearch.Text.Trim().ToLower();

            foreach (Control control in flpContainer.Controls)
            {
                if (control is FoodItem item)
                {

                    if (item.TenMon.ToLower().Contains(searchText))
                    {
                        item.Visible = true;
                    }
                    else
                    {
                        item.Visible = false;
                    }
                }
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = Connections.GetConnect())
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    
                    decimal giamGia = 0;
                    if (!string.IsNullOrEmpty(txtGiamGia.Text))
                    {
                        string giamGiaText = txtGiamGia.Text.Replace("%", "").Trim();
                        decimal.TryParse(giamGiaText, out giamGia);
                    }

                
                    string tongTienText = lbTongTien.Text.Replace("đ", "").Replace(",", "").Trim();
                    decimal tongTien = 0;
                    if (!decimal.TryParse(tongTienText, out tongTien))
                    {
                        MessageBox.Show("Lỗi: Tổng tiền không hợp lệ!");
                        return;
                    }

                    // Thêm hóa đơn vào tblDonHang và lấy MaDonHang vừa tạo
                    string insertHoaDonQuery = @"INSERT INTO tblDonHang (MaNV, NgayDat, Loai, GiamGia, TongTien) 
                                         VALUES (@MaNV, @NgayDat, @Loai, @GiamGia, @TongTien);
                                         SELECT SCOPE_IDENTITY();"; // Lấy ID vừa tạo

                    SqlCommand cmd = new SqlCommand(insertHoaDonQuery, conn, transaction);
                    cmd.Parameters.AddWithValue("@MaNV", txtMaNV.Text);
                    cmd.Parameters.AddWithValue("@NgayDat", DateTime.Now);                   
                    cmd.Parameters.AddWithValue("@Loai", cmbLoai.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@GiamGia", giamGia);
                    cmd.Parameters.AddWithValue("@TongTien", tongTien);

                    int maDonHang = Convert.ToInt32(cmd.ExecuteScalar()); // Lấy MaDonHang mới

                    // Thêm từng món vào tblChiTietDonHang
                    foreach (DataGridViewRow row in dgHoaDon.Rows)
                    {
                        if (row.Cells["TenMon"].Value == null) continue;

                        string insertChiTietQuery = "INSERT INTO tblChiTietDonHang (MaDonHang, MaMon, SoLuong, Gia) " +
                                                    "VALUES (@MaDonHang, @MaMon, @SoLuong, @Gia)";

                        SqlCommand cmdChiTiet = new SqlCommand(insertChiTietQuery, conn, transaction);
                        cmdChiTiet.Parameters.AddWithValue("@MaDonHang", maDonHang);
                        cmdChiTiet.Parameters.AddWithValue("@MaMon", GetMaMon(row.Cells["TenMon"].Value.ToString()));
                        cmdChiTiet.Parameters.AddWithValue("@SoLuong", Convert.ToInt32(row.Cells["SoLuong"].Value));
                        cmdChiTiet.Parameters.AddWithValue("@Gia", Convert.ToDecimal(row.Cells["ThanhTien"].Value));

                        cmdChiTiet.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("Thanh toán thành công!");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            XoaMonAn();
        }
        private void dgHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                dgHoaDon.Rows[e.RowIndex].Selected = true;
            }
        }

        //Gắn sự kiện click vào label danh mục
        private void lblDanhMuc_Click(object sender, EventArgs e)
        {
            lbTatca.ForeColor = Color.White;
            Label clickedLabel = sender as Label;
            if (clickedLabel != null)
            {              
                if (selectedLabel != null)
                {
                    selectedLabel.ForeColor = Color.White;
                }              
                clickedLabel.ForeColor = Color.Red; // Đổi sang màu đỏ hoặc màu bạn muốn             
                selectedLabel = clickedLabel;
                // Hiển thị món theo danh mục
                string danhMuc = clickedLabel.Text;
                HienThiMonTheoDanhMuc(danhMuc);
            }
        }
        private void txtSearch_Click(object sender, EventArgs e)
        {
            LoadMenu();
        }

        private void lbTatca_Click(object sender, EventArgs e)
        {
            lbTatca.ForeColor = Color.Red;
            lbCaPhe.ForeColor = Color.White;
            lbDoAnNhanh.ForeColor = Color.White;
            lbDoNgot.ForeColor = Color.White;
            lbNuocngot.ForeColor = Color.White;
            lbTraSua.ForeColor = Color.White;
            LoadMenu();          
        }
        private void btnXoa_MouseEnter(object sender, EventArgs e)
        {
            btnXoa.BackColor = Color.White;
            btnXoa.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void btnXoa_MouseLeave(object sender, EventArgs e)
        {
            btnXoa.BackColor = Color.FromArgb(64, 64, 64);
            btnXoa.ForeColor = Color.White;
        }

        private void btnThanhToan_MouseEnter(object sender, EventArgs e)
        {
            btnThanhToan.BackColor = Color.White;
            btnThanhToan.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void btnThanhToan_MouseLeave(object sender, EventArgs e)
        {
            btnThanhToan.BackColor = Color.FromArgb(64, 64, 64);
            btnThanhToan.ForeColor = Color.White;
        }

        private void txtGiamGia_KeyUp(object sender, KeyEventArgs e)
        {
            TinhTongTien();
        }
    }
}