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
    public partial class UQLNV : Form
    {
        string sCon = "Data Source=LAPTOP-C240ING2\\MSSQLSERVER_DEV;Initial Catalog=HTQLYMKT;Integrated Security=True;TrustServerCertificate=True";
        public UQLNV()
        {
            InitializeComponent();
        }
        private void UQLNV_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Bạn đã đóng form chỉnh sửa thông tin nhân viên.", "Thông báo");
        }
        private void UQLNV_Load(object sender, EventArgs e)
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

            txtMANV.Enabled = false;
            txtMATK.Enabled = false;
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string sMANV = txtMANV.Text.Trim();
            string sHOTEN = txtHOTEN.Text.Trim();
            string sMATK = txtMATK.Text.Trim();
            string sSDT = txtSDT.Text.Trim();
            string sNGSINH = dtpNGSINH.Value.ToString("yyyy-MM-dd");
            string sDIACHI = txtDIACHI.Text.Trim();

            // Kiểm tra độ dài và định dạng

            if (sSDT.Length != 10 || !sSDT.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại phải có đúng 10 chữ số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra họ tên không được để trống
            if (string.IsNullOrWhiteSpace(sHOTEN))
            {
                MessageBox.Show("Họ tên không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime ngaySinh;
            if (!DateTime.TryParse(sNGSINH, out ngaySinh) || ngaySinh > DateTime.Now)
            {
                MessageBox.Show("Ngày sinh không hợp lệ. Vui lòng chọn ngày nhỏ hơn hoặc bằng ngày hiện tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Kiểm tra số điện thoại có bị trùng không
            string queryCheck = @"
            IF EXISTS (SELECT 1 FROM NhanVien WHERE SDT = @SDT AND MANV != @MANV)
                SELECT N'Số điện thoại đã tồn tại' AS Message;
            ELSE
                SELECT 'OK' AS Message;";

            using (SqlConnection con = new SqlConnection(sCon))
            {
                try
                {
                    con.Open();

                    // Kiểm tra trùng lặp
                    using (SqlCommand cmdCheck = new SqlCommand(queryCheck, con))
                    {
                        cmdCheck.Parameters.AddWithValue("@SDT", sSDT);
                        cmdCheck.Parameters.AddWithValue("@MANV", sMANV); // Đảm bảo không kiểm tra số điện thoại của chính nhân viên

                        string result = cmdCheck.ExecuteScalar().ToString();
                        if (result != "OK")
                        {
                            MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Câu lệnh SQL UPDATE
                    string sQuery = "UPDATE NhanVien SET SDT = @SDT, HOTEN = @HOTEN, NGSINH = @NGSINH, DIACHI = @DIACHI WHERE MANV = @MANV";

                    using (SqlCommand cmd = new SqlCommand(sQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@MANV", sMANV);
                        cmd.Parameters.AddWithValue("@HOTEN", sHOTEN);
                        cmd.Parameters.AddWithValue("@MATK", sMATK);  // Bạn có thể sử dụng MATK nếu cần
                        cmd.Parameters.AddWithValue("@SDT", sSDT);
                        cmd.Parameters.AddWithValue("@NGSINH", sNGSINH);
                        cmd.Parameters.AddWithValue("@DIACHI", sDIACHI);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            RefreshDataGridView();
                        }
                        else
                        {
                            MessageBox.Show("Không có dữ liệu nào được cập nhật. Kiểm tra lại mã nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xảy ra lỗi trong quá trình cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void RefreshDataGridView()
        {
            using (SqlConnection con = new SqlConnection(sCon))
            {
                try
                {
                    con.Open();
                    string sQuery = "SELECT * FROM NhanVien";
                    SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "NhanVien");
                    dataGridView1.DataSource = ds.Tables["NhanVien"];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xảy ra lỗi khi tải lại dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UQLNV_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Bạn đã đóng form chỉnh sửa thông tin nhân viên.", "Thông báo");
        }
    }
    
}
