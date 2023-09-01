using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary.Exceptions
{
    public class InvalidClassFullNameException:Exception
    {
        public InvalidClassFullNameException(string message) : base(message) { }   
    }
}
