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
    public partial class DQLTK : Form
    {
        string sCon = "Data Source=DESKTOP-74S139L;Initial Catalog=HTQLYMKT;Intergrated Security=True ";
        public DQLTK()
        {
            InitializeComponent();
        }

        private void DQLTK_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Chào bạn ");

        }

        private void btnXoaTK_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Bạn có chắc chắn xóa không?", " Thông báo", MessageBoxButtons.OKCancel);
            if (ret == DialogResult.OK)
            {
                //Bước 1
                SqlConnection con = new SqlConnection(sCon);

                try
                {
                    con.Open();
                }
                catch (Exception)
                {
                    MessageBox.Show("Xảy ra lỗi trong quá trình kết nối DB");
                }
                //Bước 2 lấy giá trị 
                string sDMaTK = txtDMaKH.Text;

                string sQuery = "delete TaiKhoan where matk = @matk";

                SqlCommand cmd = new SqlCommand(sQuery, con);
                cmd.Parameters.AddWithValue("MaTK", sDMaTK);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành công !");
                }
                catch (Exception )
                {
                    MessageBox.Show("Xảy ra lỗi tỏng quá trình xóa !");
                }
                con.Close(); //Bước 3 



            }
        }

        private void btnHuyDQLTK_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn chắc chắn thoát? ", "Thông báo");
        }

        private void DQLTK_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sCon);
            try
            {
                con.Open();
            }
            catch (Exception )
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình kết nối DB");
            }
            //Bước 2 - lấy dữ liệu về 
            string sQuery = "select * from TaiKhoan ";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);

            DataSet ds = new DataSet();
            adapter.Fill(ds, "TaiKhoan ");
            dataGridView1.DataSource = DataSet.Tables["TaiKhoan"] ;

            con.Close(); //Bước 3 
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            txtDMaTK.Text = dataGridView1.Rows[e.RowIndex].Cells["MaTK"].Value.ToString();
            txtDMaKH.Text = dataGridView1.Rows[e.RowIndex].Cells["MaKH"].Value.ToString();
            txtDTenDNKH.Text = dataGridView1.Rows[e.RowIndex].Cells["Tendangnhap"].Value.ToString();
            txtDMatKhau.Text = dataGridView1.Rows[e.RowIndex].Cells["Matkhau"].Value.ToString();
            txtDMaNV.Text = dataGridView1.Rows[e.RowIndex].Cells["Manv"].Value.ToString();
            txtDMaTK.Enabled = false;
        }
    }
}
