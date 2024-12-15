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
    public partial class DQLNV : Form
    {
        string sCon = "Data Source=LAPTOP-C240ING2\\MSSQLSERVER_DEV;Initial Catalog=HTQLYMKT;Integrated Security=True;TrustServerCertificate=True";
        public DQLNV()
        {
            InitializeComponent();
        }
        
        private void DQLNV_Load(object sender, EventArgs e)
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMANV.Text = dataGridView1.Rows[e.RowIndex].Cells["MANV"].Value.ToString();
            txtHOTEN.Text = dataGridView1.Rows[e.RowIndex].Cells["HOTEN"].Value.ToString(); ;
            txtMATK.Text = dataGridView1.Rows[e.RowIndex].Cells["MATK"].Value.ToString(); ;
            txtSDT.Text = dataGridView1.Rows[e.RowIndex].Cells["SDT"].Value.ToString(); ;
            dtpNGSINH.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["NGSINH"].Value);
            txtDIACHI.Text = dataGridView1.Rows[e.RowIndex].Cells["DIACHI"].Value.ToString(); ;

        }

        //private void btnXOA_Click(object sender, EventArgs e)
        //{
        //    //buoc1


        //    SqlConnection con = new SqlConnection(sCon);
        //    try
        //    {
        //        con.Open();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Xảy ra lỗi trong quá trình kết nối Database!!!");
        //    }
        //    //bước 2
        //    string sMANV=txtMANV.Text;

        //    string sQuery = "delete from NhanVien where MANV=@MANV";

        //    SqlCommand cmd = new SqlCommand(sQuery, con);
        //    cmd.Parameters.AddWithValue("@MANV", sMANV);
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        MessageBox.Show("Xóa thành công!");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Xảy ra lỗi trong quá trình xóa!");
        //    }

        //    con.Close();//buoc3
        //}
        private void btnXOA_Click(object sender, EventArgs e)
        {
            // Bước 1: Kiểm tra mã nhân viên
            string sMANV = txtMANV.Text;
            if (string.IsNullOrWhiteSpace(sMANV))
            {
                MessageBox.Show("Vui lòng chọn mã nhân viên cần xóa.");
                return;
            }

            // Bước 2: Khởi tạo kết nối
            SqlConnection con = new SqlConnection(sCon);
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình kết nối Database!!! Lỗi: " + ex.Message);
                return;
            }

            // Tăng thời gian chờ (timeout) để xử lý các truy vấn lâu
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandTimeout = 180; // Thời gian chờ 3 phút

            // Bước 3: Bắt đầu giao dịch (Transaction)
            SqlTransaction transaction = con.BeginTransaction();
            try
            {
                // Xóa dữ liệu trong bảng TaiKhoan liên quan đến MANV
                string queryDeleteTaiKhoan = "DELETE FROM TaiKhoan WHERE MANV = @MANV";
                SqlCommand cmdDeleteTaiKhoan = new SqlCommand(queryDeleteTaiKhoan, con, transaction);
                cmdDeleteTaiKhoan.Parameters.AddWithValue("@MANV", sMANV);
                cmdDeleteTaiKhoan.ExecuteNonQuery();

                // Xóa dữ liệu trong bảng HopDong liên quan đến MANV
                string queryDeleteHopDong = "DELETE FROM HopDong WHERE MANV = @MANV";
                SqlCommand cmdDeleteHopDong = new SqlCommand(queryDeleteHopDong, con, transaction);
                cmdDeleteHopDong.Parameters.AddWithValue("@MANV", sMANV);
                cmdDeleteHopDong.ExecuteNonQuery();

                // Xóa dữ liệu trong bảng NhanVien
                string queryDeleteNV = "DELETE FROM NhanVien WHERE MANV = @MANV";
                SqlCommand cmdDeleteNV = new SqlCommand(queryDeleteNV, con, transaction);
                cmdDeleteNV.Parameters.AddWithValue("@MANV", sMANV);
                cmdDeleteNV.ExecuteNonQuery();

                // Cam kết (commit) giao dịch
                transaction.Commit();

                MessageBox.Show("Xóa thành công!");

                // Cập nhật lại DataGridView
                RefreshDataGridView(); // Làm mới dữ liệu trong DataGridView
                                       // Xóa (reset) các ô nhập liệu
                ResetFields();
            }
            catch (Exception ex)
            {
                // Hủy giao dịch nếu có lỗi
                transaction.Rollback();
                MessageBox.Show("Xảy ra lỗi trong quá trình xóa! Lỗi: " + ex.Message);
            }
            finally
            {
                con.Close(); // Đảm bảo kết nối được đóng
            }
        }
        private void RefreshDataGridView()
        {
            // Khởi tạo kết nối và tải lại dữ liệu từ cơ sở dữ liệu
            SqlConnection con = new SqlConnection(sCon);
            try
            {
                con.Open();
                string sQuery = "SELECT * FROM NhanVien"; // Truy vấn lại bảng NhanVien
                SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "NhanVien");
                dataGridView1.DataSource = ds.Tables["NhanVien"]; // Cập nhật dữ liệu vào DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi khi tải lại dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close(); // Đảm bảo kết nối được đóng
            }
        }
        private void ResetFields()
        {
            // Làm sạch tất cả các ô nhập liệu
            txtMANV.Clear();
            txtHOTEN.Clear();
            txtMATK.Clear();
            txtSDT.Clear();
            txtDIACHI.Clear();
            dtpNGSINH.Value = DateTime.Now;  // Đặt lại ngày sinh về ngày hiện tại
        }

        private void DQLNV_FormClosing_1(object sender, FormClosingEventArgs e)
        {

            //MessageBox.Show("Bạn đã đóng form xóa thông tin nhân viên.", "Thông báo");
        }

        private void btnBACK_Click(object sender, EventArgs e)
        {
            // Đóng form hiện tại (CQLNV)
            this.Close();

            // Tạo và hiển thị form NhanVien
            NhanVien frmNhanVien = new NhanVien();
            frmNhanVien.Show();
        }
    }
}
