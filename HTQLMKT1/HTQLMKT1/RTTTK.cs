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
    public partial class RTTTK : Form
    {
        string sCon = "Data Source=DESKTOP-74S139L;Initial Catalog=HTQLYMKT;Intergrated Security=True";
        public RTTTK()
        {
            InitializeComponent();
        }

        private void RTTTK_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Hãy nhập mã tài khoản của quý khách!");
            //Bước 1
            SqlConnection con = new SqlConnection(sCon);

            try
            {
                con.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình kết nối DB");
            }
            //Bước 2 - Lấy dữ liệu về 
            string sQuery = "select * from TaiKhoan";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);

            DataSet dataSet = new DataSet();

            adapter.Fill(dataSet, "TaiKhoan");

            dataGridView1.DataSource = dataSet.Tables["TaiKhoan"];

            con.Close(); //Bước 3 
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaTK.Text = dataGridView1.Rows[e.RowIndex].Cells["MaTK"].Value.ToString();
            txtMaKH.Text = dataGridView1.Rows[e.RowIndex].Cells["MaKH"].Value.ToString();
            txtTenDNKH.Text = dataGridView1.Rows[e.RowIndex].Cells["Tendangnhap"].Value.ToString();
            txtMatKhau.Text = dataGridView1.Rows[e.RowIndex].Cells["Matkhau"].Value.ToString();
            txtMaNV.Text = dataGridView1.Rows[e.RowIndex].Cells["Manv"].Value.ToString();
            txtMaTK.Enabled = false;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            string accountId = txtMaTK.Text.Trim();

            if (string.IsNullOrEmpty(accountId))
            {
                MessageBox.Show("Vui lòng nhập Mã Tài Khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FilterAccountByID(accountId);
        }

        private void FilterAccountByID(string accountId)
        {
            string connectionString = "Data Source=DESKTOP-74S139L;Initial Catalog=HTQLYMKT;Intergrated Security=True";
            string query = "SELECT MaTK, MaKH, TenDangnhap ,MATKHAU , MANV FROM TaiKhoan WHERE MaTK = @MaTK";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@AccountID", accountId);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dataTable;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView1.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" Bạn chắc chắn không xem?");
        }
    }
}
