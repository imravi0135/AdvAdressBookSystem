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
        static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = AddressBookServiceDB; Integrated Security=True;";
        static SqlConnection connection = new SqlConnection(connectionString);
        //UC-1 Check connection
        public void EstablishConnection()
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
        public   List<Details> CreateAddressBook()
        {
            List<Details> contacts = new List<Details>();
            Details details = new Details();
            SqlConnection connection = new SqlConnection(connectionString);
            string spname = "dbo.spAddressBook";
            using (connection)
            {
                SqlCommand sqlCommand = new SqlCommand(spname, connection);
                sqlCommand.CommandType  = System.Data.CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        details.FirstName = reader.GetString(1);
                        details.LastName = reader.GetString(2);
                        details.Address = reader.GetString(3);
                        details.City = reader.GetString(4);
                        details.State = reader.GetString(5);
                        details.Zip = reader.GetInt32(6);
                        details.PhoneNumber = reader.GetInt64(7);
                        details.Email = reader.GetString(8);
                        details.ContactType = reader.GetString(9);
                        
                        Console.WriteLine(details.FirstName + "," + details.LastName + "," + details.Address + "," + details.City + ","
                            + details.State + "," + details.Zip + "," + details.PhoneNumber + "," + details.Email + "," + details.ContactType +",");
                    }
                }
                else
                {
                    Console.WriteLine("No Data Found");
                }

                connection.Close();
                return contacts;
            }
        }
        public void Add_Contact()
        {
            List<Details> contacts = new List<Details>();
            Details contactDetails = new Details();
            Console.WriteLine("First Name :");
            contactDetails.FirstName = Console.ReadLine();
            Console.WriteLine("Last Name :");
            contactDetails.LastName = Console.ReadLine();
            Console.WriteLine("Address :");
            contactDetails.Address = Console.ReadLine();
            Console.WriteLine("City :");
            contactDetails.City = Console.ReadLine();
            Console.WriteLine("State :");
            contactDetails.State = Console.ReadLine();
            Console.WriteLine("Zip code :");
            contactDetails.Zip = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Phone Number :");
            contactDetails.PhoneNumber = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Email Id :");
            contactDetails.Email = Console.ReadLine();
            Console.WriteLine("Add ContactType :");
            contactDetails.ContactType = Console.ReadLine();
            SqlConnection connection = new SqlConnection(connectionString);
            string spname = "dbo.spAddressBook";
            using (connection)
            {
                SqlCommand sqlCommand = new SqlCommand(spname, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@FirstName", contactDetails.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", contactDetails.LastName);
                sqlCommand.Parameters.AddWithValue("@Address", contactDetails.Address);
                sqlCommand.Parameters.AddWithValue("@City", contactDetails.City);
                sqlCommand.Parameters.AddWithValue("@State", contactDetails.State);
                sqlCommand.Parameters.AddWithValue("@Zip", contactDetails.Zip);
                sqlCommand.Parameters.AddWithValue("@PhoneNumber", contactDetails.PhoneNumber);
                sqlCommand.Parameters.AddWithValue("@Email", contactDetails.Email);
                sqlCommand.Parameters.AddWithValue("@ContactType", contactDetails.ContactType);

                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                Console.WriteLine(contactDetails.FirstName + "," + contactDetails.LastName + "," + contactDetails.Address + ","
                    + contactDetails.City + "," + contactDetails.State + "," + contactDetails.Zip, ","
                    + contactDetails.PhoneNumber + "," + contactDetails.Email);

                connection.Close();
            }
        }
        public bool  EditContact(Details address)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("dbo.spEditContact", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", address.FirstName);
                    command.Parameters.AddWithValue("@LastName", address.LastName);
                    command.Parameters.AddWithValue("@Address", address.Address);
                    command.Parameters.AddWithValue("@City", address.City);
                    
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception)
            {
                throw new AddressBookException(AddressBookException.ExceptionType.Contact_Not_Add, "not add");
                return false;
            }
        }
    }
}
        
    

