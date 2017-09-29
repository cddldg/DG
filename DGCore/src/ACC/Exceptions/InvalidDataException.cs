using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Exceptions
{
    public class InvalidDataException : Exception
    {
        public InvalidDataException()
        {
        }
        public InvalidDataException(string message) : base(message)
        {
        }

        public InvalidDataException(string message, Exception ex) : base(message, ex)
        {
        }
    }
}
