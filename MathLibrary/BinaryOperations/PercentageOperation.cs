using MathLibrary.Abstract;
using MathLibrary.Properties;
using System;
using System.Collections.Generic;


namespace MathLibrary.BinaryOperations
{
    public class PercentageOperation : BinaryOperation
    {
        public PercentageOperation( int precedence)
        {
            Precedence = precedence;
        }
        protected override double EvaluateCore(List<double> operands)
        {
            if (operands[1] == 0)
            {
                throw new DivideByZeroException(Resources.DivideByZeroExceptionMsg);
            }
            double result = (operands[0] / operands[1]);
            return result * 100;
        }
    }
}
