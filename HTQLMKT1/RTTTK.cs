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
        string sCon = "Data Source=YANG;Initial Catalog=HTQLYMKT;Persist Security Info=True;User ID=KhachHang;Password=nhom3@123;TrustServerCertificate=True";
        public RTTTK()
        {
            InitializeComponent();
        }

        private void RTTTK_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Hãy nhập mã tài khoản của quý khách!");
            txtMaTK.Enabled = true;
            txtMaTK.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" Bạn chắc chắn không xem?");
        }

        private void label6_Click(object sender, EventArgs e)
        { }

        private void btnXemm_Click(object sender, EventArgs e)
        {
            string accountId = txtMaTK.Text.Trim(); // Lấy mã tài khoản từ TextBox

            // Kiểm tra nếu mã tài khoản rỗng
            if (string.IsNullOrEmpty(accountId))
            {
                MessageBox.Show("Vui lòng nhập Mã Tài Khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Nếu mã tài khoản không rỗng, ta sẽ gọi phương thức để tìm kiếm thông tin tài khoản
            FilterAccountByID(accountId);
        }

        // Phương thức lọc thông tin tài khoản theo mã tài khoản
        private void FilterAccountByID(string accountId)
        {
            string query = "SELECT MaTK, MaKH, TenDangnhap, MATKHAU, MANV FROM TaiKhoan WHERE MaTK = @MaTK";

            try
            {
                using (SqlConnection connection = new SqlConnection(sCon))
                {
                    connection.Open();

                    // Tạo câu lệnh SQL
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaTK", accountId); // Thêm tham số vào câu lệnh SQL

                    // Sử dụng SqlDataAdapter để lấy dữ liệu
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable); // Lấy dữ liệu vào DataTable

                    // Kiểm tra nếu có kết quả
                    if (dataTable.Rows.Count > 0)
                    {
                        // Chỉ hiển thị giá trị mà không hiển thị tên cột
                        labelMaKH.Text = dataTable.Rows[0]["MaKH"].ToString();
                        labelTenDNKH.Text = dataTable.Rows[0]["TenDangnhap"].ToString();
                        labelMatKhau.Text = dataTable.Rows[0]["MATKHAU"].ToString(); // Hoặc có thể dấu sao nếu không muốn hiển thị mật khẩu thật

                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Nếu không tìm thấy tài khoản, xóa thông tin hiển thị trong các Label
                        labelMaKH.Text = "Mã Khách Hàng: ";
                        labelTenDNKH.Text = "Tên Đăng Nhập: ";
                        labelMatKhau.Text = "Mật Khẩu: ";

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

