using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;//Buoc 0

namespace HTQLMKT1
{
    public partial class CQLNV : Form
    {
        string sCon = "Data Source=LAPTOP-C240ING2\\MSSQLSERVER_DEV;Initial Catalog=HTQLYMKT;Integrated Security=True;TrustServerCertificate=True";

        public CQLNV()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void CQLNV_Load(object sender, EventArgs e)
        {

            LoadData();
            // Tạo mã nhân viên mới
            txtMANV.Text = GenerateNewMANV(); // Hiển thị mã mới trong TextBox txtMANV
            //buoc1


            SqlConnection con = new SqlConnection(sCon);
            try
            {
                con.Open();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình kết nối Database!!!");
            }
            //bước 2
            string sQuery = "select * from NhanVien";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery,con);
            
            DataSet ds = new DataSet();

            adapter.Fill(ds, "NhanVien");

            dataGridView1.DataSource = ds.Tables["NhanVien"];

            con.Close();//buoc3

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CQLNV_FormClosing(object sender, FormClosingEventArgs e)
        {
         //   MessageBox.Show("Bạn đã đóng form thêm nhân viên mới.", "Thông báo");
        }

        private void btnHUY_Click(object sender, EventArgs e)
        {

        }

        private void btnLUU_Click(object sender, EventArgs e)
        {
            string sMANV = GenerateNewMANV(); // Gọi hàm tạo mã nhân viên mới

            // string sMANV = txtMANV.Text;
            string sHOTEN = txtHOTEN.Text;
            string sMATK = txtMATK.Text;
            string sSDT = txtSDT.Text;
            string sNGSINH = dtpNGSINH.Value.ToString("yyyy-MM-dd");
            string sDIACHI = txtDIACHI.Text;

            // Kiểm tra độ dài và định dạng
            if (sMANV.Length != 10)
            {
                MessageBox.Show("Mã nhân viên phải có đúng 10 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (sMATK.Length != 10)
            {
                MessageBox.Show("Mã tài khoản phải có đúng 10 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (sSDT.Length != 10 || !sSDT.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại phải có đúng 10 chữ số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra họ tên không được để trống
            if (string.IsNullOrWhiteSpace(sHOTEN))
            {
                MessageBox.Show("Họ tên không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime ngaySinh;
            if (!DateTime.TryParse(sNGSINH, out ngaySinh) || ngaySinh > DateTime.Now)
            {
                MessageBox.Show("Ngày sinh không hợp lệ. Vui lòng chọn ngày nhỏ hơn hoặc bằng ngày hiện tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra dữ liệu từ cơ sở dữ liệu: Kiểm tra số điện thoại, mã nhân viên và mã tài khoản đã tồn tại chưa
            string queryCheck = @"
            IF NOT EXISTS (SELECT 1 FROM TaiKhoan WHERE matk = @MATK)
                SELECT N'Mã tài khoản không tồn tại' AS Message;

            
            
            ELSE IF EXISTS (SELECT 1 FROM nhanvien WHERE sdt = @SDT)
                SELECT N'Số điện thoại đã tồn tại' AS Message;
            ELSE
                SELECT 'OK' AS Message;";

            string queryInsert = "INSERT INTO NhanVien (manv, sdt, hoten, ngsinh, diachi, matk) VALUES (@MANV, @SDT, @HOTEN, @NGSINH, @DIACHI, @MATK)";

            using (SqlConnection con = new SqlConnection(sCon))
            {
                try
                {
                    con.Open();

                    using (SqlCommand cmdCheck = new SqlCommand(queryCheck, con))
                    {
                        cmdCheck.Parameters.AddWithValue("@MANV", sMANV);
                        cmdCheck.Parameters.AddWithValue("@MATK", sMATK);
                        cmdCheck.Parameters.AddWithValue("@SDT", sSDT);

                        string message = (string)cmdCheck.ExecuteScalar();

                        if (message != "OK")
                        {
                            MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    using (SqlCommand cmdInsert = new SqlCommand(queryInsert, con))
                    {
                        cmdInsert.Parameters.AddWithValue("@MANV", sMANV);
                        cmdInsert.Parameters.AddWithValue("@SDT", sSDT);
                        cmdInsert.Parameters.AddWithValue("@HOTEN", sHOTEN);
                        cmdInsert.Parameters.AddWithValue("@NGSINH", sNGSINH);
                        cmdInsert.Parameters.AddWithValue("@DIACHI", sDIACHI);
                        cmdInsert.Parameters.AddWithValue("@MATK", sMATK);

                        cmdInsert.ExecuteNonQuery();
                        MessageBox.Show("Thêm mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // Tải lại dữ liệu vào DataGridView
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Xảy ra lỗi trong quá trình kết nối cơ sở dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        ///////////////
        private void LoadData()
        {
            using (SqlConnection con = new SqlConnection(sCon))
            {
                try
                {
                    con.Open(); // Mở kết nối đến cơ sở dữ liệu
                    string sQuery = "SELECT * FROM NhanVien"; // Câu truy vấn lấy toàn bộ dữ liệu từ bảng NhanVien
                    SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);

                    DataSet ds = new DataSet(); // Bộ nhớ lưu trữ dữ liệu
                    adapter.Fill(ds, "NhanVien"); // Đổ dữ liệu từ cơ sở dữ liệu vào DataSet

                    dataGridView1.DataSource = ds.Tables["NhanVien"]; // Gán dữ liệu vào DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Xảy ra lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        ////////
        private string GenerateNewMANV()
        {
            string manvNew = string.Empty;
            string prefix = "NV"; // Tiền tố mã nhân viên
            int maxNumber = 0;

            string query = @"
        SELECT ISNULL(MAX(CAST(SUBSTRING(MANV, 3, LEN(MANV) - 2) AS INT)), 0) + 1 AS NewNumber
        FROM NhanVien";

            using (SqlConnection con = new SqlConnection(sCon))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Lấy số lớn nhất từ bảng
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            maxNumber = Convert.ToInt32(result);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tạo mã nhân viên mới: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Tạo mã nhân viên mới bằng cách ghép tiền tố với số đã tăng
            manvNew = prefix + maxNumber.ToString("D8"); // Định dạng thành 8 chữ số
            return manvNew;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Đóng form hiện tại (CQLNV)
            this.Close();

            // Tạo và hiển thị form NhanVien
            NhanVien frmNhanVien = new NhanVien();
            frmNhanVien.Show();
        }
    }

}
