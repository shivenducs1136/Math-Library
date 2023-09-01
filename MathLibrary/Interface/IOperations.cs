using System;
using System.Collections.Generic;


namespace MathLibrary.Interface
{
    public interface IOperations
    {
         int OperandCount { get; set; }
         int Precedence { get; set;  }
         double Evaluate(List<Double> operands);
    }
}
