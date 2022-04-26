using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvAdressBookSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to AddressBook System Ado.Net Probblems");
            AddressBookConnection addressBookConnection = new AddressBookConnection();
            Details details = new Details();
            addressBookConnection.EstablishConnection();
            Console.WriteLine("Connection Established Successfully");
            Console.ReadLine();
        }
    }
}
