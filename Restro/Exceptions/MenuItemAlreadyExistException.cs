using System;

namespace Restro.Exceptions
{
    public class MenuItemAlreadyExistsException : Exception
    {
        public MenuItemAlreadyExistsException()
        {
        }

        public MenuItemAlreadyExistsException(string message)
            : base(message)
        {
        }

        public MenuItemAlreadyExistsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
