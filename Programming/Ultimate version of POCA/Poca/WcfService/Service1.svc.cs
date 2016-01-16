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
        private SqlConnection sqlConnection1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Alexandru\Documents\Poca\WcfService\App_Data\Database.mdf;Integrated Security=True");
        private SqlCommand cmd = new SqlCommand();

        public bool RegisterUser(string username, string password, string email, string name, int passion1, int passion2, int passion3,DateTime bday)
        {
            string command = string.Format("Insert Into Users (Username, Pass, Email, Name, Passion1, Passion2, Passion3, BirthDate) VALUES ('{0}','{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')", username, password, email ,name, passion1, passion2, passion3, bday.ToString());
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
            string command = string.Format("Update Users SET Username='{0}', Pass='{1}', Email='{2}', Name='{3}', Passion1='{4}', Passion2='{5}', Passion3='{6}', BirthDate='{7}' WHERE Username ='{8}'", username, password, email, name, passion1, passion2, passion3, bday.ToString(),username);
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
            //check here
            return false;
        }

        public bool UsernameExists(string username)
        {
            //check here
            return false;
        }

        public bool InsertUserConnection(int id1,int id2)
        {
            bool ok = false;
            string command = string.Format("INSERT INTO CONNECTIONS(SenderId,ReceiverId,Accepted ) VALUES ('{0}','{1}','1') ",id1,id2);
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
    }
}
