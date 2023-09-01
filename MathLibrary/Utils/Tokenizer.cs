using MathLibrary.Interface;
using MathLibrary.Properties;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MathLibrary.Utils
{
    public class Tokenizer
    {
        // Converting input string to a list of tokens
        public static List<Token> TokenizeExpression(String input, Dictionary<String, IOperations> operatorMap)
        {
            Regex regex = new Regex(@"/\(\+\s*\d\.?\d*\s*\)|\(\-\s*\d\.?\d*\s*\)|\d+(?:\.\d+)?|[a-z]+|\(|\)|\{|\}|\[|\]|\*|\+|\-|\/|\!|\./g");
            List<Token> tokens = new List<Token>();
            foreach (Match match in regex.Matches(input))
            {
                switch (match.Value)
                {
                    case "(":
                        {
                            tokens.Add(new Token("(", TokenType.RoundBracesOpen));
                           
                        }
                        break;
                    case ")":
                        tokens.Add(new Token(")", TokenType.RoundBracesClose));
                        break;
                    
                    
                    default:
                        if (operatorMap.ContainsKey(match.Value))
                        {
                            tokens.Add(new Token(match.Value, TokenType.Operator));
                        }
                        else
                        {
                            try
                            {
                                
								tokens.Add(new Token(match.Value, TokenType.Operand));


							}
							catch (FormatException f)
                            {
                                throw new FormatException(Resources.InvalidExpressionFormat);
                            }
                        }
                        break;
                }
            }
           
            return tokens;
        }

    }
}
  