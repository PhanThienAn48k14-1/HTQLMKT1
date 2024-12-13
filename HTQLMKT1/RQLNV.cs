using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;//Buoc 0

namespace HTQLMKT1
{
    public partial class RQLNV : Form
    {
        string sCon = "Data Source=LAPTOP-C240ING2\\MSSQLSERVER_DEV;Initial Catalog=HTQLYMKT;Integrated Security=True;TrustServerCertificate=True";

        public RQLNV()
        {
            InitializeComponent();
        }
        private void RQLNV_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Bạn đã đóng form xem thông tin nhân viên.", "Thông báo");
        }
        private void RQLNV_Load(object sender, EventArgs e)
        {
            //buoc1


            SqlConnection con = new SqlConnection(sCon);
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình kết nối Database!!!");
            }
            //bước 2
            string sQuery = "select * from NhanVien";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);

            DataSet ds = new DataSet();

            adapter.Fill(ds, "NhanVien");

            dataGridView1.DataSource = ds.Tables["NhanVien"];

            con.Close();//buoc3
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtMATK_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtDIACHI_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dtpNGSINH_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtHOTEN_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtMANV_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMANV.Text = dataGridView1.Rows[e.RowIndex].Cells["MANV"].Value.ToString();
            txtHOTEN.Text = dataGridView1.Rows[e.RowIndex].Cells["HOTEN"].Value.ToString(); ;
            txtMATK.Text = dataGridView1.Rows[e.RowIndex].Cells["MATK"].Value.ToString(); ;
            txtSDT.Text = dataGridView1.Rows[e.RowIndex].Cells["SDT"].Value.ToString(); ;
            dtpNGSINH.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["NGSINH"].Value);
            txtDIACHI.Text = dataGridView1.Rows[e.RowIndex].Cells["DIACHI"].Value.ToString(); ;

            txtMANV.Enabled = false;
            txtMATK.Enabled = false;

        }

        private void RQLNV_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            //MessageBox.Show("Bạn đã đóng form xem thông tin nhân viên.", "Thông báo");
        }

        private void btnBACK_Click(object sender, EventArgs e)
        {
            // Đóng form hiện tại (CQLNV)
            this.Close();

            // Tạo và hiển thị form NhanVien
            NhanVien frmNhanVien = new NhanVien();
            frmNhanVien.Show();
        }

        private void btnBACK_Click_1(object sender, EventArgs e)
        {
            // Đóng form hiện tại (CQLNV)
            this.Close();

            // Tạo và hiển thị form NhanVien
            NhanVien frmNhanVien = new NhanVien();
            frmNhanVien.Show();
        }
    }
}
