using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTQLMKT1
{
    public partial class KhachHang : Form
    {
        public KhachHang()
        {
            InitializeComponent();
        }

        private string username; // Biến lưu tên đăng nhập

        public KhachHang(string sTenDN)
        {
            InitializeComponent();
            username = sTenDN; // Gán tên đăng nhập từ constructor
        }

        //private void xemThôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        //{
           
        //}

        // Trong KhachHang.cs
        private void sửaThôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }


        private void xóaThôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var XoaTTKH = new DTTCN(username); // Nếu DTTCN cũng cần username
            XoaTTKH.Show();
            this.Hide();
        }

        private void xemTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RTTTK rTTTK = new RTTTK();
            rTTTK.MdiParent = this;
            rTTTK.Show();
        }

        private void xemDịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void xemHợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }

        private void KhachHang_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            
        }

        private void XemTTCN_Click(object sender, EventArgs e)
        {
            var XemTTKH = new RTTCN(username); // Truyền tên đăng nhập
            XemTTKH.Show();
            this.Hide();
        }

        private void UTTCN_Click(object sender, EventArgs e)
        {
            var SuaTTKH = new UTTCN(username); // Truyền tên đăng nhập vào UTTCN
            SuaTTKH.Show();
            this.Hide();
        }

        private void RTTHD_Click(object sender, EventArgs e)
        {
            var XemTTHD= new RTTHD(username); // Truyền tên đăng nhập
            XemTTHD.Show();
            this.Hide();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            var XemTTDV = new RTTDV(username); // Truyền tên đăng nhập
            XemTTDV.Show();
            this.Hide();
        }
    }
}
