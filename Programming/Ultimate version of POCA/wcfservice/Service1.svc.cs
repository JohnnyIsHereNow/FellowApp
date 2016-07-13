using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using WcfService.ModelLayer;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private SqlConnection sqlConnection1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Alexandru\Documents\PocaJohnny\Poca\WcfService\App_Data\Database.mdf;Integrated Security=True");
        private SqlCommand cmd = new SqlCommand();

        public bool RegisterUser(string username, string password, string email, string name, int passion1, int passion2, int passion3,DateTime bday, int isAdvisor)
        {
            string tempdate2 = "" + bday.Year + "-" + bday.Month + "-" + bday.Day + " " + bday.Hour + ":00:00";
            string command = string.Format("Insert Into Users (Username, Pass, Email, Name, Passion1, Passion2, Passion3, BirthDate, isAdvisor) VALUES ('{0}','{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}')", username, password, email ,name, passion1, passion2, passion3, tempdate2.ToString(), isAdvisor);
                cmd.CommandText = command;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();
                cmd.ExecuteNonQuery();
                sqlConnection1.Close();
            return true;
        }
        public bool UpdateUser(string username, string password, string email, string name, int passion1, int passion2, int passion3, DateTime bday)
        {
            string tempdate2 = "" + bday.Year + "-" + bday.Month + "-" + bday.Day + " " + bday.Hour + ":00:00";

            string command = string.Format("Update Users SET Username='{0}', Pass='{1}', Email='{2}', Name='{3}', Passion1='{4}', Passion2='{5}', Passion3='{6}', BirthDate='{7}' WHERE Username ='{8}'", username, password, email, name, passion1, passion2, passion3, tempdate2.ToString(),username);
            cmd.CommandText = command;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
            cmd.ExecuteNonQuery();
            sqlConnection1.Close();
            return true;
        }

        public bool LoginUser(string username, string password)
        {
            int nr=0;
            string command = string.Format("Select Username, Pass from Users where Username = '"+username + "' AND Pass = '"+ password + "'");
            cmd.CommandText = command;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
            //cmd.ExecuteReader();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    nr++;
                }
            }
            sqlConnection1.Close();

            if (nr > 0)
            {
                return true;
            }
            return false;
        }

        public bool EmailExists(string email)
        {
            bool hasEmail = false;
            string command = string.Format("Select Email from Users where Email = '" + email + "'");
            cmd.CommandText = command;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    if (email.Equals(reader.GetValue(0).ToString()))
                    {
                        hasEmail = true;
                    }
                }
            }
            sqlConnection1.Close();
            return hasEmail;
        }

        public bool UsernameExists(string username)
        {
            bool hasUsername = false;
            string command = string.Format("Select Username from Users where Username = '" + username + "'");
            cmd.CommandText = command;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    if (username.Equals(reader.GetValue(0).ToString()))
                    {
                        hasUsername = true;
                    }
                }
            }
            sqlConnection1.Close();
            return hasUsername;
        }

        public bool InsertUserConnection(int id1,int id2)
        {
            bool ok = false;
            string command = string.Format("INSERT INTO CONNECTIONS(SenderId,ReceiverId,Accepted ) VALUES ('{0}','{1}','0') ",id1,id2);
            cmd.CommandText = command;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;
            
            sqlConnection1.Open();
            if (cmd.ExecuteNonQuery() != 0)
                ok = true;
            sqlConnection1.Close();
            return ok;
        }

        public User GetUserByUsername(string usrname)
        {
            string command = string.Format("Select Id, Username, Email, Name, Passion1, Passion2, Passion3, BirthDate from Users where Username = '" + usrname + "'");
            cmd.CommandText = command;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
            //cmd.ExecuteReader();
            User userFound = new User();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    userFound.Id = Int32.Parse(reader.GetValue(0).ToString());
                    userFound.Username = reader.GetValue(1).ToString();
                    userFound.Email = reader.GetValue(2).ToString();
                    userFound.Name = reader.GetValue(3).ToString();
                    userFound.Passion1 = Int32.Parse(reader.GetValue(4).ToString());
                    userFound.Passion2 = Int32.Parse(reader.GetValue(5).ToString());
                    userFound.Passion3 = Int32.Parse(reader.GetValue(6).ToString());
                    userFound.Bday = DateTime.Parse(reader.GetValue(7).ToString(), new System.Globalization.CultureInfo("fr-FR", true));
                 
                }
            }
            sqlConnection1.Close();
            return userFound;
        }

        public List<string> GetAllPassions()
        {
            List<string> passionList = new List<string>();
            string command = string.Format("Select Passion from Passions Where Active = 1");
            cmd.CommandText = command;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    passionList.Add(reader.GetValue(0).ToString());
                }
            }
            sqlConnection1.Close();
            return passionList;
        }

        public List<User> GetAllResults(int passion1, int passion2, int passion3,string realname)
        {
            List<int> results = new List<int>();            
            if (passion1 != 0)
            {
                string command = string.Format("Select id from Users Where Passion1 = '" + passion1 + "'" + " OR Passion1 = '" + passion2 + "'" + " OR Passion1 = '" + passion3 + "'");
                cmd.CommandText = command;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(Int32.Parse(reader.GetValue(0).ToString()));
                    }
                }
                sqlConnection1.Close();
            }
            if (passion2 != 0)
            {
                string command = string.Format("Select id from Users Where passion2 = '" + passion1 + "'" + " OR passion2 = '" + passion2 + "'" + " OR passion2 = '" + passion3 + "'");
                cmd.CommandText = command;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(Int32.Parse(reader.GetValue(0).ToString()));
                    }
                }
                sqlConnection1.Close();
            }
            if (passion3 != 0)
            {
                string command = string.Format("Select id from Users Where passion3 = '" + passion1 + "'" + " OR passion2 = '" + passion2 + "'" + " OR passion3  = '" + passion3 + "'");
                cmd.CommandText = command;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(Int32.Parse(reader.GetValue(0).ToString()));
                    }
                }
                sqlConnection1.Close();
            }
            List<User> users = new List<User>();

            int[] S = results.Distinct().ToArray();
            
            foreach (int i in S)
            {
                //i wanted to check if i am in the list too so prevent the program from showing myself.
                //if (i == Int32.Parse((request.Cookies.Get("userName").Value)))
                //{
                    string command = string.Format("Select Id, Username, Email, Name, Passion1, Passion2, Passion3 , BirthDate from Users where Id = '" + i + "'");
                    cmd.CommandText = command;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = sqlConnection1;

                    sqlConnection1.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!reader.GetValue(1).ToString().Equals(realname))
                            {
                                User user = new User();
                                user.Id = Int32.Parse(reader.GetValue(0).ToString());
                                user.Username = reader.GetValue(1).ToString();
                                user.Email = reader.GetValue(2).ToString();
                                user.Name = reader.GetValue(3).ToString();
                                user.Passion1 = Int32.Parse(reader.GetValue(4).ToString());
                                user.Passion2 = Int32.Parse(reader.GetValue(5).ToString());
                                user.Passion3 = Int32.Parse(reader.GetValue(6).ToString());
                                user.Bday = DateTime.Parse(reader.GetValue(7).ToString(), new System.Globalization.CultureInfo("fr-FR", true));
                                users.Add(user);
                            }
                        }
                    }
                    sqlConnection1.Close();
                    //==========================================================

                    foreach (User u in users)
                    {

                        command = string.Format("Select Passion from Passions where Id = '" + u.Passion1 + "'");
                        cmd.CommandText = command;
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = sqlConnection1;

                        sqlConnection1.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                u.Passion1String = reader.GetValue(0).ToString();
                            }
                        }
                        sqlConnection1.Close();

                        command = string.Format("Select Passion from Passions where Id = '" + u.Passion2 + "'");
                        cmd.CommandText = command;
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = sqlConnection1;

                        sqlConnection1.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                u.Passion2String = reader.GetValue(0).ToString();
                            }
                        }
                        sqlConnection1.Close();

                        command = string.Format("Select Passion from Passions where Id = '" + u.Passion3 + "'");
                        cmd.CommandText = command;
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = sqlConnection1;

                        sqlConnection1.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                u.Passion3String = reader.GetValue(0).ToString();
                            }
                        }
                        sqlConnection1.Close();
                    }
                }
            

            //User users2 = new User();
            //foreach (User u in users)
            //{

            //}


            return users;
        }
        public List<User> GetAllUsers(string realname)
        {
            int myid = GetUserByUsername(realname).Id;
            int[] values = GetAllMyConnections(myid);
            List<int> results = new List<int>();
            string command = string.Format("Select id from Users ");
            cmd.CommandText = command;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int hisId = Int32.Parse(reader.GetValue(0).ToString());
                    bool found = false;
                    int i = 0;
                    while (!found && i<100)
                    {
                        if((values[i]==myid && values[i+1]==hisId) || (values[i+1] == myid && values[i]== hisId))
                        {
                            found = true;
                        }
                        else
                        {
                            i += 2;
                        }
                    }
                    if (!found)
                    {
                        results.Add(hisId);
                    }

                    

                }
            }

            List<User> users = new List<User>();

            int[] S = results.Distinct().ToArray();
            sqlConnection1.Close();
            foreach (int i in S)
            {
                command = string.Format("Select Id, Username, Email, Name, Passion1, Passion2, Passion3 , BirthDate , isAdvisor from Users where Id = '" + i + "'");
                cmd.CommandText = command;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;
                sqlConnection1.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (!reader.GetValue(1).ToString().Equals(realname) && (Int32.Parse(reader.GetValue(8).ToString())!=1))
                        {
                            User user = new User();
                            user.Id = Int32.Parse(reader.GetValue(0).ToString());
                            user.Username = reader.GetValue(1).ToString();
                            user.Email = reader.GetValue(2).ToString();
                            user.Name = reader.GetValue(3).ToString();
                            user.Passion1 = Int32.Parse(reader.GetValue(4).ToString());
                            user.Passion2 = Int32.Parse(reader.GetValue(5).ToString());
                            user.Passion3 = Int32.Parse(reader.GetValue(6).ToString());
                            user.Bday = DateTime.Parse(reader.GetValue(7).ToString(), new System.Globalization.CultureInfo("fr-FR", true));
                            users.Add(user);
                        }
                    }
                }
                sqlConnection1.Close();
            }
            return users;
        }

        public List<User> GetAllConnections1(User myUser)
        {
            //Edit this
            List<int> results = new List<int>();
            if (myUser != null)
            {
                string command = string.Format("Select ReceiverId from Connections Where SenderId = '" + myUser.Id + "'" + " AND Accepted = '1' ");
                cmd.CommandText = command;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(Int32.Parse(reader.GetValue(0).ToString()));
                    }
                }

                command = string.Format("Select SenderId from Connections Where ReceiverId = '" + myUser.Id + "'" + " AND Accepted = '1' ");
                cmd.CommandText = command;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(Int32.Parse(reader.GetValue(0).ToString()));
                    }
                }



                sqlConnection1.Close();
            }

            List<User> users = new List<User>();
            foreach (int i in results)
            {
                string command = string.Format("Select Id, Username, Email, Name, Passion1, Passion2, Passion3, BirthDate from Users where Id = '" + i + "'");
                cmd.CommandText = command;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        User user = new User();
                        user.Id = Int32.Parse(reader.GetValue(0).ToString());
                        user.Username = reader.GetValue(1).ToString();
                        user.Email = reader.GetValue(2).ToString();
                        user.Name = reader.GetValue(3).ToString();
                        user.Passion1 = Int32.Parse(reader.GetValue(4).ToString());
                        user.Passion2 = Int32.Parse(reader.GetValue(5).ToString());
                        user.Passion3 = Int32.Parse(reader.GetValue(6).ToString());
                        user.Bday = DateTime.Parse(reader.GetValue(7).ToString(), new System.Globalization.CultureInfo("fr-FR", true));
                        users.Add(user);
                    }
                }
                sqlConnection1.Close();
                //==========================================================

                foreach (User u in users)
                {
                    command = string.Format("Select Passion from Passions where Id = '" + u.Passion1 + "'");
                    cmd.CommandText = command;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = sqlConnection1;

                    sqlConnection1.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            u.Passion1String = reader.GetValue(0).ToString();
                        }
                    }
                    sqlConnection1.Close();

                    command = string.Format("Select Passion from Passions where Id = '" + u.Passion2 + "'");
                    cmd.CommandText = command;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = sqlConnection1;

                    sqlConnection1.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            u.Passion2String = reader.GetValue(0).ToString();
                        }
                    }
                    sqlConnection1.Close();

                    command = string.Format("Select Passion from Passions where Id = '" + u.Passion3 + "'");
                    cmd.CommandText = command;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = sqlConnection1;

                    sqlConnection1.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            u.Passion3String = reader.GetValue(0).ToString();
                        }
                    }
                    sqlConnection1.Close();
                }
            }
            return users;
        }
        public List<User> GetAllConnections0(User myUser)
        {
            //Edit this
            List<int> results = new List<int>();
            if (myUser != null)
            {
                //string command = string.Format("Select ReceiverId from Connections Where SenderId = '" + myUser.Id + "'" + " AND Accepted = '0' ");
                //cmd.CommandText = command;
                //cmd.CommandType = CommandType.Text;
                //cmd.Connection = sqlConnection1;

                //sqlConnection1.Open();
                //using (SqlDataReader reader = cmd.ExecuteReader())
                //{
                //    while (reader.Read())
                //    {
                //        results.Add(Int32.Parse(reader.GetValue(0).ToString()));
                //    }
                //}
                sqlConnection1.Open();
                string command = string.Format("Select SenderId from Connections Where ReceiverId = '" + myUser.Id + "'" + " AND Accepted = '0' ");
                cmd.CommandText = command;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(Int32.Parse(reader.GetValue(0).ToString()));
                    }
                }



                sqlConnection1.Close();
            }



            List<User> users = new List<User>();
            foreach (int i in results)
            {
                string command = string.Format("Select Id, Username, Email, Name, Passion1, Passion2, Passion3, BirthDate from Users where Id = '" + i + "'");
                cmd.CommandText = command;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        User user = new User();
                        user.Id = Int32.Parse(reader.GetValue(0).ToString());
                        user.Username = reader.GetValue(1).ToString();
                        user.Email = reader.GetValue(2).ToString();
                        user.Name = reader.GetValue(3).ToString();
                        user.Passion1 = Int32.Parse(reader.GetValue(4).ToString());
                        user.Passion2 = Int32.Parse(reader.GetValue(5).ToString());
                        user.Passion3 = Int32.Parse(reader.GetValue(6).ToString());
                        user.Bday = DateTime.Parse(reader.GetValue(7).ToString(), new System.Globalization.CultureInfo("fr-FR", true));
                        users.Add(user);
                    }
                }
                sqlConnection1.Close();
                //==========================================================

                foreach (User u in users)
                {
                    command = string.Format("Select Passion from Passions where Id = '" + u.Passion1 + "'");
                    cmd.CommandText = command;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = sqlConnection1;

                    sqlConnection1.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            u.Passion1String = reader.GetValue(0).ToString();
                        }
                    }
                    sqlConnection1.Close();

                    command = string.Format("Select Passion from Passions where Id = '" + u.Passion2 + "'");
                    cmd.CommandText = command;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = sqlConnection1;

                    sqlConnection1.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            u.Passion2String = reader.GetValue(0).ToString();
                        }
                    }
                    sqlConnection1.Close();

                    command = string.Format("Select Passion from Passions where Id = '" + u.Passion3 + "'");
                    cmd.CommandText = command;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = sqlConnection1;

                    sqlConnection1.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            u.Passion3String = reader.GetValue(0).ToString();
                        }
                    }
                    sqlConnection1.Close();
                }
            }
            return users;
        }

        public List<User> GetAllPendingConnections(User myUser)
        {
            //Edit this
            List<int> results = new List<int>();
            if (myUser != null)
            {
                //string command = string.Format("Select ReceiverId from Connections Where SenderId = '" + myUser.Id + "'" + " AND Accepted = '0' ");
                //cmd.CommandText = command;
                //cmd.CommandType = CommandType.Text;
                //cmd.Connection = sqlConnection1;

                //sqlConnection1.Open();
                //using (SqlDataReader reader = cmd.ExecuteReader())
                //{
                //    while (reader.Read())
                //    {
                //        results.Add(Int32.Parse(reader.GetValue(0).ToString()));
                //    }
                //}
                sqlConnection1.Open();
                string command = string.Format("Select ReceiverId from Connections Where SenderId = '" + myUser.Id + "'" + " AND Accepted = '0' ");
                cmd.CommandText = command;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(Int32.Parse(reader.GetValue(0).ToString()));
                    }
                }



                sqlConnection1.Close();
            }



            List<User> users = new List<User>();
            foreach (int i in results)
            {
                string command = string.Format("Select Id, Username, Email, Name, Passion1, Passion2, Passion3, BirthDate from Users where Id = '" + i + "'");
                cmd.CommandText = command;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        User user = new User();
                        user.Id = Int32.Parse(reader.GetValue(0).ToString());
                        user.Username = reader.GetValue(1).ToString();
                        user.Email = reader.GetValue(2).ToString();
                        user.Name = reader.GetValue(3).ToString();
                        user.Passion1 = Int32.Parse(reader.GetValue(4).ToString());
                        user.Passion2 = Int32.Parse(reader.GetValue(5).ToString());
                        user.Passion3 = Int32.Parse(reader.GetValue(6).ToString());
                        user.Bday = DateTime.Parse(reader.GetValue(7).ToString(), new System.Globalization.CultureInfo("fr-FR", true));
                        users.Add(user);
                    }
                }
                sqlConnection1.Close();
                //==========================================================

                foreach (User u in users)
                {
                    command = string.Format("Select Passion from Passions where Id = '" + u.Passion1 + "'");
                    cmd.CommandText = command;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = sqlConnection1;

                    sqlConnection1.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            u.Passion1String = reader.GetValue(0).ToString();
                        }
                    }
                    sqlConnection1.Close();

                    command = string.Format("Select Passion from Passions where Id = '" + u.Passion2 + "'");
                    cmd.CommandText = command;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = sqlConnection1;

                    sqlConnection1.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            u.Passion2String = reader.GetValue(0).ToString();
                        }
                    }
                    sqlConnection1.Close();

                    command = string.Format("Select Passion from Passions where Id = '" + u.Passion3 + "'");
                    cmd.CommandText = command;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = sqlConnection1;

                    sqlConnection1.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            u.Passion3String = reader.GetValue(0).ToString();
                        }
                    }
                    sqlConnection1.Close();
                }
            }
            return users;
        }
        public string GetPassionById(int id)
        {
            string passion = "";
            string command = string.Format("Select Passion from Passions Where Id = " + id);
            cmd.CommandText = command;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    passion=reader.GetValue(0).ToString();
                }
            }
            sqlConnection1.Close();
            return passion;
        }
        public void CreateConnection(int t, int Id)
        {
            string command = string.Format("Update Connections SET Accepted=1 WHERE SenderId=" + t + " AND " + "ReceiverId=" + Id);

            cmd.CommandText = command;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
            cmd.ExecuteNonQuery();
            sqlConnection1.Close();
        }
        public void RemoveConnection(int t, int Id)
        {
            string command = string.Format("Delete FROM Connections WHERE SenderId=" + t + " AND " + "ReceiverId=" + Id);
            cmd.CommandText = command;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
            cmd.ExecuteNonQuery();

            command = string.Format("Delete FROM Connections WHERE SenderId=" + Id + " AND " + "ReceiverId=" + t);
            cmd.CommandText = command;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            cmd.ExecuteNonQuery();
            sqlConnection1.Close();
        }
        public int[] GetAllMyConnections(int myid)
        {
            int[] values = new int[100];
            sqlConnection1.Open();
            int counter = 0;
            string command = string.Format("Select SenderId, ReceiverId from Connections Where (SenderId = " + myid + " OR ReceiverId = "+myid+ " ) ");
            cmd.CommandText = command;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;
            
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {                    
                    values[counter]=Int32.Parse(reader.GetValue(0).ToString());
                    counter++;
                    values[counter]=Int32.Parse(reader.GetValue(1).ToString());
                    counter++;
                }
            }
            sqlConnection1.Close();
            return values;
        }
        public bool bookingExist(int id, DateTime date)
        {
            
            sqlConnection1.Open();
            string mydate;
            if (date.Hour < 10) 
            {
                 mydate = "" + date.Year + "-" + date.Month + "-" + date.Day + " 0" + date.Hour+":00:00";
            }
            else 
            {
                 mydate = "" + date.Year + "-" + date.Month + "-" + date.Day + " " + date.Hour+":00:00";
            }
            
            string command = string.Format("Select id, advisorId, bookingTime from Advisors Where (advisorId = " + id + " AND bookingTime = '" + mydate + "' ) ");
            cmd.CommandText = command;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;
            bool found= false;

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.HasRows)
                {
                    found = true;
                }
            }
            sqlConnection1.Close();
            return found;
        }
        public void insertBooking(int id, DateTime date)
        {
            string mydate;
            if (date.Hour < 10)
            {
                mydate = "" + date.Year + "-" + date.Month + "-" + date.Day + " 0" + date.Hour + ":00:00";
            }
            else
            {
                mydate = "" + date.Year + "-" + date.Month + "-" + date.Day + " " + date.Hour + ":00:00";
            }
            sqlConnection1.Open();
            string command = string.Format("Insert into Advisors(advisorId,bookingTime,isAvailable) VALUES ('{0}','{1}',0)",id,mydate);
            cmd.CommandText = command;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;
            cmd.ExecuteNonQuery();
            sqlConnection1.Close();
        }
        public List<User> GetAllAdvisors()
        {
            List<int> results = new List<int>();
            string command = string.Format("Select id from Users where isAdvisor = 1");
            cmd.CommandText = command;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                        results.Add(Int32.Parse(reader.GetValue(0).ToString()));
                }
            }
            List<User> users = new List<User>();

            int[] S = results.Distinct().ToArray();
            sqlConnection1.Close();
            foreach (int i in S)
            { 
                command = string.Format("Select Id, Username, Email, Name, Passion1, Passion2, Passion3 , BirthDate , isAdvisor from Users where Id = '" + i + "'");
                cmd.CommandText = command;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;
                sqlConnection1.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {      
                            User user = new User();
                            user.Id = Int32.Parse(reader.GetValue(0).ToString());
                            user.Username = reader.GetValue(1).ToString();
                            user.Email = reader.GetValue(2).ToString();
                            user.Name = reader.GetValue(3).ToString();
                            user.Passion1 = Int32.Parse(reader.GetValue(4).ToString());
                            user.Passion2 = Int32.Parse(reader.GetValue(5).ToString());
                            user.Passion3 = Int32.Parse(reader.GetValue(6).ToString());
                            user.Bday = DateTime.Parse(reader.GetValue(7).ToString(), new System.Globalization.CultureInfo("fr-FR", true));
                            users.Add(user);
                       
                    }
                }
                sqlConnection1.Close();
            }
            return users;
         }
        public List<string> GetAllAdvisorsDates(int id)
        {
            List<string> results = new List<string>();
            string command = string.Format("Select id, advisorId, bookingTime, isAvailable, currTime from Advisors where advisorId = " + id);
            cmd.CommandText = command;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (Int32.Parse(reader.GetValue(3).ToString()) != 2)
                    {
                        results.Add(reader.GetValue(2).ToString());
                    }
                }
            }
            return results;
        }
        public List<string> GetAllBookedDates(int advisorId, int userId)
        {
            string command;
            List<string> results = new List<string>();
            if (advisorId == userId)
            {
                 command = string.Format("Select id, advisorId, bookingTime, isAvailable, currTime from Advisors where (advisorId = " + userId + "And isAvailable = 2)");

            }
            else
            {
                 command = string.Format("Select id, advisorId, bookingTime, isAvailable, currTime from Advisors where (advisorId = " + advisorId + " AND userId=" + userId + "And isAvailable = 2)");
            }
            cmd.CommandText = command;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (Int32.Parse(reader.GetValue(3).ToString()) == 2)
                    {
                        results.Add(reader.GetValue(2).ToString());
                    }
                }
            }
            return results;
        }

        public List<string> GetAllAdvisorAvailableDates(int userId)
        {
            List<string> results = new List<string>();
            string command = string.Format("Select id, advisorId, bookingTime, isAvailable, currTime from Advisors where (advisorId = " + userId + "And isAvailable != 2)");
            cmd.CommandText = command;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (Int32.Parse(reader.GetValue(3).ToString()) != 2)
                    {
                        results.Add(reader.GetValue(2).ToString());
                    }
                }
            }
            return results;
        }
        public bool checkDateIsAvailable(int advisorId,string bookingTime, int userID)
        {
            DateTime tempdate = DateTime.Parse(bookingTime);
            string tempdate2 = "" + tempdate.Year + "-" + tempdate.Month + "-" + tempdate.Day + " " + tempdate.Hour + ":00:00";
            sqlConnection1.Open();
            string command = string.Format("Select id, advisorId, bookingTime, isAvailable, currTime, userId FROM Advisors Where (advisorId = " + advisorId + " AND bookingTime = '" + tempdate2 + "' AND isAvailable!= 2 ) ");
            cmd.CommandText = command;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;
            int value = 0;
            DateTime time = DateTime.Now;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    if (Int32.Parse(reader.GetValue(3).ToString()) == 0)
                    {
                        value = 0;
                    }
                    else if (Int32.Parse(reader.GetValue(3).ToString()) == 1)
                    {
                        value = 1;
                    }
                    if (value == 1)
                    {

                        DateTime currTime = DateTime.Parse(reader.GetValue(4).ToString());
                        TimeSpan ts = new TimeSpan(0, 1, 0);
                        currTime = currTime + ts;
                        if (currTime < time || Int32.Parse(reader.GetValue(5).ToString())==userID)
                        {
                            value = 0;
                        }
                        
                    }
                }
            }
            sqlConnection1.Close();
            sqlConnection1.Open();
            string time2 = "" + time.Year + "-" + time.Month + "-" + time.Day + " " + time.Hour + ":"+ time.Minute + ":"+time.Second;

            if (value == 0)
            {
                command = string.Format("Update Advisors SET isAvailable=0 Where (userId = " + userID + "AND isAvailable != 2)");
                cmd.CommandText = command;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;
                cmd.ExecuteNonQuery();

                command = string.Format("Update Advisors SET userId=" + userID +", isAvailable=1, currTime='"+ time2 + "' Where (advisorId = " + advisorId + " AND bookingTime = '" + tempdate2 + "');");
                cmd.CommandText = command;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;
                cmd.ExecuteNonQuery();
            }
            sqlConnection1.Close();
            if (value == 0)
            {
                return true;
            }
            return false;
        }
        public bool finishBook(int advisorId, string bookingTime, int userID)
        {
            bool found = false;
             DateTime tempdate = DateTime.Parse(bookingTime);
            string tempdate2 = "" + tempdate.Year + "-" + tempdate.Month + "-" + tempdate.Day + " " + tempdate.Hour + ":00:00";
            sqlConnection1.Open();
            string command = string.Format("Select id, advisorId, bookingTime, isAvailable, currTime, userId FROM Advisors Where (advisorId = " + advisorId + " AND bookingTime = '" + tempdate2 + "' AND isAvailable = 1 ) ");
            cmd.CommandText = command;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;
            DateTime time = DateTime.Now;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    found = true;
 
                }
            }
            sqlConnection1.Close();
            sqlConnection1.Open();
            string time2 = "" + time.Year + "-" + time.Month + "-" + time.Day + " " + time.Hour + ":"+ time.Minute + ":"+time.Second;

            if (found)
            {
                command = string.Format("Update Advisors SET userId=" + userID + ", isAvailable=2, currTime='" + time2 + "' Where (advisorId = " + advisorId + " AND bookingTime = '" + tempdate2 + "');");
                cmd.CommandText = command;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;
                cmd.ExecuteNonQuery();
            }
            
            sqlConnection1.Close();
            if (found)
            {
                return true;
            }
            return false;
        }
        public bool isAdvisor(int id)
        {
            bool isAdvisor = false;
            string command = string.Format("Select isAdvisor from Users where id = " + id);
            cmd.CommandText = command;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
            //cmd.ExecuteReader();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    if (Int32.Parse(reader.GetValue(0).ToString())==1)
                    {
                        isAdvisor = true;
                    }
                }   
            }
            sqlConnection1.Close();
            return isAdvisor;
        }
        public bool removeBook(int advisorId, string bookingTime,int userID)
        {
            bool found = false;
            DateTime tempdate = DateTime.Parse(bookingTime);
            string tempdate2 = "" + tempdate.Year + "-" + tempdate.Month + "-" + tempdate.Day + " " + tempdate.Hour + ":00:00";
            sqlConnection1.Open();
            string command = string.Format("Select id, advisorId, bookingTime, isAvailable, currTime, userId FROM Advisors Where (advisorId = " + advisorId + " AND bookingTime = '" + tempdate2 + "' AND isAvailable = 2 ) ");
            cmd.CommandText = command;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    found = true;

                }
            }
            sqlConnection1.Close();
            sqlConnection1.Open();

            if (found)
            {
                command = string.Format("Update Advisors SET userId=null" + ", isAvailable=0" +  " Where (advisorId = " + advisorId + " AND bookingTime = '" + tempdate2 + "');");
                cmd.CommandText = command;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;
                cmd.ExecuteNonQuery();
            }

            sqlConnection1.Close();
            if (found)
            {
                return true;
            }
            return false;
        }
        public bool deleteBook(int advisorId, string bookingTime, int userID)
        {
            bool found = false;
            DateTime tempdate = DateTime.Parse(bookingTime);
            string tempdate2 = "" + tempdate.Year + "-" + tempdate.Month + "-" + tempdate.Day + " " + tempdate.Hour + ":00:00";
            sqlConnection1.Open();
            string command = string.Format("Select id, advisorId, bookingTime, isAvailable, currTime, userId FROM Advisors Where (advisorId = " + userID + " AND bookingTime = '" + tempdate2 + "' AND isAvailable != 2 ) ");
            cmd.CommandText = command;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    found = true;

                }
            }
            sqlConnection1.Close();
            sqlConnection1.Open();

            if (found)
            {
                command = string.Format("DELETE FROM Advisors Where (advisorId = " + userID + " AND bookingTime = '" + tempdate2 + "');");
                cmd.CommandText = command;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;
                cmd.ExecuteNonQuery();
            }

            sqlConnection1.Close();
            if (found)
            {
                return true;
            }
            return false;
        }

    }
    
}
