using MathLibrary.Abstract;
using System.Collections.Generic;


namespace MathLibrary.BinaryOperations
{
    public class AddOperation : BinaryOperation
    {
        public AddOperation(int precedence) {
            Precedence = precedence;
        }
        protected override double EvaluateCore(List<double> operands)
        {
            return operands[0] + operands[1];
        }
    }
}
