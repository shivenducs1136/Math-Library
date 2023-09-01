using MathLibrary.Abstract;
using System.Collections.Generic;

namespace MathLibrary.UnaryOperations
{
    public class SignChangeOperation: UnaryOperation
    {
        public SignChangeOperation( int precedence)
    {
            Precedence = precedence;
    }
    protected override double EvaluateCore(List<double> operands)
    {
        return -1 * operands[0];
    }
}
}
