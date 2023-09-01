using MathLibrary.Abstract;
using MathLibrary.Properties;
using System;
using System.Collections.Generic;


namespace MathLibrary.UnaryOperations
{
    public class LognOperation : UnaryOperation
    {
        public LognOperation(int precedence)
        {
            Precedence = precedence;
        }
        protected override double EvaluateCore(List<double> operands)
        {
            return Math.Log(operands[0]);
        }
    }
}
