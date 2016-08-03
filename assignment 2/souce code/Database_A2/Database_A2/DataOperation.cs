using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Database_A2
{
    class DataOperation
    {
        static SqlConnection con;
        public static SqlConnection createCon()
        {
            con = new SqlConnection("server=JAKE-PC;uid=sa;pwd=sql2014;database=Hotel_database");
            return con;
        }
        public static bool execSQL(string sql)
        {
            SqlConnection con = createCon();
            con.Open();
            SqlCommand com = new SqlCommand(sql, con);
            try
            {
                com.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                con.Close();
                return false;
            }
            return true;
        }

        public static SqlDataReader getRow(string sql)
        {
            SqlConnection con = createCon();
            con.Open();
            SqlCommand com = new SqlCommand(sql, con);
            return com.ExecuteReader();
            con.Close();
        }
    }
}
