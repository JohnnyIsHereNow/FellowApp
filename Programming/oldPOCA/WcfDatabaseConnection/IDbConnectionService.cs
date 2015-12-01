using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;

namespace WcfDatabaseConnection
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IDbConnectionService
    {
        [OperationContract]
        void CreateConnection();

        [OperationContract]
        void CloseConnection();

      //  [OperationContract]
      //  CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "WcfDatabaseConnection.ContractType".
    [DataContract]
    public class CompositeType
    {
        SqlConnection sqlConnection;
        SqlConnection cmd;

        [DataMember]
        public SqlConnection SqlConnection
        {
            get { return sqlConnection; }
            set { sqlConnection = value; }
        }

        [DataMember]
        public SqlConnection Cmd
        {
            get { return cmd; }
            set { cmd = value; }
        }
    }
}
