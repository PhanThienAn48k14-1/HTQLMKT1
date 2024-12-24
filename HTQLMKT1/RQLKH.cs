using HTQLMKT1;
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
    public partial class RQLKH : Form
    {
        String sCon = "Data Source=DESKTOP-74S139L;Initial Catalog = HTQLYMKT1; Integrated Security = True;";


        public RQLKH()
        {
            InitializeComponent();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtMaKH_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void RQLKH_Load(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            var Nhanvien=new NhanVien();
            Nhanvien.Show();
            this.Hide();
        }
    }
}
