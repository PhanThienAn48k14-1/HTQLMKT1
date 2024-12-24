using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //Bước 0 
namespace HTQLMKT1
{
    public partial class DQLTK : Form
    {
        string sCon = "Data Source=YANG;Initial Catalog=HTQLYMKT;Persist Security Info=True;User ID=NhanVien;Password=nhom3@123;TrustServerCertificate=True";
        public DQLTK()
        {
            InitializeComponent();
        }

        private void DQLTK_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Chào bạn ");

        }

        private void btnXoaTK_Click(object sender, EventArgs e)
        {
            string maTK = txtDMaTK.Text.Trim();

            if (string.IsNullOrEmpty(maTK))
            {
                MessageBox.Show("Vui lòng nhập Mã TK để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(sCon))
                {
                    try
                    {
                        con.Open();
                        string sQuery = "DELETE FROM TaiKhoan WHERE MaTK = @MaTK";
                        SqlCommand cmd = new SqlCommand(sQuery, con);
                        cmd.Parameters.AddWithValue("@MaTK", maTK);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Xóa tài khoản thành công!");

                        // Làm mới dữ liệu trong DataGridView
                        LoadData();
                        ClearTextBoxes();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Xảy ra lỗi trong quá trình xóa!");
                    }
                }
            }

        }
        // Hàm làm mới dữ liệu trong DataGridView
        private void LoadData()
        {
            SqlConnection con = new SqlConnection(sCon);

            try
            {
                con.Open();
                string sQuery = "SELECT * FROM TaiKhoan";
                SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);

                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "TaiKhoan");

                dataGridView1.DataSource = dataSet.Tables["TaiKhoan"];
            }
            catch (Exception)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình lấy dữ liệu!");
            }
            finally
            {
                con.Close();
            }
        }

        private void btnHuyDQLTK_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void DQLTK_Load(object sender, EventArgs e)
        {
            // Load dữ liệu khi form được tải lên
            LoadData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                // Lấy dữ liệu từ dòng đã chọn trong DataGridView
                txtDMaTK.Text = dataGridView1.Rows[e.RowIndex].Cells["MaTK"].Value.ToString();
                txtDMaKH.Text = dataGridView1.Rows[e.RowIndex].Cells["MaKH"].Value.ToString();
                txtDTenDNKH.Text = dataGridView1.Rows[e.RowIndex].Cells["Tendangnhap"].Value.ToString();
                txtDMatKhau.Text = dataGridView1.Rows[e.RowIndex].Cells["Matkhau"].Value.ToString();
                txtDMaNV.Text = dataGridView1.Rows[e.RowIndex].Cells["Manv"].Value.ToString();

                // Disable chỉnh sửa Mã TK
                txtDMaTK.Enabled = false;
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string maTK = txtDMaTK.Text.Trim();

            if (string.IsNullOrEmpty(maTK))
            {
                MessageBox.Show("Vui lòng nhập Mã TK để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection con = new SqlConnection(sCon))
            {
                try
                {
                    con.Open();
                    string sQuery = "SELECT * FROM TaiKhoan WHERE MaTK = @MaTK";
                    SqlCommand cmd = new SqlCommand(sQuery, con);
                    cmd.Parameters.AddWithValue("@MaTK", maTK);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // Hiển thị thông tin vào các TextBox
                        txtDMaTK.Text = reader["MaTK"].ToString();
                        txtDTenDNKH.Text = reader["Tendangnhap"].ToString();
                        txtDMatKhau.Text = reader["Matkhau"].ToString();
                        txtDMaKH.Text = reader["MaKH"].ToString();
                        txtDMaNV.Text = reader["Manv"].ToString();

                        // Không cho phép chỉnh sửa Mã TK
                        txtDMaTK.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy tài khoản với Mã TK đã nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ClearTextBoxes();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Xảy ra lỗi trong quá trình tìm kiếm!");
                }
            }
        }
        // Hàm xóa nội dung các TextBox
        private void ClearTextBoxes()
        {
            txtDMaTK.Text = "";
            txtDTenDNKH.Text = "";
            txtDMatKhau.Text = "";
            txtDMaKH.Text = "";
            txtDMaNV.Text = "";

            // Bật lại chỉnh sửa Mã TK
            txtDMaTK.Enabled = true;
        }

    }

}

