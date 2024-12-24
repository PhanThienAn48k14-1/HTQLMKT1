using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //Bước 0


namespace HTQLMKT1
{
    public partial class RQLTK : Form
    {
        string sCon = "Data Source=DESKTOP-74S139L;Initial Catalog=HTQLYMKT;Intergrated Security=True";

        public RQLTK()
        {
            InitializeComponent();
        }

        private void btnRHuy_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chào bạn, Bạn không muốn xem nữa ư ?");
        }

        private void RQLTK_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Chào bạn !");
        }

        private void RQLTK_Load(object sender, EventArgs e)
        {

            //Bước 1
            SqlConnection con = new SqlConnection(sCon);
         
            try
            {
                con.Open();
            }
            catch(Exception)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình kết nối DB");
            }
            //Bước 2 - Lấy dữ liệu về 
            string sQuery = "select * from TaiKhoan";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);

            DataSet dataSet = new DataSet();

            adapter.Fill(dataSet, "TaiKhoan");

            dataGridView1.DataSource = dataSet.Tables["TaiKhoan"];

            con.Close(); //Bước 3 
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtRMaTK.Text = dataGridView1.Rows[e.RowIndex].Cells["MaTK"].Value.ToString();
            txtRMaKH.Text = dataGridView1.Rows[e.RowIndex].Cells["MaKH"].Value.ToString();
            txtRTenDN.Text = dataGridView1.Rows[e.RowIndex].Cells["Tendangnhap"].Value.ToString();
            txtRMatKhau.Text = dataGridView1.Rows[e.RowIndex].Cells["Matkhau"].Value.ToString();
            txtRMaNV.Text = dataGridView1.Rows[e.RowIndex].Cells["Manv"].Value.ToString();
            txtRMaTK.Enabled = false;




        }
    }
}
