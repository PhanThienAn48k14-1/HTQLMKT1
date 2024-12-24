using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;//Bước 0 

namespace HTQLMKT1
{
    public partial class UQLTK : Form
    {
        string sCon = "Data Source=YANG;Initial Catalog=HTQLYMKT;Persist Security Info=True;User ID=NhanVien;Password=nhom3@123;TrustServerCertificate=True";
        public UQLTK()
        {
            InitializeComponent();
        }

        private void btnUHuy_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn chắc chắn thoát ?");
        }

        private void btnUSua_Click(object sender, EventArgs e)
        {
            string maTK = txtUMaTK.Text.Trim();
            string tenDN = txtUTenDNKH.Text.Trim();
            string matKhau = txtUMatKhau.Text.Trim();

            if (string.IsNullOrEmpty(maTK) || string.IsNullOrEmpty(tenDN) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cập nhật thông tin vào bảng TaiKhoan
            using (SqlConnection con = new SqlConnection(sCon))
            {
                try
                {
                    con.Open();
                    string sQuery = "UPDATE TaiKhoan SET Tendangnhap = @Tendangnhap, MatKhau = @Matkhau WHERE MaTK = @MaTK";
                    SqlCommand cmd = new SqlCommand(sQuery, con);

                    cmd.Parameters.AddWithValue("@MaTK", maTK);
                    cmd.Parameters.AddWithValue("@Tendangnhap", tenDN);
                    cmd.Parameters.AddWithValue("@Matkhau", matKhau);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Cập nhật thành công!");

                    // Làm mới dữ liệu trong DataGridView
                    LoadData();
                }
                catch (Exception)
                {
                    MessageBox.Show("Xảy ra lỗi trong quá trình cập nhật!");
                }
            }
        }

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


        private void UQLTK_Load(object sender, EventArgs e)
        {
            // Load dữ liệu khi form được tải lên
            LoadData();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {// Kiểm tra nếu người dùng click vào dòng hợp lệ
            if (e.RowIndex >= 0)
            {
                // Lấy tất cả giá trị của các cột vào text box
                txtUMaTK.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtUTenDNKH.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtUMatKhau.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtUMaKH.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtUMaNV.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

                // Tắt chỉnh sửa trên Mã TK
                txtUMaTK.Enabled = false;
            }

            // Khóa các TextBox không cho phép chỉnh sửa

            txtUMaKH.Enabled = false;  // Mã KH không cho sửa
            txtUMaNV.Enabled = false;  // Mã NV không cho sửa

            // Cho phép chỉnh sửa Tên Đăng Nhập và Mật Khẩu
            txtUTenDNKH.Enabled = true;  // Cho phép sửa tên đăng nhập
            txtUMatKhau.Enabled = true;  // Cho phép sửa mật khẩu
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string maTK = txtUMaTK.Text.Trim();

            if (string.IsNullOrEmpty(maTK))
            {
                MessageBox.Show("Vui lòng nhập Mã TK để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy thông tin tài khoản dựa trên Mã TK
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
                        txtUMaTK.Text = reader["MaTK"].ToString();
                        txtUTenDNKH.Text = reader["TENDANGNHAP"].ToString();
                        txtUMatKhau.Text = reader["Matkhau"].ToString();
                        txtUMaKH.Text = reader["MaKH"].ToString();
                        txtUMaNV.Text = reader["Manv"].ToString();

                        // Không cho phép sửa Mã TK, Mã KH và Mã NV
                        txtUMaTK.Enabled = false;
                        txtUMaKH.Enabled = false;
                        txtUMaNV.Enabled = false;

                        // Chỉ cho phép chỉnh sửa Tên Đăng Nhập và Mật Khẩu
                        txtUTenDNKH.Enabled = true;
                        txtUMatKhau.Enabled = true;
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
        // Xóa nội dung các TextBox
        private void ClearTextBoxes()
        {
            txtUMaTK.Text = "";
            txtUTenDNKH.Text = "";
            txtUMatKhau.Text = "";
            txtUMaKH.Text = "";
            txtUMaNV.Text = "";

            // Bật cho phép nhập Mã TK lại
            txtUMaTK.Enabled = true;

            // Tắt chỉnh sửa Tên Đăng Nhập và Mật Khẩu
            txtUTenDNKH.Enabled = false;
            txtUMatKhau.Enabled = false;
        }

    }
}

