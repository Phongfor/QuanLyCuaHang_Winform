using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHang
{
    public partial class LoginForm : Form
    {
       
        public LoginForm()
        {
            InitializeComponent();
        }

        Modify modify = new Modify();
    
        private void textBox1_Click(object sender, EventArgs e)
        {
            txtLoginUser.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string User = txtLoginUser.Text;
            string Pass = txtLoginPass.Text;

            if (User.Trim() != "" && Pass.Trim() != " ")
            {
                string query = "select * from tblNhanVien where TaiKhoan ='" + User + "'and MatKhau ='" + Pass + "'";
                List<Taikhoan> Account = modify.Taikhoans(query);
                if (Account.Count > 0)
                {
                    string role = Account[0].Role;                 
                    TrangChu trangChu = new TrangChu(role);
                    this.Hide();
                    trangChu.ShowDialog();
                    this.Close();
                }
                else
                {
                    label3.Text = label4.Text = "Tài khoản hoặc mật khẩu sai!";
                    label3.Visible = label4.Visible = true;
                }
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            txtLoginPass.Clear();
            txtLoginPass.PasswordChar= '*';
        }

        private void txtLoginUser_Leave(object sender, EventArgs e)
        {
            string User = txtLoginUser.Text;
            if (User.Trim() == "")
            {
                label3.Visible = true;
            }
            else
            {
                label3.Visible = false;
            }
        }

        private void txtLoginPass_Leave(object sender, EventArgs e)
        {
            string Pass = txtLoginPass.Text;
            if (Pass.Trim() == "")
            {
                label4.Visible = true;
            }
            else
            {
                label4.Visible = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtLoginPass.PasswordChar = '\0';
            }
            else
            {
                txtLoginPass.PasswordChar = '*';
            }
        }

        private void btnLogin_MouseHover(object sender, EventArgs e)
        {
            btnLogin.ForeColor = Color.White;
            btnLogin.BackColor = Color.Black;
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.ForeColor = Color.Black;
            btnLogin.BackColor = Color.White;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            ForgotPass forgotPass = new ForgotPass();
            forgotPass.ShowDialog();
            this.Close();
        }
    }
}
