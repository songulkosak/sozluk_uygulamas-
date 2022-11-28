using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sozluk_uygulaması
{
    public class Database
    {
        string ConnectionString = "Server=DESKTOP-ER0GUQT\\SQLEXPRESS;Database=sozluk;Integrated Security=true;";
        SqlConnection SqlConnection;
        SqlCommand SqlCommand;

        public Database()
        {
            SqlConnection = new SqlConnection(ConnectionString);
        }

        public void KomutCalistir(string cmdText)
        {
            SqlConnection.Open();
            SqlCommand = new SqlCommand(cmdText,SqlConnection);
            SqlCommand.ExecuteNonQuery();
            SqlConnection.Close();
        }
        public void KomutCalistir(string cmdText,Dictionary<string,object>parameters)
        {
            SqlConnection.Open();
            SqlCommand = new SqlCommand(cmdText, SqlConnection);
            foreach (var item in parameters)
            {
                SqlCommand.Parameters.Add(new SqlParameter(item.Key, item.Value));
            }
            SqlCommand.ExecuteNonQuery();
            SqlConnection.Close();
        }

        public DataTable GetDataTable(string cmdText)
        {
            SqlConnection.Open();
            SqlDataAdapter dt = new SqlDataAdapter(cmdText, SqlConnection);
            DataSet ds = new DataSet();
            dt.Fill(ds);
            SqlConnection.Close();
            return ds.Tables[0];

        }

    }
}
