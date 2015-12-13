using ClassLibraryPOCA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace UserServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        User RecordUser(InsertUser insertUser);

        [OperationContract]
        User GetUser(string username);

        [OperationContract]
        void UpdateUser(UpdateUser updateUser);

        [OperationContract]
        void DeleteUser(string usname);
        // TODO: Add your service operations here

        [OperationContract]
        List<User> GetAllUsers();
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "UserServiceLibrary.ContractType".
    [DataContract]
    public class InsertUser
    {

        [DataMember]
        public string fn { get; set; }

        [DataMember]
        public string ln { get; set; }

        [DataMember]
        public string email { get; set; }

        [DataMember]
        public string usr { get; set; }

        [DataMember]
        public string pass { get; set; }

        [DataMember]
        public DateTime bday { get; set; }

        [DataMember]
        public string imgURL { get; set; }

    }

    [DataContract]
    public class GetUser
    {

        [DataMember]
        public string username { get; set; }
    }


    [DataContract]
    public class UpdateUser
    {
        [DataMember]
        public string usr { get; set; }
        [DataMember]
        public string fn { get; set; }

        [DataMember]
        public string ln { get; set; }

        [DataMember]
        public string pass { get; set; }

        [DataMember]
        public DateTime bday { get; set; }

        [DataMember]
        public string imgURL { get; set; }
    }

    [DataContract]
    public class DeleteUser
    {
        [DataMember]
        public string usname { get; set; }
    }

}
