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
    public partial class LoadChiNhanhLenDW : Form
    {
        public LoadChiNhanhLenDW()
        {
            InitializeComponent();
        }

        DataProvide data = new DataProvide();

        public void loaddulieu() {
            SqlDataAdapter da = data.getDa("select * from baohiemnhantho_dim.dbo.dim_chinhanh");
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            data.close();
        }

        public DataTable dt() {
            SqlDataAdapter da = data.getDa("select * from " + data.getServer() + "BaoHiemNhanTho.dbo.ChiNhanh where macn not in (select macn from BaoHiemNhanTho_Dim.dbo.Dim_ChiNhanh)");
            DataTable dt = new DataTable();
            da.Fill(dt);
            data.close();
            return dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn cập nhật?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                foreach (DataRow row in dt().Rows)
                {
                    String sql = "insert into baohiemnhantho_dim.dbo.dim_chinhanh values('" + row["MaCN"].ToString().Trim() + "', N'" + row["Tenchinhanh"].ToString().Trim() + "', N'" + row["Khuvuc"].ToString().Trim() + "', N'" + row["TinhTP"].ToString().Trim() + "', N'" + row["Diachi"].ToString().Trim() + "', '" + row["SDT"].ToString().Trim() + "')";
                    data.ThemXoaSua(sql);
                }
                loaddulieu();
                button1.Enabled = false;
            }
        }

        private void LoadChiNhanhLenDW_Load(object sender, EventArgs e)
        {
            loaddulieu();
        }
    }
}
