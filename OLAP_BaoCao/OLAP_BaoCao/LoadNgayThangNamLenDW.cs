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
    public partial class LoadNgayThangNamLenDW : Form
    {
        public LoadNgayThangNamLenDW()
        {
            InitializeComponent();
        }

        DataProvide data = new DataProvide();

        public void loaddulieu() {
            SqlDataAdapter da = data.getDa("select * from baohiemnhantho_dim.dbo.dim_ngay");
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            data.close();
        }

        private void LoadNgayThangNamLenDW_Load(object sender, EventArgs e)
        {
            loaddulieu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn thêm?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                String sql = "set dateformat dmy declare @i int, @date datetime; set @i = 1; set @date = '" + txtNgayThangNam.Text.Trim() + "'; while @i <= 365 begin insert into baohiemnhantho_dim.dbo.Dim_Ngay values (@date, DAY(@date), MONTH(@date), YEAR(@date)); set @date = @date + 1; set @i = @i + 1; end;";
                data.ThemXoaSua(sql);
                loaddulieu();
            }
        }
    }
}
