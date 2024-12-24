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
using System.Xml.Linq;
namespace HTQLMKT1
{
    public partial class FrmDK : Form
    {
        String sCon = "Data Source=DESKTOP-74S139L;Initial Catalog = HTQLYMKT1; Integrated Security = True;";
        public FrmDK()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void BTNDK_Click(object sender, EventArgs e)
        {
            int i = 0;
            //var DangKy = new FrmLogin();
            //DangKy.Show();
            //this.Hide();
            // Lấy số điện thoại từ TextBox

            // Kiểm tra số điện thoại
            using (SqlConnection con = new SqlConnection(sCon))
            {
                try
                {
                    con.Open();
                    string SDT = txtSDTNew.Text; // Giả sử TextBox nhập SDT có tên là txtSDTNew

                    if (string.IsNullOrWhiteSpace(SDT))
                    {
                        MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    else
                    {
                        SqlCommand sSDT = new SqlCommand("CheckUniquePhone", con);
                        sSDT.CommandType = CommandType.StoredProcedure;
                        // Tham số đầu vào
                        sSDT.Parameters.AddWithValue("@SoDienThoai", SDT);
                        // Tham số đầu ra
                        SqlParameter kqParam = new SqlParameter("@KQ", SqlDbType.Int);
                        kqParam.Direction = ParameterDirection.Output;
                        sSDT.Parameters.Add(kqParam);
                        sSDT.ExecuteNonQuery();
                        // Lấy giá trị đầu ra
                        int KqSDT = Convert.ToInt32(kqParam.Value);
                        // Kiểm tra số điện thoại qua thủ tục SQL
                        if (KqSDT == 0)
                        {
                            MessageBox.Show("Số điện thoại này không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return; // Dừng đăng ký nếu số điện thoại đã tồn tại
                        }
                        else
                        {
                            i = i + 1;
                            MessageBox.Show("Số điện thoại hợp lệ. Tiếp tục đăng ký.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kết nối bị lỗi");
                }
            }


            //Kiểm tra email
            using (SqlConnection con = new SqlConnection(sCon))
            {
                try
                {
                    con.Open();
                    string Email = txtEmailNew.Text; // Giả sử TextBox nhập SDT có tên là txtSDTNew

                    if (string.IsNullOrWhiteSpace(Email))
                    {
                        MessageBox.Show("Vui lòng nhập Email!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    else
                    {
                        SqlCommand sEmail = new SqlCommand("CheckUniqueEmail", con);
                        sEmail.CommandType = CommandType.StoredProcedure;
                        // Tham số đầu vào
                        sEmail.Parameters.AddWithValue("@Email", Email);
                        // Tham số đầu ra
                        SqlParameter kqParam = new SqlParameter("@KQ", SqlDbType.Int);
                        kqParam.Direction = ParameterDirection.Output;
                        sEmail.Parameters.Add(kqParam);
                        sEmail.ExecuteNonQuery();
                        // Lấy giá trị đầu ra
                        int KqSDT = Convert.ToInt32(kqParam.Value);
                        // Kiểm tra số điện thoại qua thủ tục SQL
                        if (KqSDT == 0)
                        {
                            MessageBox.Show("Địa chỉ Email này không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return; // Dừng đăng ký nếu số điện thoại đã tồn tại
                        }
                        else
                        {
                            i = i + 1;
                            MessageBox.Show("Email hợp lệ. Tiếp tục đăng ký.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kết nối bị lỗi");
                }
            }


            // Kiểm tra tên đăng nhập
            using (SqlConnection con = new SqlConnection(sCon))
            {
                try
                {
                    con.Open();
                    string TenDN = txtTenDNNew.Text; // Giả sử TextBox nhập SDT có tên là txtSDTNew

                    if (string.IsNullOrWhiteSpace(TenDN))
                    {
                        MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    else
                    {
                        SqlCommand sTenDN = new SqlCommand("CheckUniqueTenDN", con);
                        sTenDN.CommandType = CommandType.StoredProcedure;
                        // Tham số đầu vào
                        sTenDN.Parameters.AddWithValue("@TenDN", TenDN);
                        // Tham số đầu ra
                        SqlParameter kqParam = new SqlParameter("@KQ", SqlDbType.Int);
                        kqParam.Direction = ParameterDirection.Output;
                        sTenDN.Parameters.Add(kqParam);
                        sTenDN.ExecuteNonQuery();
                        // Lấy giá trị đầu ra
                        int KqSDT = Convert.ToInt32(kqParam.Value);
                        // Kiểm tra số điện thoại qua thủ tục SQL
                        if (KqSDT == 0)
                        {
                            MessageBox.Show("Tên đăng nhập này không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return; // Dừng đăng ký nếu số điện thoại đã tồn tại
                        }
                        else
                        {
                            i = i + 1;
                            MessageBox.Show("Tên đăng nhập hợp lệ. Tiếp tục đăng ký.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kết nối bị lỗi");
                }
            }


            using (SqlConnection con = new SqlConnection(sCon))
            {
                try
                {
                    con.Open();
                    if (i==3)
                    {
                        MessageBox.Show("Tạo tài khoản thành công", "Thông báo", MessageBoxButtons.OK);
                        // Bước 2: Chuẩn bị dữ liệu
                        string sTenKH = txtNameNew.Text;
                        string sSDTKH = txtSDTNew.Text;
                        string sEmailKH = txtEmailNew.Text;
                        string sTenDNKH = txtTenDNNew.Text;
                        string sMKKH = txtMKNew.Text;

                        // Bước 3: Gọi thủ tục tạo mã tài khoản mới

                        SqlCommand cmdTaoMaTKMoi = new SqlCommand("spTaomaTK", con);
                        cmdTaoMaTKMoi.CommandType = CommandType.StoredProcedure;
                        cmdTaoMaTKMoi.Parameters.Add(new SqlParameter("@MATK_MOI", SqlDbType.VarChar, 10) { Direction = ParameterDirection.Output });
                        cmdTaoMaTKMoi.ExecuteNonQuery(); // Thực thi thủ tục
                        string sMaTK = cmdTaoMaTKMoi.Parameters["@MATK_MOI"].Value.ToString();
                        // Lấy giá trị mã tài khoản mới từ thủ tục


                        // Bước 4: Gọi thủ tục tạo mã khách hàng mới

                        SqlCommand cmdTaoMaKHMoi = new SqlCommand("spTaomaKH", con);
                        cmdTaoMaKHMoi.CommandType = CommandType.StoredProcedure;
                        cmdTaoMaKHMoi.Parameters.Add(new SqlParameter("@MAKH_MOI", SqlDbType.VarChar, 10) { Direction = ParameterDirection.Output });
                        cmdTaoMaKHMoi.ExecuteNonQuery(); // Thực thi thủ tục
                        string sMaKH = cmdTaoMaKHMoi.Parameters["@MAKH_MOI"].Value.ToString();
                        // Lấy giá trị mã khách hàng mới từ thủ tục

                        // Bước 5: Thực thi lệnh thêm khách hàng
                        String sQuery = "insert into KhachHang values(@makh,@hoten,@email,@sdt,@matk)";
                        SqlCommand cmd = new SqlCommand(sQuery, con);
                        cmd.Parameters.AddWithValue("@makh", sMaKH);
                        cmd.Parameters.AddWithValue("@hoten", sTenKH);
                        cmd.Parameters.AddWithValue("@email", sEmailKH);
                        cmd.Parameters.AddWithValue("@sdt", sSDTKH);
                        cmd.Parameters.AddWithValue("@matk", sMaTK);
                        cmd.ExecuteNonQuery(); // Thực thi câu lệnh

                        //Bước 6: Thêm tài khoản mới vào bảng tài khoản

                        string sQueryThemTK = "insert into TaiKhoan values(@matk,@tendn,@matkhau,@makhang,@manv)";
                        SqlCommand cmdThemTKMoi = new SqlCommand(sQueryThemTK, con);
                        cmdThemTKMoi.Parameters.AddWithValue("@matk", sMaTK);
                        cmdThemTKMoi.Parameters.AddWithValue("@tendn", sTenDNKH);
                        cmdThemTKMoi.Parameters.AddWithValue("@matkhau", sMKKH);
                        cmdThemTKMoi.Parameters.AddWithValue("@makhang", sMaKH);
                        cmdThemTKMoi.Parameters.AddWithValue("@manv", DBNull.Value);
                        cmdThemTKMoi.ExecuteNonQuery();
                    }    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kết nối bị lỗi");
                }
            }


        }

        private void FrmDK_Load(object sender, EventArgs e)
        {

        }

        private void BTNDKback_Click(object sender, EventArgs e)
        {
            var DangKyBack = new FrmLogin();
            DangKyBack.Show();
            this.Hide();
        }
    }
}

// Bước 7: Hiện thông báo thành công
//MessageBox.Show("Tạo tài khoản mới thành công", "Thông báo");
