namespace MathLibrary.Utils
{
    
    class OperatorModel
    {
        public string symbol
        {
            get; set;
        }
        public string classFullName
        {
            get; set;
        }
        public int operandCount
        {
            get; set;
        }
        public int precedence
        {
            get; set;
        }
    }
}
