using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTapDe02
{
    internal class LOPDUNGCHUNG
    {
        SqlConnection conn;
        string chuoikn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Code_Space\OnTapDe02\OnTapDe02\QLNHANVIEN.mdf;Integrated Security=True";
        public LOPDUNGCHUNG()
        {
            conn = new SqlConnection(chuoikn);
        }
        public int ThemSuaXoa (string sql)
        {
            SqlCommand comm = new SqlCommand(sql, conn);
            conn.Open();
            int kq = comm.ExecuteNonQuery();
            conn.Close();
            return kq;
        }
        public object LayGT (string sql)
        {
            SqlCommand comm = new SqlCommand(sql, conn);
            conn.Open();
            object kq = comm.ExecuteScalar();
            conn.Close();
            return kq;
        }
        public DataTable LoadDL (string sql)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
