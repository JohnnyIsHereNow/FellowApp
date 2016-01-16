using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace ClassLibraryPOCA
{
    class ConnectionDB
    {

        private SqlConnection sqlCn = null;
        public void OpenConnection(string connectionString)
        {
            sqlCn = new SqlConnection();
            sqlCn.ConnectionString = connectionString;
            sqlCn.Open();
        }

        public void CloseConnection()
        {
            sqlCn.Close();
        }

        public void InsertUser(string first_name, string last_name, string email, string username, string password, DateTime birthdate)
        {
            string sql = string.Format("Insert into User_tb" + "(first_name,last_name,email,username,password,birthdate) Values" +
                "('{0}', '{1}', '{2}', '{3}', '{4}', '{5}') ", first_name, last_name, email, username, password, birthdate);

            //Execute using the connection that we have already created
            using (SqlCommand cmd = new SqlCommand(sql, this.sqlCn))
            {
                cmd.ExecuteNonQuery();
            }
        }
        public User GetUser(string username)
         {
             User user = new User();
             string sql = string.Format("Select * FROM User_tb WHERE username == "+ username);
             //Execute using the connection that we have already created
             using (SqlCommand cmd = new SqlCommand(sql, this.sqlCn))
             {
                 SqlDataReader rd = cmd.ExecuteReader();

                 user.first_name = (string)rd["first_name"];
                 user.last_name = (string)rd["last_name"];
                 user.email = (string)rd["email"];
                 user.username = (string)rd["username"];
                 user.password = (string)rd["password"];
                 user.birthdate = (DateTime)rd["birthdate"];
             }
             return user;
         }
        public void UpdateUser(string first_name, string last_name, string email, string username, string password, DateTime birthdate) 
        {
            string sql = string.Format("Update User_tb SET first_name =" + first_name + "last_name =" + last_name + "password=" + password + "birthdate="+ birthdate+ "WHERE username=" + username);
            using (SqlCommand cmd = new SqlCommand(sql, this.sqlCn))
            {
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteUser(string username)
        {
            string sql = string.Format("Delete FROM User_tb Where username=" + username);
            using (SqlCommand cmd = new SqlCommand(sql, this.sqlCn))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}
