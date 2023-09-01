using MathLibrary.Exceptions;
using MathLibrary.Interface;
using MathLibrary.Properties;
using System;
using System.Collections.Generic;

namespace MathLibrary.Utils
{
    public class PostfixConverter
    {
        // Converting List of tokens into postfix format. 
        public static List<Token> Convert(List<Token> tokens, Dictionary<String, IOperations> operatorMap) 
        {
            // Adding closing braces to ensure the ending of the tokens. 
            tokens.Add(new Token(")",TokenType.RoundBracesClose));
            List<Token> postFix = new List<Token>();
            Stack<Token> tempStack = new Stack<Token>();

            // Pushing opening braces to stack to ensure starting of overall expression 
            tempStack.Push(new Token("(",TokenType.RoundBracesOpen));
            int len = tokens.Count;

            // Iterating the list of tokens
            for(int i =0; i < len;i++)
            {
                // If current token is Operand add it to resultant list. 
                if (tokens[i].Type == TokenType.Operand)
                {
                    postFix.Add(tokens[i]); 
                }
                // If current token is open braces then push it to temporary stack.
                else if (tokens[i].Type == TokenType.RoundBracesOpen)
                {
                    tempStack.Push((Token)tokens[i]);
                    if (i+1<len && tokens[i+1].Type == TokenType.Operator)
                    {
                        if(i+2<len && (tokens[i+2].Type == TokenType.Operand))
                        {
                            if (tokens[i+1].Value == "+")
                            {
                                i++; 
                            }
                            else
                            {
                                if (tokens[i + 2].Value[0] != '-')
                                { 
                                    string newValue = "-" + tokens[i + 2].Value;
                                    tokens[i + 2].Value = newValue;
                                    i++;
                                }
                                else 
                                {
                                    string newValue = tokens[i + 2].Value.Substring(1, tokens[i + 2].Value.Length);
                                    tokens[i + 2].Value = newValue; 
                                    i++; 
                                }
                            }
                        }
                    }
                }
                // If current token is close braces then pop and add to result until opening braces is not found.
                else if (tokens[i].Type == TokenType.RoundBracesClose)
                {
                    try
                    {
                        while (tempStack.Count > 0 && tempStack.Peek().Type != TokenType.RoundBracesOpen)
                        {
                            postFix.Add((Token)tempStack.Pop());
                        }
                        tempStack.Pop();
                    }
                    catch
                    {
                        throw new InvalidPositionException(Resources.InvalidPositionExceptionMsg);
                    }
                }
                /*
                   If current token is Operator then add it to answer until 
                   We find another opening braces and token from stack have higher precedence
                */
                else
                {
                    try
                    {
                        while (tempStack.Count > 0 && tempStack.Peek().Type != TokenType.RoundBracesOpen && operatorMap[tokens[i].Value].Precedence <= operatorMap[tempStack.Peek().Value].Precedence)
                        {
                            postFix.Add((Token)tempStack.Pop());
                        }
                    }
                    catch
                    {
                        throw new InvalidPositionException(Resources.InvalidPositionExceptionMsg);
                    }
                    tempStack.Push(tokens[i]);
                }

            }
            // finally pop out remaining elements if any, and add it to answer. 
            while (tempStack.Count > 0)
            {
                postFix.Add(tempStack.Pop());
            }
            // return the result.
            return postFix;
        }
    }
}
