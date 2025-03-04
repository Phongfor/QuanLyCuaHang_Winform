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
    public partial class QuanLyNhanVien : Form
    {
        public QuanLyNhanVien()
        {
            InitializeComponent();           
            this.WindowState = FormWindowState.Maximized;
            CenterPanel();
        }
        private void CenterPanel()
        {
            panel1.Left = (this.ClientSize.Width - panel1.Width);
            panel1.Top = (this.ClientSize.Height - panel1.Height);
            
        }
    }
}
