using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTQLMKT1
{
    public partial class DQLDV : Form
    {
        string sCon = "Data Source=DESKTOP-74S139L;Initial Catalog = HTQLYMKT1; Integrated Security = True;";
        public DQLDV()
        {
            
            InitializeComponent();
        }

       
        private void DQLDV_Load(object sender, EventArgs e)
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

        }

        private void btnXoa_Click(object sender, EventArgs e)
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

            //Bước 2:
            //Lấy giá trị
            string sMaDV = txtMaDV.Text;

            string sQuery = "delete DICHVUMKT where MADVMKT = @MaDV";

            SqlCommand cmd = new SqlCommand(sQuery, con);
            cmd.Parameters.AddWithValue("@MaDV", sMaDV);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công");


                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["MADVMKT"].Value.ToString() == sMaDV)
                    {
                        dataGridView1.Rows.Remove(row);
                        break; // Dừng sau khi xóa dòng
                    }
                }

                // Xóa các ô nhập liệu
                txtMaDV.Clear();
                txtTenDV.Clear();
                txtChiPhi.Clear();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình xóa!");
            }



            con.Close(); //Bước 3
        }

        
        
        private void button1_Click(object sender, EventArgs e)
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
