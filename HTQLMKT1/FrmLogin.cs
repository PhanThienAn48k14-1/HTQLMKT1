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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void BTNLogin_Click(object sender, EventArgs e)
        {
            string sCon = "Data Source=PC\\MSSQLSERVER01;Initial Catalog=HTQLYMKT;Integrated Security=True;";
            using (SqlConnection con = new SqlConnection(sCon))
            {
                try
                {
                    con.Open();
                    string sTenDN = txtTenDN.Text;
                    string sMK = txtMK.Text;

                    if (string.IsNullOrWhiteSpace(sTenDN) || string.IsNullOrWhiteSpace(sMK))
                    {
                        MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    SqlCommand sSDT = new SqlCommand("sp_dangnhap", con);
                    sSDT.CommandType = CommandType.StoredProcedure;
                    sSDT.Parameters.AddWithValue("@TenDn", sTenDN);
                    sSDT.Parameters.AddWithValue("@MatKhau", sMK);

                    SqlParameter kqParam = new SqlParameter("@KQ", SqlDbType.Int);
                    kqParam.Direction = ParameterDirection.Output;
                    sSDT.Parameters.Add(kqParam);

                    sSDT.ExecuteNonQuery();

                    int KqSDT = Convert.ToInt32(kqParam.Value);

                    if (KqSDT == 0)
                    {
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu bị sai", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        // Lưu tên đăng nhập vào Global.CurrentUser
                        Global.CurrentUser = sTenDN;

                        if (KqSDT == 1)
                        {
                            MessageBox.Show("Đăng nhập thành công với vai trò nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            var NV = new NhanVien();
                            NV.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Đăng nhập thành công với vai trò khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            var KH = new KhachHang(sTenDN);
                            KH.Show();
                            this.Hide();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kết nối bị lỗi: " + ex.Message);
                }
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BTNDK_Click(object sender, EventArgs e)
        {
            var DK = new FrmDK();
            DK.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
