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
    public partial class DQLHD : Form
    {
        public DQLHD()
        {
            InitializeComponent();
        }

        private void btnXOA_Click(object sender, EventArgs e)
        {
            //Bước 1
            string sCon = "Data Source=DESKTOP-74S139L;Initial Catalog = HTQLYMKT1; Integrated Security = True;";
            SqlConnection con = new SqlConnection(sCon);
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Xảy ra lỗi trong quá trình kết nối DB");
            }

            string sMAHD=txtDMAHD.Text;
            if ( sMAHD.Length > 10)
            {
                MessageBox.Show("Mã hợp đồng không hợp lệ");
                return;
            }
            string sQuery = "DELETE FROM HopDong where MAHD=@MAHD";
            SqlCommand cmd = new SqlCommand(sQuery, con);
            cmd.Parameters.AddWithValue("@MAHD", sMAHD);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa hợp đồng thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("xảy ra lỗi trong quá trình xóa hợp đồng" + ex.Message);
            }
            con.Close();
        }
    }
}
