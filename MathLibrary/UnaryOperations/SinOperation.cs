using MathLibrary.Abstract;
using System;
using System.Collections.Generic;


namespace MathLibrary.UnaryOperations
{
    public class SinOperation : UnaryOperation
    {
        public SinOperation(int precedence)
        {
            Precedence = precedence;
        }
        protected override double EvaluateCore(List<double> operands)
        {
            // converting value to radians
            double operandInRadian = (operands[0] * (Math.PI)) / 180;
            double result =  Math.Sin(operandInRadian) ;
            return result;
        }
    }
}
