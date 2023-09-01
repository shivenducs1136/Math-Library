using MathLibrary.Abstract;
using System;
using System.Collections.Generic;

namespace MathLibrary.UnaryOperations
{
    public class SquareOperation : UnaryOperation
    {
        public SquareOperation(int precedence)
        {
            Precedence = precedence;
        }
        protected override double EvaluateCore(List<double> operands)
        {
            double power = Math.Pow(operands[0],2);
            return power;
        }
    }
}
