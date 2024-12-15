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

        private void xemThôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var XemTTKH = new RTTCN(username); // Truyền tên đăng nhập
            XemTTKH.Show();
            this.Hide();
        }

        // Trong KhachHang.cs
        private void sửaThôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var SuaTTKH = new UTTCN(username); // Truyền tên đăng nhập vào UTTCN
            SuaTTKH.Show();
            this.Hide();
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
            RTTDV rTTDV = new RTTDV();
            rTTDV.MdiParent = this;
            rTTDV.Show();
        }

        private void xemHợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RTTHD rTTHD = new RTTHD();
            rTTHD.MdiParent = this;
            rTTHD .Show();

        }

        private void KhachHang_Load(object sender, EventArgs e)
        {

        }

        private void BTNDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "Bạn có muốn đăng xuất không?", // Nội dung thông báo
            "Xác nhận đăng xuất",           // Tiêu đề thông báo
            MessageBoxButtons.YesNo,        // Hiển thị nút Yes và No
            MessageBoxIcon.Question         // Icon dấu hỏi
            );

            // Kiểm tra kết quả người dùng chọn
            if (result == DialogResult.Yes)
            {
                // Nếu chọn Yes thì thực hiện đăng xuất
                var DX = new FrmLogin();
                DX.Show();
                this.Hide();
            }
        }

        // Trong KhachHang.cs


    }
}
