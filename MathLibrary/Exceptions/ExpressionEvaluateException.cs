using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary.Exceptions
{
    public class ExpressionEvaluateException:Exception
    {
        public ExpressionEvaluateException(string message):base(message) { }
    }
}
