using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.Exceptions
{
     class EntityNotFoundException : Exception
    {
        public EntityNotFoundException() : base("Requested entity was not found.") { }

        public EntityNotFoundException(string message) : base(message) { }

        public EntityNotFoundException(string message, Exception inner) : base(message, inner) { }
    
    
    }
}
