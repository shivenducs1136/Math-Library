using MathLibrary.Exceptions;
using MathLibrary.Interface;
using MathLibrary.Properties;
using MathLibrary.Utils;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace MathLibrary.Evaluator
{
    // This class is used to evaluate any mathematical expression string.
    public class ExpressionEvaluator
    {
        /*
            operatorMap dictionary stores operator symbol as a key and
            the operation which is to be performed as a value.
         */
        private Dictionary<String, IOperations> _operatorMap;
        public ExpressionEvaluator()
        {
            Dictionary<String, IOperations> operatorMap = new Dictionary<String, IOperations>();
            
            try
            {
                string filePath = Directory.GetCurrentDirectory() + @"\Properties\OperatorJson.json";  
                string jsonString = File.ReadAllText(filePath); 
                List<OperatorModel> myOperatorList = JsonSerializer.Deserialize<List<OperatorModel>>(jsonString);
                foreach (OperatorModel model in myOperatorList)
                {
                    try
                    {
                        Type type = Type.GetType(model.classFullName, true);
                        if (type != null)
                        {
                            IOperations instance = (IOperations)Activator.CreateInstance(type, new object[]
                            {
                            Convert.ToInt32(model.precedence)
                            });
                            operatorMap.Add(model.symbol, instance);
                        }
                    }
                    catch 
                    {
                        throw new InvalidClassFullNameException(Resources.InvalidClassFullNameExceptionMsg);
                    }
                }
            }
            catch {
                throw new FileNotFoundException();
            }
            _operatorMap = operatorMap;
        }
        public Dictionary<String, IOperations> GetOperatorMap()
        {
            return _operatorMap;
        }
        public double EvaluateExpression(String expression)
        {
            if(expression.Length == 0)
            {
                expression = "0";
            }
            // converting expression to the list of tokens.
            List<Token> tokenizedString = Tokenizer.TokenizeExpression(expression, _operatorMap);
            /*
                converting that list of token to the postfix pattern, 
                which is also a list of token but in postfix format.
                */
            List<Token> pattern = PostfixConverter.Convert(tokenizedString, _operatorMap);
            // created temporary stack opStack which is used to store operators & operand and respected variables for processing result.
            Stack<Token> opStack = new Stack<Token>();
            double firstValue, secondValue, tempAns;
            // Iterating the postfix expression
            for (int j = 0; j < pattern.Count; j++)
            {
                // Checking if the operator is Binary Operator
                if (pattern[j].Type == TokenType.Operator && _operatorMap[pattern[j].Value].OperandCount == 2)
                {
                    // Popping out two operand from stack to perform Binary Operation
                    try
                    {
                        Token stackFirstElement = opStack.Pop();
                        Token stackSecondElement = opStack.Pop();
                        firstValue = Convert.ToDouble(stackSecondElement.Value);
                        secondValue = Convert.ToDouble(stackFirstElement.Value);

                        // Adding these element to the argument list, to perform operation
                        List<Double> argList = new List<Double>();
                        argList.Add(firstValue);
                        argList.Add(secondValue);
                        // Pushing temporary answer generated after operation for further usage
                        tempAns = _operatorMap[pattern[j].Value].Evaluate(argList);
                        opStack.Push(new Token(tempAns.ToString(), TokenType.Operand));
                    }
                    catch (DivideByZeroException e)
                    {
                        throw new DivideByZeroException(Resources.DivideByZeroExceptionMsg);

                    }
                    catch (NegativeNumberException e)
                    {
                        throw new NegativeNumberException(Resources.RootOfNegativeExceptionMsg);

                    }
                    catch (FormatException) 
                    {
                        throw new FormatException(Resources.InvalidOperandMsg); 
                    }
                    catch
                    {
                        throw new InvalidOperationException(Resources.InvalidBinaryOperation);
                    }

                        
                }
                // Checking if the operator is Unary Operator 
                else if (pattern[j].Type == TokenType.Operator && _operatorMap[pattern[j].Value].OperandCount == 1)
                {
                    try
                    {
                        // Popping out one operand from stack to perform Unary Operation
                        Token stackFirstElement = opStack.Pop();
                        secondValue = Convert.ToDouble(stackFirstElement.Value);

                        // Add the operand to the argument list. 
                        List<Double> argList = new List<Double>();
                        argList.Add(secondValue);

                        // Pushing temporary answer generated after operation for further usage
                        tempAns = _operatorMap[pattern[j].Value].Evaluate(argList);
                        opStack.Push(new Token(tempAns.ToString(), TokenType.Operand));

                    }
                    catch (DivideByZeroException e)
                    {
                        throw new DivideByZeroException(Resources.DivideByZeroExceptionMsg);

                    }
                    catch (NegativeNumberException e)
                    {
                        throw new NegativeNumberException(Resources.RootOfNegativeExceptionMsg);

                    }
                    catch (FormatException)
                    {
                        throw new FormatException(Resources.InvalidOperandMsg);
                    }
                    catch
                    {
                        throw new InvalidOperationException(Resources.InvalidUnaryOperation);
                    }


                }
				// Checking if the token is operand or not. 
				else if (pattern[j].Type == TokenType.Operand)
                {
					if (pattern[j].Value.Contains("+") || pattern[j].Value.Contains("-"))
					{
						Regex r = new Regex(@"\-\s*\d*\.?\d\d*|\+\s*\d*\.?\d\d*");
						StringBuilder sb = new StringBuilder();
						Match result = r.Match(pattern[j].Value);
						opStack.Push(new Token(result.Value, TokenType.Operand));

					}
                    else
					opStack.Push(pattern[j]);
                }
            }
            // finalizing and returning the answer. 
            try
            {         
                double answer = Convert.ToDouble(opStack.Pop().Value);
                return answer;
            }
            catch
            {
                throw new ExpressionEvaluateException(Resources.ExpressionEvaluationFailedMsg); 
            }
        }
       
    }
}
