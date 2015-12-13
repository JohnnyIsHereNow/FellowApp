using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ClassLibraryPOCA;

namespace UserServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class UserService : IUserService
    {
        UserBusiness ctrl = new UserBusiness();
        public User RecordUser(InsertUser insertUser)
        {
            try
            {
                ctrl.RegisterUser(insertUser.fn, insertUser.ln, insertUser.email, insertUser.usr, insertUser.pass, insertUser.bday, insertUser.imgURL);
                //Here we need to have error handling not just returning true. 
                //I put it true to be able to test it as fast as i can.
                return GetUser(insertUser.usr);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public User GetUser(string username)
        {
          User user = ctrl.GetUser(username);
           return user;
        }

        public void UpdateUser(UpdateUser updateUser)
        {
            ctrl.UpdateUser(updateUser.usr,updateUser.fn, updateUser.ln, updateUser.pass, updateUser.bday, updateUser.imgURL);
        }

        public void DeleteUser(string usname)
        {
            ctrl.DeleteUser(usname);
        }

        public List<User> GetAllUsers()
        {
            List<User> allUsers = new List<User>();
            return allUsers = ctrl.GetAllUsers();
        }

    }
}
