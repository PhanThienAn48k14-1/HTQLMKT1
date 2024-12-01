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

        private void xemThôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RTTCN rTTCN = new RTTCN();
            rTTCN.MdiParent = this;
            rTTCN.Show();
        }

        private void sửaThôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UTTCN uTTCN = new UTTCN();
            uTTCN.MdiParent = this;
            uTTCN.Show();
        }

        private void xóaThôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DTTCN dTTCN = new DTTCN();
            dTTCN.MdiParent = this;
            dTTCN.Show();
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
    }
}
