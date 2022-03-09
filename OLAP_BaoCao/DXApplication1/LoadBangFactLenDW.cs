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
    public partial class LoadBangFactLenDW : Form
    {
        public LoadBangFactLenDW()
        {
            InitializeComponent();
        }

        DataProvide data = new DataProvide();
        public void loaddulieu() {
            SqlDataAdapter da = data.getDa("select * from baohiemnhantho_dim.dbo.bhnt_fact");
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            data.close();
        }

        public DataTable dt() {
            SqlDataAdapter da = data.getDa("select NgayThangNam, MaSP, MaKH_MBM, MaCN, HinhThucDongTienBH, ThoiHanBH, ThoiHanDongTien, PhiTienBH, SoTienCanDong, TongTienBH from " + data.getServer() + "BaoHiemNhanTho.dbo.HoaDon hd, " + data.getServer() + "BaoHiemNhanTho.dbo.ChiTietHoaDon cthd, " + data.getServer() + "BaoHiemNhanTho.dbo.NhanVien nv where hd.mahd = cthd.mahd and hd.manv = nv.manv and  not exists(select 1 from BaoHiemNhanTho_Dim.dbo.BHNT_Fact f where f.NgayThangNam = hd.NgayThangNam and f.MaCN = nv.MaCN and f.MaKH_MBM = hd.MaKH_MBM and f.MaSP = cthd.MaSP)");
            DataTable dt = new DataTable();
            da.Fill(dt);
            data.close();
            return dt;
        }

        private void LoadBangFactLenDW_Load(object sender, EventArgs e)
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
                    String sql = "insert into baohiemnhantho_dim.dbo.bhnt_fact values('" + row["NgayThangNam"].ToString().Trim() + "', '" + row["MaSP"].ToString().Trim() + "', '" + row["MaKH_MBM"].ToString().Trim() + "', '" + row["MaCN"].ToString().Trim() + "', N'" + row["HinhThucDongTienBH"].ToString().Trim() + "', " + int.Parse(row["ThoiHanBH"].ToString().Trim()) + ", " + int.Parse(row["ThoiHanDongTien"].ToString().Trim()) + ", " + int.Parse(row["PhiTienBH"].ToString().Trim()) + ", " + int.Parse(row["SoTienCanDong"].ToString().Trim()) + ", " + int.Parse(row["TongTienBH"].ToString().Trim()) + ")";
                    data.ThemXoaSua(sql);
                }
                loaddulieu();
                button1.Enabled = false;
            }
        }
    }
}
