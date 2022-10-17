﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCamp.Application.Exceptions
{
    public class AuthenticationErrorException : Exception
    {
        public AuthenticationErrorException():base("Kimlik doğrulama hatalı...")
        {
        }

        public AuthenticationErrorException(string? message) : base(message)
        {
        }

        public AuthenticationErrorException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
