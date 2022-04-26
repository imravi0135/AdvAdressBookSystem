using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvAdressBookSystem
{
    public class AddressBookConnection
    {
        static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = AddressBookServiceDB; Integrated Security=SSPI;";
        static SqlConnection connection = new SqlConnection(connectionString);
        //UC-1 Check connection
        public  void EstablishConnection()
        {
            if (connection != null && connection.State.Equals(ConnectionState.Closed))
            {
                try
                {
                    connection.Open();
                }
                catch (Exception)
                {
                    throw new AddressBookException(AddressBookException.ExceptionType.Connection_Failed, "Connection failed..");
                }
            }
            if (connection != null && connection.State.Equals(ConnectionState.Open))
            {
                try
                {
                    connection.Close();
                }
                catch (Exception)
                {
                    throw new AddressBookException(AddressBookException.ExceptionType.Connection_Failed, "Connection failed..");
                }
            }
        }
    }
}
