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
    public partial class LoadSanPhamLenDW : Form
    {
        public LoadSanPhamLenDW()
        {
            InitializeComponent();
        }

        DataProvide data = new DataProvide();

        public void loaddulieu()
        {
            SqlDataAdapter da = data.getDa("select * from BaoHiemNhanTho_Dim.dbo.Dim_SanPham");
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            data.close();
        }

        private void LoadSanPhamLenDW_Load(object sender, EventArgs e)
        {
            loaddulieu();
        }

        public DataTable dt() {
            SqlDataAdapter da = data.getDa("select * from " + data.getServer() + "BaoHiemNhanTho.dbo.SanPham where masp not in (select masp from BaoHiemNhanTho_Dim.dbo.Dim_SanPham)");
            DataTable dt = new DataTable();
            da.Fill(dt);
            data.close();
            return dt;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn cập nhật?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                foreach (DataRow row in dt().Rows)
                {
                    String sql = "insert into BaoHiemNhanTho_Dim.dbo.Dim_SanPham values('" + row["MaSP"].ToString().Trim() + "', N'" + row["TenSP"].ToString().Trim() + "', N'" + row["DoTuoiThamGia"].ToString().Trim() + "', '" + row["MaLoaiBH"].ToString().Trim() + "', " + int.Parse(row["GiaSP"].ToString().Trim()) + ")";
                    data.ThemXoaSua(sql);
                }
                loaddulieu();
                btnThem.Enabled = false;
            }
        }
    }
}
