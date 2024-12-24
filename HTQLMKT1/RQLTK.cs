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
    public partial class RQLTK : Form
    {
        string sCon = "Data Source=YANG;Initial Catalog=HTQLYMKT;Persist Security Info=True;User ID=NhanVien;Password=nhom3@123;TrustServerCertificate=True";

        public RQLTK()
        {
            InitializeComponent();
        }

        private void btnRHuy_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chào bạn, Bạn không muốn xem nữa ư ?");
        }

        private void RQLTK_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Chào bạn !");
        }

        private void RQLTK_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn hãy nhập mã tài khoản muốn xem nhé !");
        }

        private void btnRXem_Click(object sender, EventArgs e)
        {
            string accountId = txtRMaTK.Text.Trim(); // Lấy mã tài khoản từ TextBox

            // Kiểm tra nếu mã tài khoản trống
            if (string.IsNullOrEmpty(accountId))
            {
                MessageBox.Show("Vui lòng nhập Mã Tài Khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gọi phương thức để tải thông tin tài khoản
            LoadAccountDetails(accountId);
        }

        // Phương thức tải thông tin tài khoản từ cơ sở dữ liệu
        private void LoadAccountDetails(string accountId)
        {
            // Bước 1: Mở kết nối đến cơ sở dữ liệu
            SqlConnection con = new SqlConnection(sCon);

            try
            {
                con.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình kết nối DB");
                return;
            }

            // Bước 2: Câu lệnh truy vấn SQL để lấy thông tin tài khoản
            string sQuery = "SELECT MaTK, MaKH, TENDANGNHAP, Matkhau, Manv FROM TaiKhoan WHERE MaTK = @MaTK";
            SqlCommand command = new SqlCommand(sQuery, con);
            command.Parameters.AddWithValue("@MaTK", accountId);

            SqlDataReader reader = command.ExecuteReader();

            // Bước 3: Kiểm tra nếu có dữ liệu và hiển thị lên các TextBox
            if (reader.Read())
            {
                txtRMaTK.Text = reader["MaTK"].ToString();
                txtRMaKH.Text = reader["MaKH"].ToString();
                txtRTenDN.Text = reader["TENDANGNHAP"].ToString();
                txtRMatKhau.Text = reader["Matkhau"].ToString();
                txtRMaNV.Text = reader["Manv"].ToString();
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Nếu không tìm thấy tài khoản, xóa nội dung trong các TextBox
                txtRMaTK.Clear();
                txtRMaKH.Clear();
                txtRTenDN.Clear();
                txtRMatKhau.Clear();
                txtRMaNV.Clear();
            }

            // Đóng kết nối
            con.Close();
        }
    }
}

