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
    public partial class CQLTK : Form
    {
        string sCon = "Data Source=DESKTOP-74S139L;Initial Catalog=HTQLYMKT;Intergrated Security=True";
        public CQLTK()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CQLTK_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Xin Chào, Hẹn gặp lại lần sau !","Thông báo");
        }

        private void btnTaoTK_Click(object sender, EventArgs e)
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
            //Bước 2
            //Chuẩn bị dữ liệu 
            //Kiểm tra tính hợp lệ của dữ liệu 
            //gán dữ liệu vào biến 

            string sMaTK = txtMaTK.Text;
            string sMaKH = txtMaKH.Text;
            string sTenDN = txtTenDN.Text;
            string sMatKhau = txtMatKhau.Text;
            string sMaNV = txtMaNV.Text;

            string sQuery = " insert into TaiKhoan values(@matk, @makh,@tendn, @matkhau, @manv)";
            SqlCommand cmd = new SqlCommand(sQuery, con);
            cmd.Parameters.AddWithValue("@matk", sMaTK);
            cmd.Parameters.AddWithValue("@makh", sMaKH);
            cmd.Parameters.AddWithValue("@tendn", sTenDN);
            cmd.Parameters.AddWithValue("@matkhau", sMatKhau);
            cmd.Parameters.AddWithValue("@manv", sMaNV);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm mới thành công !");
            }
            catch (Exception )
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình thêm mới!");
            }
            con.Close();

            
        }

        private void CQLTK_Load(object sender, EventArgs e)
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
    }
}
