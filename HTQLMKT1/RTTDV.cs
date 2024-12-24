using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HTQLMKT1
{
    public partial class RTTDV : Form
    {
        private string username;

        public RTTDV(string sTenDN)
        {
            InitializeComponent();
            username = sTenDN; // Nhận tên đăng nhập từ form trước đó
        }

        private void RTTDV_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string connectionString = "Data Source=DESKTOP-74S139L;Initial Catalog=HTQLYMKT1;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sQuery = @"
                    declare @makh varchar(10)
                    select @makh=makh
                    from TaiKhoan
                    WHERE TENDANGNHAP=@tendn
                    declare @madv varchar(10)
                    select DICHVUMKT.MADVMKT,TENDV,CHIPHI
                    from HopDong join DICHVUMKT on HopDong.MADVMKT=DICHVUMKT.MADVMKT
                    where MAKH=@makh";
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

        private void button1_Click(object sender, EventArgs e)
        {
            var khachHangForm = new KhachHang(username); // Quay lại form Khách Hàng
            khachHangForm.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thêm logic xử lý khi một cell trong DataGridView được nhấn
        }
    }

}
