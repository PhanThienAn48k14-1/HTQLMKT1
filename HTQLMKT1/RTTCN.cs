using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HTQLMKT1
{
    public partial class RTTCN : Form
    {
        private string username;
        String sCon = "Data Source=DESKTOP-74S139L;Initial Catalog = HTQLYMKT1; Integrated Security = True;";


        public RTTCN()
        {
            InitializeComponent();
        }

        public RTTCN(string sTenDN) : this() // Gọi constructor mặc định
        {
            username = sTenDN;
        }

        private void RTTCN_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string username = Global.CurrentUser; // Lấy tên đăng nhập từ biến toàn cục
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Không có tên đăng nhập để tải dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            String sCon = "Data Source=DESKTOP-74S139L;Initial Catalog = HTQLYMKT1; Integrated Security = True;";
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

        private void button2_Click(object sender, EventArgs e)
        {
            Global.CurrentUser = username;  // Lưu tên đăng nhập vào biến toàn cục
            var QL = new KhachHang();
            QL.Show();
            this.Hide();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

