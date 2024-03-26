using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTapDe01
{
    internal class LOPDUNGCHUNG
    {
        SqlConnection conn;
        string chuoikn= @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Code_Space\OnTapDe01\OnTapDe01\Database.mdf;Integrated Security=True";
        public LOPDUNGCHUNG()
        {
            conn = new SqlConnection(chuoikn);
        }
        public int ThemXoaSua(string sql)
        {
            SqlCommand comm = new SqlCommand(sql, conn);
            conn.Open(); 
            int kq =comm.ExecuteNonQuery();
            conn.Close();
            return kq;
        }
        public object LayGT(String sql)
        {
            SqlCommand comm = new SqlCommand(sql, conn);
            conn.Open();
            object kq = comm.ExecuteNonQuery();
            conn.Close();
            return kq;
        }
        public DataTable LoadDL(String sql)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
