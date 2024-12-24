using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //khai báo thư viện

namespace HTQLMKT1
{
    public partial class RQLHD : Form
    {
        // gán link database vào
        public RQLHD()
        {
            InitializeComponent();
        }

        private void btnXEM_Click(object sender, EventArgs e)
        {

            
            }

        private void RQLHD_Load(object sender, EventArgs e)
        {
            //// Chuỗi kết nối (thay thế bằng chuỗi kết nối của bạn)
            //string connectionString = "Data Source=DESKTOP-74S139L;Initial Catalog = HTQLYMKT1; Integrated Security = True;";


            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    string sQuery = "SELECT * FROM HopDong ";
            //    SqlCommand command = new SqlCommand(sQuery, connection);

            //    // Khai báo tham số trước khi thực thi


            //    try
            //    {
            //        connection.Open();
            //        SqlDataAdapter adapter = new SqlDataAdapter(command);
            //        DataSet ds = new DataSet();
            //        adapter.Fill(ds, "HopDong");
            //        dataGridView1.DataSource = ds.Tables["HopDong"];
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Xảy ra lỗi trong quá trình kết nối DB: " + ex.Message);
            //    }
            //    connection.Close();
            }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string SMAHD = txtMAHDKH.Text;


            // Chuỗi kết nối (thay thế bằng chuỗi kết nối của bạn)
            string connectionString = "Data Source=DESKTOP-74S139L;Initial Catalog = HTQLYMKT1; Integrated Security = True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sQuery = "SELECT * FROM HopDong WHERE MAHD=@MaHD";
                SqlCommand command = new SqlCommand(sQuery, connection);

                // Khai báo tham số trước khi thực thi
                command.Parameters.AddWithValue("@MaHD", SMAHD);

                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "HopDong");
                    dataGridView1.DataSource = ds.Tables["HopDong"];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xảy ra lỗi trong quá trình kết nối DB: " + ex.Message);
                }
                connection.Close();
            }
        }

        private void BTNQL_Click(object sender, EventArgs e)
        {
            var XemTTHD = new KhachHang(); // Truyền tên đăng nhập
            XemTTHD.Show();
            this.Hide();
        }
    }
}
