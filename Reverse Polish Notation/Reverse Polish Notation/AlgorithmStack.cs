using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse_Polish_Notation
{
    internal class AlgorithmStack
    {
        static private bool IsDelimeter(char c)
        {
            if ((" =".IndexOf(c) != -1))
                return true;
            return false;
        }
        static private bool IsOperator(char с)
        {
            if (("+-/*^()".IndexOf(с) != -1))
                return true;
            return false;
        }
        static private byte GetPriority(char s)
        {
            switch (s)
            {
                case '(': return 0;
                case ')': return 1;
                case '+': return 2;
                case '-': return 3;
                case '*': return 4;
                case '/': return 4;
                case '^': return 5;
                default: return 6;
            }
        }
        /// <summary>
        /// Преобразовние в обратную польскую записиь стэком
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        static public string GetExpression(string input)
        {
            string output = string.Empty;
            Stack<char> operStack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if (IsDelimeter(input[i]))
                    continue;

                if (Char.IsDigit(input[i]) || !IsOperator(input[i]))
                {
                    while (!IsDelimeter(input[i]) && !IsOperator(input[i]))
                    {
                        output += input[i];
                        i++;

                        if (i == input.Length) break;
                    }

                    output += " ";
                    i--;
                }

                if (IsOperator(input[i]))
                {
                    if (input[i] == '(')
                        operStack.Push(input[i]);
                    else if (input[i] == ')')
                    {
                        char s = operStack.Pop();

                        while (s != '(')
                        {
                            output += s.ToString() + ' ';
                            s = operStack.Pop();
                        }

                    }
                    else
                    {
                        if (operStack.Count > 0)
                            if (GetPriority(input[i]) <= GetPriority(operStack.Peek()))
                                output += operStack.Pop().ToString() + " ";

                        operStack.Push(char.Parse(input[i].ToString()));

                    }
                }
            }

            while (operStack.Count > 0)
                output += operStack.Pop() + " ";

            return output;

        }
        /// <summary>
        /// Вычисление формулы в обратной польской записи стэком
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static double Calculate(string expression)
        {
            Stack<double> stack = new Stack<double>();

            string[] tokens = expression.Split(' ');

            foreach (string token in tokens)
            {
                if (token == "") break;
                if (double.TryParse(token, out double number)||!IsOperator(Convert.ToChar(token)))
                {
                    stack.Push(number);
                }
                else if (IsOperator(Convert.ToChar(token)))
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("Invalid expression.");
                    }

                    double right = stack.Pop();
                    double left = stack.Pop();

                    switch (token)
                    {
                        case "+":
                            stack.Push(left + right);
                            break;
                        case "-":
                            stack.Push(left - right);
                            break;
                        case "*":
                            stack.Push(left * right);
                            break;
                        case "/":
                            stack.Push(left / right);
                            break;
                    }
                }
                else
                {
                    throw new ArgumentException("Invalid expression.");
                }
            }

            if (stack.Count == 1)
            {
                return stack.Pop();
            }
            else
            {
                throw new ArgumentException("Invalid expression.");
            }
        }
    }
}
