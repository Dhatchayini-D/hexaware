﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    internal class PaymentFailedException : Exception
    {
        public PaymentFailedException(string message) : base(message)
        {
        }
    }
}
