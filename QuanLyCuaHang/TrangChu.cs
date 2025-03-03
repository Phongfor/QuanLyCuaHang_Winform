using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace QuanLyCuaHang
{
    public partial class TrangChu : Form
    {
        private string userRole;
        bool sidebarExpand;
        bool MenuExpand1;
        bool MenuExpand2;
        private Button selectedButton = null;
        private string username;

        public TrangChu(string role, string user)
        {
            InitializeComponent();
            userRole = role;
            username = user;

        }
        //Kiểm tra quyền khi đăng nhập
        private void AccessControl()
        {
            if (userRole == "Nhân viên")
            {
                btnQLNV.Enabled = false;
                btnTK.Enabled = false;
                lbRole.Text = userRole;
            }
            else
            {
                lbRole.Text = userRole;
            }
        }
        //làm nổi bật màu cho nút được chọn
        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            // Nếu button đã chọn trước đó khác button vừa click, thì reset button cũ về màu gốc
            if (selectedButton != null && selectedButton != clickedButton)
            {
                selectedButton.BackColor = Color.FromArgb(64, 64, 64);

            }

            // Đổi màu button mới
            clickedButton.BackColor = Color.Black;
            selectedButton = clickedButton;
        }

        //Thêm các nút để thực hiện Button_Click
        private void AssignButtonEvents()
        {
            btnQLDH.Click += Button_Click;
            btnQLHH.Click += Button_Click;
            btnQLNV.Click += Button_Click;
            btnQLDDH.Click += Button_Click;
            btnQLKH.Click += Button_Click;
            btnQLLM.Click += Button_Click;
            btnQLMA.Click += Button_Click;
            btnTK.Click += Button_Click;
            btnTTCN.Click += Button_Click;
            btnQLGH.Click += Button_Click;
        }

        //Thêm form mới vào panelcontainer
        private void AddControlForm(Form form)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(form);
            form.Show();
        }


        //animation cho sibar
        private void SidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    SidebarTimer.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    SidebarTimer.Stop();
                }
            }
        }

        //animation cho Quản lý hàng hóa
        private void MenuTimer1_Tick(object sender, EventArgs e)
        {
            int step = 20;

            if (MenuExpand1)
            {
                flowLayoutPanel1.Height += step;
                if (flowLayoutPanel1.Height >= flowLayoutPanel1.MaximumSize.Height)
                {
                    flowLayoutPanel1.Height = flowLayoutPanel1.MaximumSize.Height;
                    MenuTimer1.Stop();
                }
            }
            else
            {
                flowLayoutPanel1.Height -= step;
                if (flowLayoutPanel1.Height <= flowLayoutPanel1.MinimumSize.Height)
                {
                    flowLayoutPanel1.Height = flowLayoutPanel1.MinimumSize.Height;
                    MenuTimer1.Stop();
                }
            }
        }

        //animation cho Quản lý đặt hàng
        private void MenuTimer2_Tick(object sender, EventArgs e)
        {
            int step = 20;

            if (MenuExpand2)
            {
                flowLayoutPanel2.Height += step;
                if (flowLayoutPanel2.Height >= flowLayoutPanel2.MaximumSize.Height)
                {
                    flowLayoutPanel2.Height = flowLayoutPanel2.MaximumSize.Height;
                    MenuTimer2.Stop();
                }
            }
            else
            {
                flowLayoutPanel2.Height -= step;
                if (flowLayoutPanel2.Height <= flowLayoutPanel2.MinimumSize.Height)
                {
                    flowLayoutPanel2.Height = flowLayoutPanel2.MinimumSize.Height;
                    MenuTimer2.Stop();
                }
            }
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            SidebarTimer.Start();

        }

        private void btnQLDH_Click(object sender, EventArgs e)
        {
            MenuExpand2 = !MenuExpand2;

            if (!MenuTimer2.Enabled)
            {
                MenuTimer2.Start();
            }

            if (pictureBox2.Image != null)
            {
                pictureBox2.BackColor = Color.Black;
                pictureBox2.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pictureBox2.Refresh();
            }
        }

        private void btnQLNV_Click(object sender, EventArgs e)
        {
            QuanLyNhanVien nhanVien = new QuanLyNhanVien();
            AddControlForm(nhanVien);
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();  // Đóng form TrangChu
            Application.Exit(); // Thoát toàn bộ ứng dụng
        }

        private void btnQLHH_Click(object sender, EventArgs e)
        {
            MenuExpand1 = !MenuExpand1;

            if (!MenuTimer1.Enabled)
            {
                MenuTimer1.Start();
            }

            if (pictureBox4.Image != null)
            {
                pictureBox4.BackColor = Color.Black;
                pictureBox4.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pictureBox4.Refresh();
            }
        }

        private void TrangChu_Load(object sender, EventArgs e)
        {
            AssignButtonEvents();
            AccessControl();
        }

        private void btnQLDH_Leave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.FromArgb(64, 64, 64);
        }

        private void btnQLHH_Leave(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.FromArgb(64, 64, 64);
        }

        private void btnQLDDH_Click(object sender, EventArgs e)
        {
            QuanLyDonDatHang QLDDH = new QuanLyDonDatHang();
            AddControlForm(QLDDH);
        }

        private void btnTTCN_Click(object sender, EventArgs e)
        {
            ThongTinCaNhan ttcn = new ThongTinCaNhan(username);
            AddControlForm(ttcn);
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            ThongKeDoanhThu tkdt = new ThongKeDoanhThu();
            AddControlForm(tkdt);
        }
    }
}
