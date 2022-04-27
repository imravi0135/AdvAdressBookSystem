using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvAdressBookSystem
{
    internal class AddressBookException : Exception
    {
        ExceptionType type;
        public enum ExceptionType
        {
            Connection_Failed, Contact_Not_Add
        }
        public AddressBookException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
    
    
}
