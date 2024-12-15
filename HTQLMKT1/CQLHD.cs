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
using System.Net.NetworkInformation;

namespace HTQLMKT1
{
    public partial class CQLHD : Form
    {
        public CQLHD()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnTAO_Click(object sender, EventArgs e)
        {
            //Bước 1
            string sCon = "Data Source=DESKTOP-74S139L;Initial Catalog=HTQLYMKT;Integrated Security=True";
            SqlConnection con = new SqlConnection(sCon);
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình kết nối DB");
                return;
            }

            //Bước 2
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

            if (string.IsNullOrEmpty(sMaDV) || sMaDV.Length > 10)
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
            if (string.IsNullOrEmpty(sMaKH) || sMaKH.Length > 10)
            {
                MessageBox.Show("Mã khách hàng không hợp lệ");
                return;
            }

            // Kiểm tra mã khách hàng
            if (!CheckMaKhachHang(con, sMaKH))
            {
                MessageBox.Show($"Mã khách hàng '{sMaKH}' không tồn tại");
                con.Close();
                return;
            }

            string sMaNV = txtMANV.Text;
            if (string.IsNullOrEmpty(sMaNV) || sMaNV.Length > 10)
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

            SqlCommand command = new SqlCommand("Taomahd", con);
            command.CommandType = CommandType.StoredProcedure;

            // Output parameter to receive the generated MAHD
            SqlParameter outputParameter = new SqlParameter("@mahd_moi", SqlDbType.VarChar, 10);
            outputParameter.Direction = ParameterDirection.Output;
            command.Parameters.Add(outputParameter);

            // Execute the stored procedure
            command.ExecuteNonQuery();

            // Retrieve the generated MAHD from the output parameter
            string maHDMoi = (string)outputParameter.Value;

            string sQuery = "insert into HopDong values (@MAHD,@DIEUKHOAN,@NGAYKY,@NGAYHETHAN,@MADVMKT,@MAKH,@MANV)";
            SqlCommand cmd = new SqlCommand(sQuery, con);
            cmd.Parameters.AddWithValue("@MAHD", maHDMoi);
            cmd.Parameters.AddWithValue("@DIEUKHOAN", sMADK);
            cmd.Parameters.AddWithValue("@NGAYKY", sNgaydangky);
            cmd.Parameters.AddWithValue("@NGAYHETHAN", sNgayhethan);
            cmd.Parameters.AddWithValue("@MADVMKT", sMaDV);
            cmd.Parameters.AddWithValue("@MAKH", sMaKH);
            cmd.Parameters.AddWithValue("@MANV", sMaNV);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Tạo hợp đồng thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình thêm mới: " + ex.Message);
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
                
                return false;
            }
        }




    }
}
