using MathLibrary.Abstract;
using System.Collections.Generic;

namespace MathLibrary.BinaryOperations
{
    public class SubtractOperation : BinaryOperation
    {
        public SubtractOperation( int precedence)
        {
            Precedence = precedence;
        }
        protected override double EvaluateCore(List<double> operands)
        {
                return operands[0] - operands[1];
        }
    }
}
