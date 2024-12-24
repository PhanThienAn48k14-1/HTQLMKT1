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
using System.Reflection.Emit;
using System.Text.RegularExpressions;
namespace HTQLMKT1
{
    public partial class CQLTK : Form
    {
        private SqlConnection con;
        string sCon = "Data Source=YANG;Initial Catalog=HTQLYMKT;Persist Security Info=True;User ID=NhanVien;Password=nhom3@123;TrustServerCertificate=True";

        public CQLTK()
        {
            InitializeComponent();
        }



        private void CQLTK_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Xin Chào, Hẹn gặp lại lần sau !", "Thông báo");
        }

        private void btnTaoTK_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDN.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();
            string maKH = txtMaKH.Text.Trim();
            Regex regexKH = new Regex(@"^KH\d{8}$"); // Định dạng "KH" + 8 số

            if (!regexKH.IsMatch(maKH))
            {
                MessageBox.Show("Mã khách hàng không hợp lệ. Định dạng hợp lệ: KH + 8 số.");
                return;
            }
            string maNV = txtMaNV.Text.Trim();
            // Kiểm tra mã nhân viên (phải có định dạng "NV" + 8 số)
            Regex regexNV = new Regex(@"^NV\d{8}$"); // Định dạng "NV" + 8 số
            if (!regexNV.IsMatch(maNV))
            {
                MessageBox.Show("Mã nhân viên không hợp lệ. Định dạng hợp lệ: NV + 8 số.");
                return;
            }
            string maTK = "";

            using (SqlConnection conn = new SqlConnection(sCon))
            {
                try
                {
                    conn.Open();

                    // Kiểm tra tên đăng nhập
                    SqlCommand cmdCheckUsername = new SqlCommand("spKiemTraTenDangNhap", conn);
                    cmdCheckUsername.CommandType = CommandType.StoredProcedure;
                    cmdCheckUsername.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);

                    SqlParameter tonTaiParam = new SqlParameter("@TonTai", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    cmdCheckUsername.Parameters.Add(tonTaiParam);

                    cmdCheckUsername.ExecuteNonQuery();

                    if ((int)tonTaiParam.Value == 1)
                    {
                        MessageBox.Show("Tên đăng nhập đã tồn tại. Vui lòng nhập tên khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Kiểm tra mật khẩu
                    SqlCommand cmdCheckPassword = new SqlCommand("spKiemTraMatKhau", conn);
                    cmdCheckPassword.CommandType = CommandType.StoredProcedure;
                    cmdCheckPassword.Parameters.AddWithValue("@MatKhau", matKhau);

                    SqlParameter hopLeParam = new SqlParameter("@HopLe", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    cmdCheckPassword.Parameters.Add(hopLeParam);

                    cmdCheckPassword.ExecuteNonQuery();

                    if ((int)hopLeParam.Value == 0)
                    {
                        MessageBox.Show("Mật khẩu không hợp lệ. Vui lòng thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Kiểm tra mã KH và NV
                    SqlCommand cmdCheckKHNV = new SqlCommand("spKiemTraMaKH_NV", conn);
                    cmdCheckKHNV.CommandType = CommandType.StoredProcedure;
                    cmdCheckKHNV.Parameters.AddWithValue("@MAKH", maKH);
                    cmdCheckKHNV.Parameters.AddWithValue("@MANV", maNV);

                    SqlParameter khnvHopLeParam = new SqlParameter("@HopLe", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    cmdCheckKHNV.Parameters.Add(khnvHopLeParam);

                    cmdCheckKHNV.ExecuteNonQuery();

                    if ((int)khnvHopLeParam.Value == 0)
                    {
                        MessageBox.Show("Mã KH hoặc NV không hợp lệ hoặc đã tồn tại trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Tạo tài khoản
                    SqlCommand cmdCreateAccount = new SqlCommand("spTaoTaiKhoan", conn);
                    cmdCreateAccount.CommandType = CommandType.StoredProcedure;
                    cmdCreateAccount.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                    cmdCreateAccount.Parameters.AddWithValue("@MatKhau", matKhau);
                    cmdCreateAccount.Parameters.AddWithValue("@MAKH", maKH);
                    cmdCreateAccount.Parameters.AddWithValue("@MANV", maNV);

                    // Thêm tham số đầu ra @KETQUA
                    SqlParameter ketQuaParam = new SqlParameter("@KETQUA", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    cmdCreateAccount.Parameters.Add(ketQuaParam);

                    cmdCreateAccount.ExecuteNonQuery();

                    // Kiểm tra kết quả trả về từ @KETQUA
                    if ((int)ketQuaParam.Value == 1)
                    {
                        MessageBox.Show("Tài khoản được tạo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Cập nhật DataGridView
                        LoadDataGridView();
                    }
                    else
                    {
                        MessageBox.Show("Tạo tài khoản không thành công. Vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }


                    MessageBox.Show($"Tài khoản được tạo thành công! Mã TK: {maTK}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Cập nhật DataGridView
                    LoadDataGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }

        }
        
      





        private void LoadDataGridView()
        {
            using (SqlConnection conn = new SqlConnection(sCon))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM TaiKhoan";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
         



        private void CQLTK_Load(object sender, EventArgs e)
        {
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


       
        private void txtTenDN_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
