using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfService.ModelLayer;
using System.Data;
using System.Data.SqlClient;
namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        bool RegisterUser(string username, string password, string email, string name, int passion1, int passion2, int passion3, DateTime bday);

        [OperationContract]
        bool UpdateUser(string username, string password, string email, string name, int passion1, int passion2, int passion3, DateTime bday);

        [OperationContract]
        bool LoginUser(string username, string password);

        [OperationContract]
        bool EmailExists(string email);

        [OperationContract]
        bool UsernameExists(string username);

        [OperationContract]
        List<string> GetAllPassions();

        [OperationContract]
        List<User> GetAllResults(int passion1, int passion2, int passion3,string realname);

        [OperationContract]
        List<User> GetAllConnections1(User myUser);

        [OperationContract]
        List<User> GetAllConnections0(User myUser);

        [OperationContract]
        User GetUserByUsername(string usrname);
        [OperationContract]
        bool InsertUserConnection(int id1, int id2);
        [OperationContract]
        string GetPassionById(int id);
        [OperationContract]
        void CreateConnection(int t, int Id);
        [OperationContract]
        void RemoveConnection(int t, int Id);
        [OperationContract]
        List<User> GetAllUsers(string realname);
    }
}
