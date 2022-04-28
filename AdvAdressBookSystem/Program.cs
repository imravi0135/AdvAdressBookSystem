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
                Console.WriteLine("2: Add Contact");
                Console.WriteLine("3: Edit Contact");
                Console.WriteLine("4: Delete Contact");
                Console.WriteLine("5: For Exit");
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
                        Details addressbook = new Details();
                        Console.WriteLine("Enter a First Name for Edit Contact");
                        string firstname = Console.ReadLine();
                        addressbook.FirstName = firstname;
                        Console.WriteLine("Edit Last Name");
                        string lastname = Console.ReadLine();
                        addressbook.LastName = lastname;
                        Console.WriteLine("Edit Address");
                        string address = Console.ReadLine();
                        addressbook.Address = address;
                        Console.WriteLine("Edit City");
                        string city = Console.ReadLine();
                        addressbook.City = city;
                        addressBookConnection.EditContact(addressbook);
                        Console.WriteLine("Contact is Edited");
                        break;
                    case 4:
                        Details delete = new Details();
                        Console.WriteLine("Enter a First Name For Delete The Contact");
                        string first_name = Console.ReadLine();
                        delete.FirstName = first_name;
                        addressBookConnection.DeleteContact(delete);
                        break;
                    case 5:
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
    