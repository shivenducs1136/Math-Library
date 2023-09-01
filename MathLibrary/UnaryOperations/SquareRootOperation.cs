using MathLibrary.Abstract;
using MathLibrary.Exceptions;
using MathLibrary.Properties;
using System;
using System.Collections.Generic;

namespace MathLibrary.UnaryOperations
{
    public class SquareRootOperation : UnaryOperation
    {
        public SquareRootOperation(int precedence)
        {
            Precedence = precedence;
        }
        protected override double EvaluateCore(List<double> operands)
        {
            if (operands[0] < 0)
            {
                throw new NegativeNumberException(Resources.RootOfNegativeExceptionMsg); 
            }
            double sqrt = Math.Sqrt(operands[0]); 
            return sqrt;
        }
    }
}
