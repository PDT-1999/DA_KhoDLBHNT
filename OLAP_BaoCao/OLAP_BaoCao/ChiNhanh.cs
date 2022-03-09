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
    public partial class ChiNhanh : Form
    {
        public ChiNhanh()
        {
            InitializeComponent();
        }

        DataProvide data = new DataProvide();

        public void loaddulieu() {
            SqlDataAdapter da = data.getDa("select * from "+data.getServer()+"baohiemnhantho.dbo.chinhanh");
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            data.close();
        }

        private void ChiNhanh_Load(object sender, EventArgs e)
        {
            loaddulieu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn thêm?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                String macn = txtMaCN.Text.Trim();
                String tencn = txtTenCN.Text.Trim();
                String khuvuc = txtKhuVuc.Text.Trim();
                String tinhtp = txtTinhTP.Text.Trim();
                String diachi = txtDiaChi.Text.Trim();
                String sdt = txtSDT.Text.Trim();
                string sql = "insert into " + data.getServer() + "baohiemnhantho.dbo.chinhanh values('" + macn + "', N'" + tencn + "', N'" + khuvuc + "', N'" + tinhtp + "', N'" + diachi + "', '" + sdt + "')";
                data.ThemXoaSua(sql);
                loaddulieu();
            }
        }
    }
}
