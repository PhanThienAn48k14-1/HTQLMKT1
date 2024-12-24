using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HTQLMKT1
{
    public partial class DQLKH : Form
    {
        private string sCon = "Data Source=DESKTOP-74S139L;Initial Catalog = HTQLYMKT1; Integrated Security = True;";
        private string username = "";
        public DQLKH()
        {
            InitializeComponent();
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
                    string query = "SELECT * FROM KhachHang"; // Truy vấn lấy dữ liệu từ bảng KhachHang
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        // Gán dữ liệu vào DataGridView
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

        private void button1_Click(object sender, EventArgs e)
        {
            string sMaKH = txtMaKHDelete.Text;

            // Kiểm tra nếu mã khách hàng để trống
            if (string.IsNullOrWhiteSpace(sMaKH))
            {
                MessageBox.Show("Vui lòng nhập mã khách hàng cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection con = new SqlConnection(sCon))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_deleteKH", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm tham số đầu vào
                    cmd.Parameters.AddWithValue("@MAKH", sMaKH);

                    // Thêm tham số đầu ra để nhận kết quả xóa
                    SqlParameter outputParam = new SqlParameter("@kq", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputParam);

                    // Thực thi lệnh
                    cmd.ExecuteNonQuery();

                    // Kiểm tra kết quả từ thủ tục lưu trữ
                    int result = Convert.ToInt32(outputParam.Value);

                    if (result == 1)
                    {
                        MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData(); // Tải lại dữ liệu sau khi xóa
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy khách hàng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thực hiện xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void BTNDeleteBack_Click(object sender, EventArgs e)
        {
            // Quay lại form NhanVien
            var QL = new NhanVien();
            QL.Show();
            this.Hide();
        }
    }
}
