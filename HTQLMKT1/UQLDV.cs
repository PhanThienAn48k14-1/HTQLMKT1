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
    public partial class UQLDV : Form
    {
        String sCon = "Data Source=DESKTOP-74S139L;Initial Catalog = HTQLYMKT1; Integrated Security = True;";
        public UQLDV()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {}

        private void label1_Click(object sender, EventArgs e)
        {}


        private void UQLDV_Load(object sender, EventArgs e)
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

            //Bước 2.2: Lấy dữ liệu về
            string sQuery = "select * from DICHVUMKT";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);

            DataSet ds = new DataSet();

            adapter.Fill(ds, "DICHVUMKT");

            dataGridView1.DataSource = ds.Tables["DICHVUMKT"];

            con.Close(); //Bước 3
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaDV.Text = dataGridView1.Rows[e.RowIndex].Cells["MADVMKT"].Value.ToString();
            txtTenDV.Text = dataGridView1.Rows[e.RowIndex].Cells["TENDV"].Value.ToString();
            txtChiPhi.Text = dataGridView1.Rows[e.RowIndex].Cells["CHIPHI"].Value.ToString();

            txtMaDV.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //Bước 1
            SqlConnection con = new SqlConnection(sCon);
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình kết nối DB");
            }

            //Bước 2
            //Lấy giá trị 
            string sMaDV = txtMaDV.Text;
            string sTenDV = txtTenDV.Text;
            string sChiPhi = txtChiPhi.Text;

            string sQuery = "update DICHVUMKT set TENDV = @TenDV , CHIPHI = @ChiPhi where MADVMKT = @MaDVMKT";
            SqlCommand cmd = new SqlCommand(sQuery, con);

            cmd.Parameters.AddWithValue("@MaDVMKT", sMaDV);
            cmd.Parameters.AddWithValue("@TenDV", sTenDV);
            cmd.Parameters.AddWithValue("@ChiPhi", sChiPhi);


            /*try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình cập nhật");
            }*/

            try
            {
                int rowsAffected = cmd.ExecuteNonQuery(); // Kiểm tra số dòng bị ảnh hưởng
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cập nhật thành công!");

                    // Bước 4: Cập nhật lại DataGridView
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells["MADVMKT"].Value.ToString() == sMaDV) // Kiểm tra mã dịch vụ
                        {
                            row.Cells["TENDV"].Value = sTenDV; // Cập nhật tên dịch vụ
                            row.Cells["CHIPHI"].Value = sChiPhi; // Cập nhật chi phí
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã dịch vụ để cập nhật!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình cập nhật: " + ex.Message);
            }

            con.Close(); //Bước 3
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
    }
}

