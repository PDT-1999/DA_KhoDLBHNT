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
    public partial class KH_MBM : Form
    {
        public KH_MBM()
        {
            InitializeComponent();
        }

        DataProvide data = new DataProvide();

        public void loaddulieu() {
            SqlDataAdapter da = data.getDa("select * from " + data.getServer() + "baohiemnhantho.dbo.kh_mbm");
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            data.close();
        }

        private void KH_MBM_Load(object sender, EventArgs e)
        {
            loaddulieu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn thêm?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                String makh_mbm = txtMaKH_MBM.Text.Trim();
                String tenkh_mbm = txtTenKH_MBM.Text.Trim();
                int namsinh = int.Parse(txtNamSinh.Text.Trim());
                String gioitinh = txtGioiTinh.Text.Trim();
                String diachi = txtDiaChi.Text.Trim();
                String cmnd = txtCMND.Text.Trim();
                String nghenghiep = txtNgheNghiep.Text.Trim();
                String doituongduocbaohiem = txtDoiTuongDuocBH.Text.Trim();
                String sql = "insert into " + data.getServer() + "baohiemnhantho.dbo.kh_mbm values('" + makh_mbm + "', N'" + tenkh_mbm + "', " + namsinh + ", N'" + gioitinh + "', N'" + diachi + "', '" + cmnd + "', N'" + nghenghiep + "', N'" + doituongduocbaohiem + "')";
                data.ThemXoaSua(sql);
                loaddulieu();
            }
        }
    }
}
