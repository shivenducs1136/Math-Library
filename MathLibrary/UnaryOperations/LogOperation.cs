using MathLibrary.Abstract;
using System;
using System.Collections.Generic;

namespace MathLibrary.UnaryOperations
{
    public class LogOperation : UnaryOperation
    {
        public LogOperation(int precedence)
        {
            Precedence = precedence;
        }
        protected override double EvaluateCore(List<double> operands)
        {
            return Math.Log10(operands[0]);
        }
    }
}
