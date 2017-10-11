using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Exceptions
{
    public class ACCException : Exception
    {
        public ACCException()
        {
        }
        public ACCException(string message) : base(message)
        {
        }

        public ACCException(string message, Exception ex) : base(message, ex)
        {
        }
    }
}
