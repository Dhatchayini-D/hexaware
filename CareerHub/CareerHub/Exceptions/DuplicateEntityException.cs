using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.Exceptions
{
     class DuplicateEntityException : Exception
    {
        public DuplicateEntityException() : base("Entity already exists.") { }

        public DuplicateEntityException(string message) : base(message) { }

        public DuplicateEntityException(string message, Exception inner) : base(message, inner) { }
    }
    
    }

