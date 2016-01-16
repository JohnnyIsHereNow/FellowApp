using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryPOCA
{
    public class BusinessClass
    {
        private const string connString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Alexandru\Documents\FellowAppX\Programming\ExaminationProjectT1\ClassLibraryPOCA\Database.mdf;Integrated Security=True;Connect Timeout=30";
        public void InsertNewUser(string first_name, string last_name, string email, string username, string password, DateTime birthdate, string imageURL)
        {
            DBConnection dbConn = new DBConnection();
            dbConn.OpenConnection(connString);
            dbConn.InsertUser(first_name, last_name, email, username, password, birthdate, imageURL);
            dbConn.CloseConnection();
        }
    }
}
