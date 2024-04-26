using System;

namespace Restro.Exceptions
{
    public class CustomerAlreadyExistException : Exception
    {
        public CustomerAlreadyExistException(string message) : base(message)
        {
        }
    }
}
