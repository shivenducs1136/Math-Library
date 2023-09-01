using MathLibrary.Abstract;
using MathLibrary.Properties;
using System;
using System.Collections.Generic;

namespace MathLibrary.UnaryOperations
{
    public class ReciprocalOperation : UnaryOperation
    {
        public ReciprocalOperation(int precedence)
        {
            Precedence = precedence;
        }
        protected override double EvaluateCore(List<double> operands)
        {
            if (operands[0] == 0)
            {
                throw new DivideByZeroException(Resources.DivideByZeroExceptionMsg);
            }
            double _reciprocal = 1 / operands[0]; 
            return _reciprocal;
        }
    }
}
