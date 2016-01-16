using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using ClassLibraryPOCA;

namespace DatabaseServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class UserService : IUserService
    {
        public bool InsertNewUser(NewUser newUsr)
        {
            BusinessClass usrCTR = new BusinessClass();
            try
            {
                usrCTR.InsertNewUser(newUsr.fn, newUsr.ln, newUsr.email, newUsr.usr, newUsr.pass, newUsr.bdate, newUsr.imgURL);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
