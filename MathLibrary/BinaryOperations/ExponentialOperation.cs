using MathLibrary.Abstract;
using System;
using System.Collections.Generic;

namespace MathLibrary.BinaryOperations
{
    public class ExponentialOperation:BinaryOperation
    {
        public ExponentialOperation( int precedence)
        {
            Precedence = precedence;
        }

        protected override double EvaluateCore(List<double> operands)
        {
            return Math.Pow(operands[0], operands[1]);
        }

    }
}
