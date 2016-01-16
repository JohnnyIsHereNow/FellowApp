using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryPOCA
{
    public class UserBusiness
    {

        private const string ConnString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Alexandru\Documents\FellowAppX\Programming\newPoca(eroareCreateUser)\POCA\ClassLibraryPOCA\Database.mdf;Integrated Security=True;Connect Timeout=30";
        public void RegisterUser(string fn,string ln,string email,string usr,string pass, DateTime bday, string imgURL)
        {
            ConnectionDB c = new ConnectionDB();
            c.OpenConnection(ConnString);
            c.InsertUser(fn, ln, email, usr, pass, bday, imgURL);
            c.CloseConnection();
        }
        public User GetUser(string u)
        {
            ConnectionDB c = new ConnectionDB();
            c.OpenConnection(ConnString);
            User user = c.GetUser(u);
            c.CloseConnection();
            return user;
        }
        public void UpdateUser(string usr,string fname,string lname,string pass, DateTime bday, string imgURL)
        {
            ConnectionDB c = new ConnectionDB();
            c.OpenConnection(ConnString);
            c.UpdateUser(usr,fname, lname, pass, bday, imgURL);
            c.CloseConnection();
        }
        public void DeleteUser(string usr)
        {
            ConnectionDB c = new ConnectionDB();
            c.OpenConnection(ConnString);
            c.DeleteUser(usr);
            c.CloseConnection();
        }

        public List<User> GetAllUsers()
        {
            ConnectionDB c = new ConnectionDB();
            c.OpenConnection(ConnString);
            List<User> allUsers = new List<User>();
            allUsers = c.GetAllUsers();
            c.CloseConnection();
            return allUsers;
        }

    }
}
