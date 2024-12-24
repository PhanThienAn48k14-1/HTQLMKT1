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
    public partial class UQLHD : Form
    {
        public UQLHD()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //Bước 1
            string sCon = "Data Source=DESKTOP-74S139L;Initial Catalog = HTQLYMKT1; Integrated Security = True;";
            SqlConnection con = new SqlConnection(sCon);
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Xảy ra lỗi trong quá trình kết nối DB");
            }
            //Bước 2
            string sMaHD = txtMAHD.Text;
            if (sMaHD.Length > 10)
            {
                MessageBox.Show("Mã hợp đồng không hợp lệ");
                return;
            }
            if (!CheckMaHD(con, sMaHD))
            {
                MessageBox.Show($"Mã hợp đồng '{sMaHD}' không tồn tại");
                con.Close();
                return;
            }
            string sMADK = txtDKHD.Text;
            DateTime ngaydangky = datetimeDKY.Value;
            DateTime ngayhethan = datetimeHHAN.Value;
            if (ngaydangky > DateTime.Now)
            {
                MessageBox.Show("Ngày đăng ký hợp đồng không hợp lệ");
                return;
            }
            string sNgaydangky = ngaydangky.ToString("yyyy-MM-dd");
            string sNgayhethan = ngayhethan.ToString("yyyy-MM-dd");
            string sMaDV = txtMADVMKT.Text;
            if (sMaDV.Length > 10)
            {
                MessageBox.Show("Mã dịch vụ marketing không hợp lệ");
                return;
            }
            // Kiểm tra mã dịch vụ marketing
            if (!CheckMaDichVu(con, sMaDV))
            {
                MessageBox.Show($"Mã dịch vụ marketing '{sMaDV}' không tồn tại");
                con.Close();
                return;
            }
            string sMaKH = txtMAKH.Text;
            if ( sMaKH.Length > 10)
            {
                MessageBox.Show("Mã khách hàng không hợp lệ");
                return;
            }
            // Kiểm tra mã khách hàng
            if (!CheckMaKhachHang(con, sMaKH))
            {
                MessageBox.Show($"Mã khách hàng '{sMaKH}' không tồn tại");
                con.Close();
            }
            string sMaNV = txtMANV.Text;
            if ( sMaNV.Length > 10)
            {
                MessageBox.Show("Mã nhân viên không hợp lệ");
                return;
            }
            // Kiểm tra mã nhân viên
            if (!CheckMaNhanVien(con, sMaNV))
            {
                MessageBox.Show($"Mã nhân viên '{sMaNV}' không tồn tại");
                con.Close();
                return;
            }

            string sQuery = "update HopDong set DIEUKHOAN=@DIEUKHOAN, NGAYKY=@NGAYKY, NGAYHETHAN=@NGAYHETHAN, MADVMKT=@MADVMKT, MAKH=@MAKH, MANV=@MANV where MAHD=@MAHD";
            SqlCommand cmd = new SqlCommand(sQuery, con);
            cmd.Parameters.AddWithValue("@MAHD", sMaHD);
            cmd.Parameters.AddWithValue("@DIEUKHOAN", sMADK);
            cmd.Parameters.AddWithValue("@NGAYKY", sNgaydangky);
            cmd.Parameters.AddWithValue("@NGAYHETHAN", sNgayhethan);
            cmd.Parameters.AddWithValue("@MADVMKT", sMaDV);
            cmd.Parameters.AddWithValue("@MAKH", sMaKH);
            cmd.Parameters.AddWithValue("@MANV", sMaNV);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sửa hợp đồng thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("xảy ra lỗi trong quá trình sửa" + ex.Message);
            }
            con.Close();
        }
        // Hàm kiểm tra mã dịch vụ marketing
        private bool CheckMaDichVu(SqlConnection con, string maDVMKT)
        {
            string query = "SELECT dbo.fn_kiemTraMaDichVu(@madvmkt)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@madvmkt", maDVMKT);

            try
            {
                int exists = Convert.ToInt32(cmd.ExecuteScalar());
                return exists == 1; // Trả về true nếu mã dịch vụ tồn tại
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trong quá trình kiểm tra mã dịch vụ: " + ex.Message);
                return false;
            }
        }

        // Hàm kiểm tra mã khách hàng
        private bool CheckMaKhachHang(SqlConnection con, string maKH)
        {
            string query = "SELECT dbo.fKiemtraMaKH(@makh)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@makh", maKH);

            try
            {
                int exists = Convert.ToInt32(cmd.ExecuteScalar());
                return exists == 1; // Trả về true nếu mã khách hàng tồn tại
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trong quá trình kiểm tra mã khách hàng: " + ex.Message);
                return false;
            }
        }

        // Hàm kiểm tra mã nhân viên
        private bool CheckMaNhanVien(SqlConnection con, string maNV)
        {
            string query = "SELECT dbo.CHECKMANV(@manv)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@manv", maNV);

            try
            {
                int exists = Convert.ToInt32(cmd.ExecuteScalar());
                return exists == 1; // Trả về true nếu mã nhân viên tồn tại
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trong quá trình kiểm tra mã nhân viên: " + ex.Message);
                return false;
            }
        }

        // Function to check if MAHD exists
        private bool CheckMaHD(SqlConnection con, string maHD)
        {
            string query = "SELECT dbo.Check_MaHD(@mahd)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@mahd", maHD);

            try
            {
                int exists = Convert.ToInt32(cmd.ExecuteScalar());
                return exists == 1; // Return true if contract exists
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trong quá trình kiểm tra mã hợp đồng: " + ex.Message);
                return false;
            }
        }

    }
}
