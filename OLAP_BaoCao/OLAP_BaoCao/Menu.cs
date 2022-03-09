using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OLAP_BaoCao
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void cSDLTácNghiệpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SanPham f = new SanPham();
            f.Show();
        }

        private void dataWarehouseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadSanPhamLenDW f = new LoadSanPhamLenDW();
            f.Show();
        }

        private void cSDLTácNghiệpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ChiNhanh f = new ChiNhanh();
            f.Show();
        }

        private void dataWarehouseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LoadChiNhanhLenDW f = new LoadChiNhanhLenDW();
            f.Show();
        }

        private void cSDLTácNghiệpToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            KH_MBM f = new KH_MBM();
            f.Show();
        }

        private void dataWarehouseToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            LoadKH_MBMLenDW f = new LoadKH_MBMLenDW();
            f.Show();
        }

        private void cSDLTácNghiệpToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            HoaDon f = new HoaDon();
            f.Show();
        }

        private void dataWarehouseToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            LoadBangFactLenDW f = new LoadBangFactLenDW();
            f.Show();
        }

        public String server() {
            if (nameServer.Equals("Server 1"))
                return "link.";
            else
                return "link1.";
        }

        public static String nameServer = "";
        
        private void Menu_Load(object sender, EventArgs e)
        {
            toolStripComboBox1.SelectedIndex = 0;
        }

        private void toolStripComboBox1_TextChanged(object sender, EventArgs e)
        {
            nameServer = toolStripComboBox1.SelectedItem.ToString().Trim();
        }

        private void ngàyThángNămFactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadNgayThangNamLenDW f = new LoadNgayThangNamLenDW();
            f.Show();
        }
    }
}
