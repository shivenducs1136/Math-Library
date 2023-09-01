using System;

namespace MathLibrary.Exceptions
{
    public class InvalidPositionException:Exception
    {
        public InvalidPositionException(string errorMessage) 
        :base(errorMessage){ }
    }
}
