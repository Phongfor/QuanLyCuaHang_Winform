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
    public partial class FoodItem : UserControl
    {
        public event EventHandler ItemClicked; // Sự kiện khi món ăn được click
    
        private decimal gia;
        public FoodItem()
        {
            InitializeComponent();                     
            this.Click += FoodItem_Click;
            lblTenMon.Click += FoodItem_Click;
            lbGia.Click += FoodItem_Click;
            pbImg.Click += FoodItem_Click;      
        }

        public string TenMon
        {
            get { return lblTenMon.Text; }
            set { lblTenMon.Text = value; }
        }

        public decimal Gia
        {
            get { return gia; }
            set
            {
                gia = value;
                lbGia.Text = $"{value:N0}đ"; // Format khi hiển thị
            }
        }

        public Image Anh
        {
            get { return pbImg.Image; }
            set { pbImg.Image = value; }
        }
        private void FoodItem_Click(object sender, EventArgs e)
        {
            ItemClicked?.Invoke(this, EventArgs.Empty); // Gọi sự kiện khi click vào món ăn
        }

    }
}
