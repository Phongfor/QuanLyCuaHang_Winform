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
    public partial class ForgotPass : Form
    {
        public ForgotPass()
        {
            InitializeComponent();
        }     

        Modify modify = new Modify();        
        private void button1_Click(object sender, EventArgs e)
        {
            string MaNV = textBox1.Text;
            string SDT = textBox2.Text;
            if (MaNV.Trim() != " " && SDT.Trim() !=" " )
            {
                string query = "select * from tblNhanVien where MaNV ='"+MaNV+"' and SDTNV ='"+SDT+"'";
                if (modify.Taikhoans(query).Count > 0)
                {
                    label5.Visible = true;
                    label5.Text = modify.Taikhoans(query)[0].Password;
                }
                else
                {
                    MessageBox.Show("Thông tin sai! Vui lòng kiểm tra lại!");
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            this.Close();
        }
    }
}
