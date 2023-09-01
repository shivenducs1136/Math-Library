using System;

namespace MathLibrary.Utils
{
    public class Token
    {
        public String Value;
        public TokenType Type;
        public Token(String value, TokenType type)
        {
            this.Value = value;
            this.Type = type;
        }
        public void Test()
        {
            Value = "";
        }
    }
}
