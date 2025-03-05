using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyCuaHang
{
    public partial class ThongKeDoanhThu : Form
    {
        private ChartForm chartForm;
        private DgrForm dgrForm;
        public ThongKeDoanhThu()
        {
            InitializeComponent();
            chartForm = new ChartForm(this);
            dgrForm = new DgrForm(this);
        }

        private void ThongKeDoanhThu_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Gray, 1);
            g.DrawLine(pen, 0, 27, 1250, 27);
            g.DrawLine(pen, 0, 102, 1250, 102);
        }

        private void ThongKeDoanhThu_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            AddControlForm(chartForm);
            DateTime fromDate = DateTime.Now.AddDays(-30);
            DateTime toDate = DateTime.Now;
            chartForm.SetupChart(fromDate, toDate);
            this.AutoScaleMode = AutoScaleMode.Dpi;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dateTimePicker1.Value;
            DateTime toDate = dateTimePicker2.Value;
            chartForm.SetupChart(fromDate, toDate);
        }

        private void AddControlForm(Form form)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(form);
            form.Show();
        }

        public string GetSelectedFilter()
        {
            return comboBox1.SelectedItem?.ToString() ?? "Báo cáo theo ngày"; 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddControlForm(dgrForm);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddControlForm(chartForm);
        }

    }
}