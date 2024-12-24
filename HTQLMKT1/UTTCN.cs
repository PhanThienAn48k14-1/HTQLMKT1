using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HTQLMKT1
{
    public partial class UTTCN : Form
    {
        private string username;
        String sCon = "Data Source=DESKTOP-74S139L;Initial Catalog = HTQLYMKT1; Integrated Security = True;";

        public UTTCN()
        {
            InitializeComponent();
        }

        public UTTCN(string sTenDN) : this() // Gọi constructor mặc định
        {
            username = sTenDN;
        }
        // Đảm bảo username được khởi tạo đúng cách trong constructor

        // Hoặc từ biến toàn cục nếu dùng Global.CurrentUser
        private void UTTCN_Load(object sender, EventArgs e)
        {
            username = Global.CurrentUser; // Lấy tên đăng nhập từ biến toàn cục
            LoadData();
        }

        private void LoadData()
        {
            string username = Global.CurrentUser;  // Lấy tên đăng nhập từ biến toàn cục
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Không có tên đăng nhập để tải dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection con = new SqlConnection(sCon))
            {
                try
                {
                    con.Open();
                    SqlCommand cmdXemTT = new SqlCommand("sp_xemttcuakh", con);
                    cmdXemTT.CommandType = CommandType.StoredProcedure;
                    cmdXemTT.Parameters.AddWithValue("@TenDN", username);

                    SqlDataAdapter da = new SqlDataAdapter(cmdXemTT);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BTNSuaTT_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(sCon))
            {
                try
                {
                    con.Open();
                    // Biến kiểm tra hợp lệ
                    int isInvalid = 0;

                    // Kiểm tra số điện thoại
                    if (!string.IsNullOrWhiteSpace(txtSDTUpdate.Text))
                    {
                        string SDT = txtSDTUpdate.Text;
                        SqlCommand sSDT = new SqlCommand("CheckUniquePhone", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        sSDT.Parameters.AddWithValue("@SoDienThoai", SDT);

                        SqlParameter kqSDT = new SqlParameter("@KQ", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        sSDT.Parameters.Add(kqSDT);

                        sSDT.ExecuteNonQuery();
                        if (Convert.ToInt32(kqSDT.Value) == 0)
                        {
                            isInvalid++;
                        }
                    }

                    // Kiểm tra email
                    if (!string.IsNullOrWhiteSpace(txtEmailUpdate.Text))
                    {
                        string Email = txtEmailUpdate.Text;
                        SqlCommand sEmail = new SqlCommand("CheckUniqueEmail", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        sEmail.Parameters.AddWithValue("@Email", Email);

                        SqlParameter kqEmail = new SqlParameter("@KQ", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        sEmail.Parameters.Add(kqEmail);

                        sEmail.ExecuteNonQuery();
                        if (Convert.ToInt32(kqEmail.Value) == 0)
                        {
                            isInvalid++;
                        }
                    }

                    // Nếu có thông tin không hợp lệ, hiển thị thông báo và dừng thực hiện
                    if (isInvalid > 0)
                    {
                        MessageBox.Show("Email hoặc Số Điện Thoại không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    // Lấy mã khách hàng từ username
                    SqlCommand sTenDN = new SqlCommand("sp_chuyendoitendn", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sTenDN.Parameters.AddWithValue("@tendn", username);

                    SqlParameter kqParam = new SqlParameter("@makh", SqlDbType.VarChar, 15)
                    {
                        Direction = ParameterDirection.Output
                    };
                    sTenDN.Parameters.Add(kqParam);

                    sTenDN.ExecuteNonQuery();

                    // Lấy mã khách hàng
                    string maKH = kqParam.Value?.ToString();

                    // Kiểm tra nếu không tìm thấy mã khách hàng
                    if (string.IsNullOrWhiteSpace(maKH))
                    {
                        MessageBox.Show("Không tìm thấy mã khách hàng tương ứng với tên đăng nhập đã cung cấp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Cập nhật thông tin
                    string tenKH = string.IsNullOrWhiteSpace(txtNameUpdate.Text) ? null : txtNameUpdate.Text;
                    string email = string.IsNullOrWhiteSpace(txtEmailUpdate.Text) ? null : txtEmailUpdate.Text;
                    string sdt = string.IsNullOrWhiteSpace(txtSDTUpdate.Text) ? null : txtSDTUpdate.Text;

                    SqlCommand cmd = new SqlCommand("spChangeInfor", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@makh", maKH);
                    cmd.Parameters.AddWithValue("@tenkh", (object)tenKH ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@email", (object)email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@sdt", (object)sdt ?? DBNull.Value);

                    SqlParameter kq = new SqlParameter("@kq", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(kq);

                    cmd.ExecuteNonQuery();

                    // Kiểm tra kết quả cập nhật
                    if (Convert.ToInt32(kq.Value) == 1)
                    {
                        MessageBox.Show("Cập nhật thông tin khách hàng thành công!", "Thông báo", MessageBoxButtons.OK);
                        LoadData(); // Tải lại dữ liệu sau khi cập nhật
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thông tin thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var QL = new KhachHang(username);
            QL.Show();
            this.Hide();
        }
    }
}




