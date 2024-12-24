using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //Bước 0: Khai báo thư viện

namespace HTQLMKT1
{
    public partial class CQLDV : Form
    {
        String sCon = "Data Source=DESKTOP-74S139L;Initial Catalog = HTQLYMKT1; Integrated Security = True;";
        public CQLDV()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {}

        private void label3_Click(object sender, EventArgs e)
        {}

        private void CQLDV_Load(object sender, EventArgs e)
        {
            //Bước 1: Thiết lập kết nối CSDL
            SqlConnection con = new SqlConnection(sCon);
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình kết nối DB");
            }



        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sCon);

            try
            {
                using (SqlConnection conn = new SqlConnection(sCon))
                {
                    conn.Open();

                    // Câu lệnh SQL để lấy mã dịch vụ lớn nhất hiện có
                    string selectQuery = "select max(MADVMKT) from DICHVUMKT where MADVMKT like 'DV%';";
                    using (SqlCommand selectCmd = new SqlCommand(selectQuery, conn))
                    {
                        object result = selectCmd.ExecuteScalar();
                        string maxCode = result != DBNull.Value ? result.ToString() : "DV00000000";

                        // Tách phần số từ mã dịch vụ hiện tại
                        int maxNumber = int.Parse(maxCode.Substring(2));

                        // Tạo mã dịch vụ mới
                        string newCode;
                        while (true)
                        {
                            maxNumber++;
                            newCode = "DV" + maxNumber.ToString("D8");

                            // Kiểm tra xem mã dịch vụ mới đã tồn tại hay chưa
                            string checkQuery = "SELECT COUNT(*) FROM DICHVUMKT WHERE MADVMKT = @NewCode;";
                            using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                            {
                                checkCmd.Parameters.AddWithValue("@NewCode", newCode);
                                int exists = (int)checkCmd.ExecuteScalar();
                                if (exists == 0)
                                {
                                    break; // Nếu không tồn tại, thoát khỏi vòng lặp
                                }
                            }
                        }

                        // Gán dữ liệu vào biến
                        string sMaDV = newCode;
                        string sTenDV = txtTenDV.Text;
                        string sChiPhi = txtChiPhi.Text;

                        // Kiểm tra đầu vào
                        if (string.IsNullOrEmpty(sTenDV) || string.IsNullOrEmpty(sChiPhi))
                        {
                            MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Thực hiện câu lệnh chèn dữ liệu
                        string insertQuery = "insert into DICHVUMKT values (@MADVMKT, @TENDV, @CHIPHI);";
                        using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                        {
                            insertCmd.Parameters.AddWithValue("@MADVMKT", sMaDV);
                            insertCmd.Parameters.AddWithValue("@TENDV", sTenDV);
                            insertCmd.Parameters.AddWithValue("@CHIPHI", sChiPhi);

                            int rowsAffected = insertCmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Dữ liệu đã được thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Cập nhật DataGrid
                                UpdateDataGrid(conn);
                            }
                            else
                            {
                                MessageBox.Show("Không thể thêm dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateDataGrid(SqlConnection conn)
        {
            try
            {
                string selectQuery = "select * from DICHVUMKT;";
                using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    System.Data.DataTable dataTable = new System.Data.DataTable();
                    adapter.Fill(dataTable);

                    // Giả sử bạn có DataGridView tên là dataGridView1
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể tải dữ liệu vào DataGrid: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Form dNhanVien = Application.OpenForms.OfType<NhanVien>().FirstOrDefault();
            if (dNhanVien != null)
            {
                dNhanVien.Show();
            }
            else
            {
                dNhanVien = new NhanVien();
                dNhanVien.Show();
            } 
            this.Hide();
            
        }
        private void CQLDV_Click(object sender, EventArgs e)
        {}
    }
}




  