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
    public partial class NhanVien : Form
    {
        public NhanVien()
        {
            InitializeComponent();
        }

        private void xemThôngTinNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RQLNV  rQLNV = new RQLNV();
            rQLNV.MdiParent = this;
            rQLNV.Show();

            var rqlnv = new RQLNV(); // Tạo đối tượng form mới
            rqlnv.Show(); // Hiển thị form mới
            this.Hide(); // Ẩn form hiện tại
        }

        private void tạoThêmThôngTinKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CQLKH cQLKH = new CQLKH();
            cQLKH.MdiParent = this;
            cQLKH.Show();
        }

        private void xemThôngTinKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RQLKH rQLKH = new RQLKH();
            rQLKH.MdiParent = this;
            rQLKH.Show();
        }

        private void sửaThôngTinKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UQLKH uQLKH = new UQLKH();
            uQLKH.MdiParent = this;
            uQLKH.Show();

        }

        private void xóaThôngTinKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DQLKH dQLKH = new DQLKH();
            dQLKH.MdiParent = this;
            dQLKH.Show();
        }

        private void tạoThêmThôngTinNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CQLNV cQLNV = new CQLNV();
            cQLNV.MdiParent = this;
            cQLNV.Show();

            var cqlnv = new CQLNV(); // Tạo đối tượng form mới
            cqlnv.Show(); // Hiển thị form mới
            this.Hide(); // Ẩn form hiện tại


        }

        private void sửaThôngTinNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UQLNV uQLNV = new UQLNV();
            uQLNV.MdiParent = this;
            uQLNV.Show();

            var uqlnv = new UQLNV();
            uqlnv.Show();
            this.Hide();
        }

        private void xóaThôngTinNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DQLNV dQLNV = new DQLNV();
            dQLNV.MdiParent = this;
            dQLNV.Show();

            var dqlnv = new DQLNV();
            dqlnv.Show();
            this.Hide();
        }

        private void tạoThêmThôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CQLTK cQLK = new CQLTK();
            cQLK.MdiParent = this;
            cQLK.Show();
        }

        private void xemThôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RQLTK rQLTK = new RQLTK();
            rQLTK.MdiParent = this;
            rQLTK.Show();
        }

        private void sửaThôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UQLTK uQLTK = new UQLTK();
            uQLTK.MdiParent = this;
            uQLTK .Show();
        }

        private void xóaThôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DQLTK dQLTK = new DQLTK();
            dQLTK .MdiParent = this;
            dQLTK .Show();
        }

        private void tạoThêmHợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CQLHD cQLHD = new CQLHD();
            cQLHD .MdiParent = this;
            cQLHD .Show();
        }

        private void xemThôngTinHợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RQLHD rQLHD = new RQLHD();
            rQLHD .MdiParent = this;
            rQLHD .Show();
        }

        private void sửaThôngTinHợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UQLHD uQLHD = new UQLHD();
            uQLHD .MdiParent = this;
            uQLHD .Show();
        }

        private void xóaThôngTinHợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DQLHD dQLHD = new DQLHD();
            dQLHD .MdiParent = this;
            dQLHD .Show();
        }

        private void tạoThêmDịchVụMarketingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CQLDV cQLDV = new CQLDV();
            cQLDV .MdiParent = this;
            cQLDV .Show();
        }

        private void xemThôngTinDịchVụMarketingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RQLDV rQLDV = new RQLDV();
            rQLDV .MdiParent = this;
            rQLDV .Show();
        }

        private void sửaThôngTinDịchVụMarketingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UQLDV uQLDV = new UQLDV();
            uQLDV .MdiParent = this;
            uQLDV .Show();
        }

        private void xóaDịchVụMarketingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DQLDV dQLDV = new DQLDV();
            dQLDV .MdiParent = this;
            dQLDV .Show();
        }
    }
}
