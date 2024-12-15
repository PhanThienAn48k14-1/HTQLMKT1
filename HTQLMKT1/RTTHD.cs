using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTQLMKT1
{
    public partial class RTTHD : Form
    {
        public RTTHD()
        {
            InitializeComponent();
        }

        private void btnXemMAHDKH_Click(object sender, EventArgs e)
        {
            string SMAHD = txtMAHDKH.Text;


            // Chuỗi kết nối (thay thế bằng chuỗi kết nối của bạn)
            string connectionString = "Data Source=DESKTOP-74S139L;Initial Catalog=HTQLYMKT;Integrated Security=True";


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
    }
}
