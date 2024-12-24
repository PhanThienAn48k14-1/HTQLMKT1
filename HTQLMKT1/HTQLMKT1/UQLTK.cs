using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;//Bước 0 

namespace HTQLMKT1
{
    public partial class UQLTK : Form
    {
        string sCon = "Data Source=DESKTOP-74S139L;Initial Catalog=HTQLYMKT;Intergrated Security=True";
        public UQLTK()
        {
            InitializeComponent();
        }

        private void btnUHuy_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn chắc chắn thoát ?");
        }

        private void btnUSua_Click(object sender, EventArgs e)
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
            //Bước 2: Lấy giá trị 
            string sUMaTK = txtUMaTK.Text;
            string sUMaKH = txtUMaKH.Text;
            string sUTenDNKH = txtUTenDNKH.Text;
            string sUMatKhau = txtUMatKhau.Text;
            string sUMaNV = txtUMaNV.Text;

            string sQuery = "update TaiKhoan set MaTK =@MaTK , MaKH =@MaKH "+" Tendangnhap = @Tendangnhap , MatKhau = @Matkhau "+" MaNV= @Manv, where matk = @matk" ;
            SqlCommand cmd = new SqlCommand(sQuery, con);
            cmd.Parameters.AddWithValue("@MaTK", sUMaTK);
            cmd.Parameters.AddWithValue("@MaTK", sUMaKH);
            cmd.Parameters.AddWithValue("@Tendangnhap", sUTenDNKH);
            cmd.Parameters.AddWithValue("@Matkhau",sUMatKhau );
            cmd.Parameters.AddWithValue("@Manv", sUMaNV);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật thành công!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi trong quá tình thêm mới! ");
            }
            con.Close();







        }

        private void UQLTK_Load(object sender, EventArgs e)
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
            txtUMaTK.Text = dataGridView1.Rows[e.RowIndex].Cells["MaTK"].Value.ToString();
            txtUMaKH.Text = dataGridView1.Rows[e.RowIndex].Cells["MaKH"].Value.ToString();
            txtUTenDNKH.Text = dataGridView1.Rows[e.RowIndex].Cells["Tendangnhap"].Value.ToString();
            txtUMatKhau.Text = dataGridView1.Rows[e.RowIndex].Cells["Matkhau"].Value.ToString();
            txtUMaNV.Text = dataGridView1.Rows[e.RowIndex].Cells["Manv"].Value.ToString();
            txtUMaTK.Enabled = false;
        }
    }
}
