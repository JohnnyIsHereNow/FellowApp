using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryPOCA
{
    public class DBConnection
    {
        private SqlConnection sqlConn = null;

        public void OpenConnection(string connString)
        {
            sqlConn = new SqlConnection();
            try
            {
                sqlConn.ConnectionString = connString;
                sqlConn.Open();
            }
            catch (Exception E)
            {
                throw;
            }
        }

        public void CloseConnection()
        {
                sqlConn.Close();
        }

        public void InsertUser(string first_name, string last_name, string email, string username, string password, DateTime birthdate, string imageURL)
        {
            string sql = string.Format("Insert into User_tb" + "(first_name,last_name,email,username,password,birthdate, imageURL) Values" +
                "('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}' ) ", first_name, last_name, email, username, password, birthdate, imageURL);

            //Execute using the connection that we have already created
            using (SqlCommand cmd = new SqlCommand(sql, this.sqlConn))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch(Exception e)
                {
                    throw;
                }
            }
        }

    }
}
