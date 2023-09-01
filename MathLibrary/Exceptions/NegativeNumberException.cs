using System;

namespace MathLibrary.Exceptions
{
    public class NegativeNumberException:Exception
    {
        public NegativeNumberException(string message)
       : base(message)
        { }
    }
}
