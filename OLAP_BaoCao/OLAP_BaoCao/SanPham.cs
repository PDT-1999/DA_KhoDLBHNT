using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OLAP_BaoCao
{
    public partial class SanPham : Form
    {
        public SanPham()
        {
            InitializeComponent();
        }

        DataProvide data = new DataProvide();

        public void loaddulieusanpham()
        {
            SqlDataAdapter da = data.getDa("select * from " + data.getServer() + "baohiemnhantho.dbo.sanpham");
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            data.close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn thêm?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                string sql = "insert into " + data.getServer() + "BaoHiemNhanTho.dbo.SanPham values('" + txtMaSP.Text + "', N'" + txtTenSP.Text + "', N'" + txtDoTuoiThamGia.Text + "', '" + txtMaLoaiBH.Text + "', " + int.Parse(txtGiaSP.Text) + ")";
                data.ThemXoaSua(sql);
            }
        }

        private void SanPham_Load(object sender, EventArgs e)
        {
            loaddulieusanpham();
        }
    }
}
