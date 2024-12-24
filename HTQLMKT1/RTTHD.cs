using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HTQLMKT1
{
    public partial class RTTHD : Form
    {
        private string username;

        public RTTHD(string sTenDN)
        {
            InitializeComponent();
            username = sTenDN; // Nhận tên đăng nhập từ form trước đó
        }

        private void RTTHD_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string connectionString = "Data Source=DESKTOP-74S139L;Initial Catalog=HTQLYMKT1;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sQuery = @"
                    DECLARE @makh VARCHAR(10);
                    SELECT @makh = makh
                    FROM TaiKhoan
                    WHERE TENDANGNHAP = @tendn;

                    SELECT * 
                    FROM HopDong
                    WHERE MAKH = @makh;";

                SqlCommand command = new SqlCommand(sQuery, connection);
                command.Parameters.AddWithValue("@tendn", username);

                try
                {
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "HopDong");

                    if (ds.Tables["HopDong"].Rows.Count > 0)
                    {
                        dataGridView1.DataSource = ds.Tables["HopDong"];
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy hợp đồng nào cho tên đăng nhập này.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xảy ra trong quá trình truy vấn:\n" + ex.Message);
                }
            }
        }

        private void btnQL_Click(object sender, EventArgs e)
        {
            var khachHangForm = new KhachHang(username); // Quay lại form Khách Hàng
            khachHangForm.Show();
            this.Hide();
        }
    }
}
