using MathLibrary.Interface;
using MathLibrary.Properties;
using System;
using System.Collections.Generic;

namespace MathLibrary.Abstract
{
    /*
        This class is used to evaluate all unary operations. 
        A Unary Operations must have one operand.
    */
    public abstract class UnaryOperation : IOperations
    {
        public int OperandCount { get { return 1;  } set { OperandCount = value; } }
        public int Precedence { get; set; }
        public double Evaluate(List<double> operands)
        {
            if (OperandCount == 1)
            {
                return EvaluateCore(operands);
            }
            else
            {
                throw new ArgumentException(Resources.ArgumentExceptionMsg);
            }
        }
        protected abstract double EvaluateCore(List<double> operands);

    }
}
