using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;

namespace WcfDatabaseConnection
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class DbConnectionService : IDbConnectionService
    {
        private SqlConnection sqlConnection;
        private SqlCommand cmd;
        private string conString;
        public void CreateConnection()
        {
            conString = @"Data Source = (LocalDB)\v11.0; AttachDbFilename = C:\Users\Alex\Documents\Xmas.mdf; Integrated Security = True; Connect Timeout = 30";
            sqlConnection = new SqlConnection(conString);
            cmd = new SqlCommand();
            sqlConnection.Open();
            /*
            string command = string.Format("Insert Into Guests (Name, Mail, Phone, IsAttending) VALUES ('{0}','{1}','{2}','{3}')", guestResponse.Name, guestResponse.Email, guestResponse.Phone, guestResponse.IsAttending);
            cmd.CommandText = command;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            */
        }
        public void CloseConnection()
        {
            sqlConnection.Close();
        }
        
        /*
        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.SqlConnection.State==System.Data.ConnectionState.Open)
            {
                composite.SqlConnection = "Suffix";
            }
            return composite;
        }*/
    }
}
