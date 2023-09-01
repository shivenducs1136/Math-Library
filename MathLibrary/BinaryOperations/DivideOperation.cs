using MathLibrary.Abstract;
using MathLibrary.Properties;
using System;
using System.Collections.Generic;

namespace MathLibrary.BinaryOperations
{
    public class DivideOperation : BinaryOperation
    {
        public DivideOperation(int precedence)
        {
            Precedence = precedence;
        }
        protected override double EvaluateCore(List<double> operands)
        {
            // Division is not possible when denominator is zero.
            if (operands[1] == 0)
            {
                throw new DivideByZeroException(Resources.DivideByZeroExceptionMsg); 
            }
            return operands[0] / operands[1];
            
        }
    }
}
