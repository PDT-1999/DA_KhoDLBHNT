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
    public partial class HoaDon : Form
    {
        public HoaDon()
        {
            InitializeComponent();
        }

        DataProvide data = new DataProvide();

        public void loaddulieu()
        {
            SqlDataAdapter da = data.getDa("select hd.MaHD, MaKH_MBM, MaNV, NgayThangNam, HinhThucDongTienBH, MaSP, ThoiHanBH, ThoiHanDongTien, PhiTienBH, SoTienCanDong, TongTienBH from " + data.getServer() + "baohiemnhantho.dbo.hoadon hd, " + data.getServer() + "baohiemnhantho.dbo.chitiethoadon cthd where hd.mahd = cthd.mahd");
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            data.close();
        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            loaddulieu();
        }

        private void button_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn thêm?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                String mahd = txtMaHD.Text.Trim();
                String makh_mbm = txtMaKH_MBM.Text.Trim();
                String manv = txtMaNV.Text.Trim();
                String ngaythangnam = txtNgayThangNam.Text.Trim();
                String hinhthucdongtienbh = txtHinhThucDongTienBH.Text.Trim();
                String masp = txtMaSP.Text.Trim();
                int thoihanbh = int.Parse(txtThoiHanBH.Text.Trim());
                int thoihandongtien = int.Parse(txtThoiHanDongTien.Text.Trim());
                int phitienbh = int.Parse(txtPhiTienBH.Text.Trim());
                int sotiencandong = int.Parse(txtSoTienCanDong.Text.Trim());
                int tongtienbh = int.Parse(txtTongTienBH.Text.Trim());
                String sql1 = "set dateformat dmy insert into " + data.getServer() + "baohiemnhantho.dbo.hoadon values('" + mahd + "', '" + makh_mbm + "', '" + manv + "', '" + ngaythangnam + "', N'" + hinhthucdongtienbh + "')";
                String sql2 = "insert into " + data.getServer() + "baohiemnhantho.dbo.chitiethoadon values('" + mahd + "', '" + masp + "', " + thoihanbh + ", " + thoihandongtien + ", " + phitienbh + ", " + sotiencandong + ", " + tongtienbh + ")";
                data.ThemXoaSua(sql1);
                data.ThemXoaSua(sql2);
                loaddulieu();
            }
        }   
    }
}
