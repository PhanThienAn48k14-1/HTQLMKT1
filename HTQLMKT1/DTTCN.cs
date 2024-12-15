using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HTQLMKT1
{
    public partial class DTTCN : Form
    {
        private string username;
        String sCon = "Data Source=PC\\MSSQLSERVER01;Initial Catalog=HTQLYMKT;Integrated Security=True;";

        public DTTCN()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Xử lý sự kiện khi người dùng click vào một ô trong DataGridView
        }

        public DTTCN(string sTenDN) : this() // Gọi constructor mặc định
        {
            username = sTenDN; // Nhận tên đăng nhập từ form trước đó
        }

        private void DTTCN_Load(object sender, EventArgs e)
        {
            LoadData(); // Tải dữ liệu khi form được mở
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
                        dataGridView1.DataSource = dt; // Hiển thị dữ liệu lên DataGridView
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

        private void BTNXoaTT_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(sCon))
            {
                try
                {
                    con.Open();
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

                    // Xóa khách hàng và tài khoản
                    SqlCommand sXoaMAKH = new SqlCommand("sp_deleteKH", con);
                    sXoaMAKH.CommandType = CommandType.StoredProcedure;
                    sXoaMAKH.Parameters.AddWithValue("@MAKH", maKH);

                    SqlParameter kq = new SqlParameter("@kq", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    sXoaMAKH.Parameters.Add(kq);

                    sXoaMAKH.ExecuteNonQuery();

                    // Kiểm tra kết quả xóa
                    int KqDeleteMakh = Convert.ToInt32(kq.Value);
                    if (KqDeleteMakh == 1)
                    {
                        MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK);
                        LoadData(); // Tải lại dữ liệu sau khi xóa, sẽ không còn thông tin của khách hàng
                    }
                    else
                    {
                        MessageBox.Show("Xóa không thành công. Có thể khách hàng không tồn tại hoặc đã bị xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
