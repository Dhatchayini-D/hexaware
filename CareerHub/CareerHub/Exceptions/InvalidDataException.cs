using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.Exceptions
{
     class InvalidDataException : Exception
    {
        public InvalidDataException() : base("Invalid data provided.") { }

        public InvalidDataException(string message) : base(message) { }

        public InvalidDataException(string message, Exception inner) : base(message, inner) { }
    
    }
}
