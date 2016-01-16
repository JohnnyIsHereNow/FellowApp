using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryPOCA
{
    class Business
    {

        private const string ConnString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Alexandru\Documents\FellowAppX\Programming\POCA\ClassLibraryPOCA\Database.mdf;Integrated Security=True;Connect Timeout=30";
        public void InsertAnUser(string fname,string lname,string mail,string usname,string pass,DateTime birth)
        {
            ConnectionDB c = new ConnectionDB();
            c.OpenConnection(ConnString);
            c.InsertUser(fname, lname, mail, usname, pass, birth);
            c.CloseConnection();
        }
        public User GetAnUser(string username)
        {
            ConnectionDB c = new ConnectionDB();
            c.OpenConnection(ConnString);
            User user = c.GetUser(username);
            c.CloseConnection();
            return user;
        }
        public void UpdateAnUser(string fname,string lname,string mail,string usname,string pass,DateTime birth)
        {
            ConnectionDB c = new ConnectionDB();
            c.OpenConnection(ConnString);
            c.UpdateUser(fname, lname, mail, usname, pass, birth);
            c.CloseConnection();
        }
        public void DeleteAnUser(string usname)
        {
            ConnectionDB c = new ConnectionDB();
            c.OpenConnection(ConnString);
            c.DeleteUser(usname);
            c.CloseConnection();
        }

    }
}
