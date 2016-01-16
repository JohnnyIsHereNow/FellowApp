using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DatabaseServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        bool InsertNewUser(NewUser newUser);
        //[OperationContract]
        //bool GetUser(string user);
    }

    [DataContract]
    public class NewUser
    {
        [DataMember]
        public string fn { set; get; }
        [DataMember]
        public string ln { set; get; }
        [DataMember]
        public string email { set; get; }
        [DataMember]
        public string usr { set; get; }
        [DataMember]
        public string pass { set; get; }
        [DataMember]
        public DateTime bdate { set; get; }
        [DataMember]
        public string imgURL { set; get; }
    }
}
