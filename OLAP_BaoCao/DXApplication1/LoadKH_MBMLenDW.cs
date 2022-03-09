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
    public partial class LoadKH_MBMLenDW : Form
    {
        public LoadKH_MBMLenDW()
        {
            InitializeComponent();
        }

        DataProvide data = new DataProvide();

        public void loaddulieu() {
            SqlDataAdapter da = data.getDa("select * from baohiemnhantho_dim.dbo.dim_kh_mbm");
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            data.close();
        }

        public DataTable dt() {
            SqlDataAdapter da = data.getDa("select * from " + data.getServer() + "BaoHiemNhanTho.dbo.KH_MBM where makh_mbm not in (select makh_mbm from BaoHiemNhanTho_Dim.dbo.Dim_KH_MBM)");
            DataTable dt = new DataTable();
            da.Fill(dt);
            data.close();
            return dt;
        }

        private void LoadKH_MBMLenDW_Load(object sender, EventArgs e)
        {
            loaddulieu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn cập nhật?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                foreach (DataRow row in dt().Rows)
                {
                    String sql = "insert into baohiemnhantho_dim.dbo.dim_kh_mbm values('" + row["MaKH_MBM"].ToString().Trim() + "', N'" + row["TenKH_MBM"].ToString().Trim() + "', N'" + int.Parse(row["Namsinh"].ToString().Trim()) + "', N'" + row["GioiTinh"].ToString().Trim() + "', '" + row["DiaChi"].ToString().Trim() + "', N'" + row["CMND"].ToString().Trim() + "', N'" + row["NgheNghiep"].ToString().Trim() + "', N'" + row["NguoiDuocBaoHiem"].ToString().Trim() + "')";
                    data.ThemXoaSua(sql);
                }
                loaddulieu();
                button1.Enabled = false;
            }
        }
    }
}
