using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace OLAP_BaoCao
{
    public class DataProvide
    {
        private SqlDataAdapter da;
        private SqlConnection cn;

        String ketnoi = "Data Source=DESKTOP-94L67MH; Initial Catalog=BaoHiemNhanTho_Dim; User ID=sa; Password=123456";
        Menu f = new Menu();

        public SqlDataAdapter getDa(String sql) {
            cn = new SqlConnection(ketnoi);
            cn.Open();
            SqlCommand cmd = new SqlCommand(sql, cn);
            da = new SqlDataAdapter(cmd);
            return da;
        }

        public void close() {
            this.cn.Close();
        }

        public String getServer()
        {
            return f.server();
        }

        public void ThemXoaSua(String sql)
        {
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            cn.Close();
        }
    }
}
