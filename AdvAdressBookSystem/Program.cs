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
            int option = 0;
            do
            {
                Console.WriteLine("1: Check Connection");
                Console.WriteLine("2: Get All Details");
                Console.WriteLine("3: For Exit");
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        addressBookConnection.EstablishConnection();
                        Console.WriteLine("Connection Established Successfully");
                        break;
                    case 2:
                        addressBookConnection.Add_Contact();

                        break;
                    case 3:
                        Console.WriteLine("Exit");
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
            }
            while (option != 0);
            Console.ReadKey();
        }
       
    }
}
    