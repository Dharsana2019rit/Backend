using System;

namespace Restro.Exceptions
{
    public class TableBookingNotFoundException : Exception
    {
        public TableBookingNotFoundException()
        {
        }

        public TableBookingNotFoundException(string message)
            : base(message)
        {
        }

        public TableBookingNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
