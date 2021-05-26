using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciber.DataAccess.Exceptions
{
    public class AuthorizationException : System.Exception
    {
        public AuthorizationException()
            : base($"Not allowed to use this operation")
        {
        }
    }
}
