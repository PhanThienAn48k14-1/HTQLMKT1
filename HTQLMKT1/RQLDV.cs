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
    public partial class RQLDV : Form
    {
        string sCon = "Data Source=DESKTOP-74S139L;Initial Catalog = HTQLYMKT1; Integrated Security = True;";
        public RQLDV()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {}

        private void btnTim_Click(object sender, EventArgs e)
        {
            // Lấy phần số của mã dịch vụ từ TextBox
            /*string soMaDV = txtMaDV.Text.Trim();

            if (string.IsNullOrEmpty(soMaDV))
            {
                MessageBox.Show("Vui lòng nhập số mã dịch vụ để tìm kiếm!");
                return;
            }

            // Ghép phần số vào chuỗi "DV"
            string fullMaDV = "DV" + soMaDV;

            SqlConnection con = new SqlConnection(sCon);*/

            string MaDV = txtMaDV.Text.Trim();

            if (string.IsNullOrEmpty(MaDV))
            {
                MessageBox.Show("Vui lòng nhập mã dịch vụ để tìm kiếm!");
                return;
            }

            // Kiểm tra nếu mã dịch vụ chưa có tiền tố "DV"
            if (!MaDV.StartsWith("DV"))
            {
                MaDV = "DV" + MaDV;
            }

            SqlConnection con = new SqlConnection(sCon);

            try
            {
                con.Open();

                // Truy vấn thông tin dịch vụ dựa trên mã dịch vụ
                string sQuery = "SELECT TENDV, CHIPHI FROM DICHVUMKT WHERE MADVMKT = @MaDV";
                SqlCommand cmd = new SqlCommand(sQuery, con);
                cmd.Parameters.AddWithValue("@MaDV", MaDV);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    // Hiển thị kết quả vào DataGridView
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy dịch vụ với mã: " + MaDV);
                    dataGridView1.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình tìm kiếm: " + ex.Message);
            }

            con.Close();
            
        }

        private void RQLDV_Load(object sender, EventArgs e)
        {
            // Đặt cấu hình DataGridView khi Form load
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Form dNhanVien = Application.OpenForms.OfType<NhanVien>().FirstOrDefault();
            if (dNhanVien != null)
            {
                dNhanVien.Show();
            }
            else
            {
                dNhanVien = new NhanVien();
                dNhanVien.Show();
            }
            this.Hide();
        }
    }
}
