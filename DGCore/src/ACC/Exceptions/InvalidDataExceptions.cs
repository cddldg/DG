using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Exceptions
{
    public class InvalidDataExceptions : Exception
    {
        public InvalidDataExceptions()
        {
        }
        public InvalidDataExceptions(string message) : base(message)
        {
        }

        public InvalidDataExceptions(string message, Exception ex) : base(message, ex)
        {
        }
    }
}
