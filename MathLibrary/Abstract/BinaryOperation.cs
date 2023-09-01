using MathLibrary.Interface;
using MathLibrary.Properties;
using System;
using System.Collections.Generic;

namespace MathLibrary.Abstract
{
    /*
     This class is used to evaluate all binary operations. 
     A binary operations must have two operands on which operation is to be performed.
     */
    public abstract class BinaryOperation : IOperations
    {
        public int OperandCount { get { return 2; } set { OperandCount = value;  } }
        public int Precedence { get; set; }

        public double Evaluate(List<double> operands)
        {
            if (OperandCount == 2)
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
