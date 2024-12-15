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
    public partial class txtEmail : Form
    {
        String sCon = "Data Source=PC\\MSSQLSERVER01;Initial Catalog=HTQLYMKT;Integrated Security=True;";
        public txtEmail()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void DQLKH_Load(object sender, EventArgs e)
        {
            // Tải dữ liệu khi form được load
            LoadData();
        }

        private void LoadData()
        {
            using (SqlConnection con = new SqlConnection(sCon))
            {
                try
                {
                    con.Open();
                    string sMaKH = txtMaKH.Text;

                    // Thay vì sử dụng SqlDataAdapter trực tiếp, sử dụng SqlCommand với tham số
                    string query = "SELECT * FROM KhachHang WHERE MAKH = @makh"; // Truy vấn lấy dữ liệu từ bảng KhachHang

                    // Tạo SqlCommand với câu lệnh SQL và kết nối
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@makh", sMaKH); // Thêm tham số vào câu lệnh SQL

                    SqlDataAdapter da = new SqlDataAdapter(cmd); // Sử dụng SqlDataAdapter với SqlCommand
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        // Gán dữ liệu vào DataGridView
                        dataGridView1.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy khách hàng với mã khách hàng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sMaKH = txtMaKH.Text;
            using (SqlConnection con = new SqlConnection(sCon))
            {
                try
                {
                    con.Open();
                    SqlCommand sMakh = new SqlCommand("sp_kiemtramakh", con);
                    sMakh.CommandType = CommandType.StoredProcedure;
                    // Tham số đầu vào
                    sMakh.Parameters.AddWithValue("@MaKH", sMaKH);
                    // Tham số đầu ra
                    SqlParameter kqParam = new SqlParameter("@KQ", SqlDbType.Int);
                    kqParam.Direction = ParameterDirection.Output;
                    sMakh.Parameters.Add(kqParam);
                    sMakh.ExecuteNonQuery();
                    // Lấy giá trị đầu ra
                    int KqMaKH = Convert.ToInt32(kqParam.Value);
                    if (KqMaKH == 0)
                    {
                        MessageBox.Show("Không tìm thấy mã khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Tìm thấy mã khách hàng!", "Thông báo", MessageBoxButtons.OK);

                        // Gọi thủ tục lấy thông tin khách hàng
                        SqlCommand cmdXemTT = new SqlCommand("sp_xemttkh", con);
                        cmdXemTT.CommandType = CommandType.StoredProcedure;

                        // Thêm tham số đầu vào
                        cmdXemTT.Parameters.AddWithValue("@MaKH", sMaKH);

                        // Đổ dữ liệu vào DataTable
                        SqlDataAdapter da = new SqlDataAdapter(cmdXemTT);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Hiển thị dữ liệu trong DataGridView
                        dataGridView1.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kết nối bị lỗi");
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

                    // Cập nhật thông tin
                    string maKH = txtMaKH.Text; // Mã khách hàng
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

                    // Kết quả cập nhật
                    if (Convert.ToInt32(kq.Value) == 1)
                    {
                        MessageBox.Show("Cập nhật thông tin khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy mã khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            var QL = new NhanVien();
            QL.Show();
            this.Hide();
        }

        private void txtEmail_Load(object sender, EventArgs e)
        {

        }


    }
}
