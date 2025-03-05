using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;

namespace QuanLyCuaHang
{
    public partial class ChartForm : Form
    {
        private ThongKeDoanhThu mainForm; 

        public ChartForm(ThongKeDoanhThu form)
        {
            InitializeComponent();
            mainForm = form;
        }

        private string GetQuery(string filterType)
        {
            switch (filterType)
            {
                case "Báo cáo theo ngày":
                    return @"
                        SELECT CONVERT(VARCHAR, NgayThanhToan, 103) AS ThoiGian, SUM(TongTien) AS DoanhThu 
                        FROM tblDonHang 
                        WHERE NgayThanhToan BETWEEN @FromDate AND @ToDate
                        GROUP BY NgayThanhToan 
                        ORDER BY NgayThanhToan";
                case "Báo cáo theo tháng":
                    return @"
                        SELECT FORMAT(NgayThanhToan, 'yyyy-MM') AS ThoiGian, SUM(TongTien) AS DoanhThu 
                        FROM tblDonHang 
                        WHERE NgayThanhToan BETWEEN @FromDate AND @ToDate
                        GROUP BY FORMAT(NgayThanhToan, 'yyyy-MM') 
                        ORDER BY FORMAT(NgayThanhToan, 'yyyy-MM')";
                case "Báo cáo theo năm":
                    return @"
                        SELECT YEAR(NgayThanhToan) AS ThoiGian, SUM(TongTien) AS DoanhThu 
                        FROM tblDonHang 
                        WHERE NgayThanhToan BETWEEN @FromDate AND @ToDate
                        GROUP BY YEAR(NgayThanhToan) 
                        ORDER BY YEAR(NgayThanhToan)";
                default:
                    return string.Empty;
            }
        }

        public void SetupChart(DateTime fromDate, DateTime toDate)
        {
            chart1.Series.Clear();
            chart1.Titles.Clear();

            Series series = new Series("Doanh Thu")
            {
                ChartType = SeriesChartType.Column
            };

            string filterType = mainForm.GetSelectedFilter();
            string query = GetQuery(filterType);

            try
            {
                using (SqlConnection connection = Connections.GetConnect())
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@FromDate", fromDate);
                        cmd.Parameters.AddWithValue("@ToDate", toDate);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string thoiGian = reader["ThoiGian"]?.ToString() ?? "N/A";
                                double doanhThu = reader["DoanhThu"] != DBNull.Value
                                    ? Convert.ToDouble(reader["DoanhThu"]) / 1000000  
                                    : 0.0;

                                series.Points.AddXY(thoiGian, doanhThu);
                            }
                        }
                    }
                }

                chart1.ChartAreas[0].AxisY.LabelStyle.Format = "#,##0M";
                series.Label = "#VALY{#,##0.00}";

                // Thêm dữ liệu vào Chart
                chart1.Series.Add(series);
                chart1.Titles.Add("Biểu đồ thống kê doanh thu");
                chart1.Titles[0].Font = new Font("Arial", 10, FontStyle.Regular);
                Console.WriteLine("Biểu đồ đã được cập nhật thành công.");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy dữ liệu: " + ex.Message);
            }
        }

    }
}
