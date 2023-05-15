
namespace Reverse_Polish_Notation
{
    class Node
    {
        public string value;
        public Node left;
        public Node right;

        public Node(string value)
        {
            this.value = value;
            this.left = null;
            this.right = null;
        }
    }

    class AlgorithmTree
    {
        private static Dictionary<string, int> operators = new Dictionary<string, int>()
    {
        { "+", 1 },
        { "-", 1 },
        { "*", 2 },
        { "/", 2 }
    };
        private static bool IsDelimeter(char c)
        {
            if ((" =".IndexOf(c) != -1))
                return true;
            return false;
        }

        private static bool IsOperator(string token)
        {
            return operators.ContainsKey(token);
        }

        private static bool IsOperator(char с)
        {
            if (("+-/*^()".IndexOf(с) != -1))
                return true;
            return false;
        }

        private static bool IsDigit(string token)
        {
            double number;
            return double.TryParse(token, out number);
        }
        
        /// <summary>
        /// Создание бинарного дерева
        /// </summary>
        /// <param name="tokens"></param>
        /// <returns></returns>
        private static Node BuildExpressionTree(List<string> tokens)
        {
            Stack<Node> stack = new Stack<Node>();

            foreach (string token in tokens)
            {
                if (IsDigit(token)|| !IsOperator(token))
                {
                    stack.Push(new Node(token));
                }
                else if (IsOperator(token))
                {
                    Node right = stack.Pop();
                    Node left = stack.Pop();
                    Node operatorNode = new Node(token);
                    operatorNode.left = left;
                    operatorNode.right = right;
                    stack.Push(operatorNode);
                }
            }

            return stack.Pop();
        }

        /// <summary>
        /// Перезапись исходной строки
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        static public string ListInput(string input)
        {
            string output = string.Empty;
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
                    output += input[i];
                    output += " ";
                }
            }
            return output;
        }

        /// <summary>
        /// Заполнение бинарного дерева
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        private static List<string> ConvertToReversePolishNotation(string expression)
        {
            List<string> tokens = new List<string>(ListInput(expression).Split(' '));
            List<string> outputQueue = new List<string>();
            Stack<string> operatorStack = new Stack<string>();

            foreach (string token in tokens)
            {
                if (IsDigit(token)||!IsOperator(token))
                {
                    outputQueue.Add(token);
                }
                else if (IsOperator(token))
                {
                    while (operatorStack.Count > 0 && IsOperator(operatorStack.Peek()) && operators[token] <= operators[operatorStack.Peek()])
                    {
                        outputQueue.Add(operatorStack.Pop());
                    }
                    operatorStack.Push(token);
                }
                else if (token == "(")
                {
                    operatorStack.Push(token);
                }
                else if (token == ")")
                {
                    while (operatorStack.Count > 0 && operatorStack.Peek() != "(")
                    {
                        outputQueue.Add(operatorStack.Pop());
                    }
                    operatorStack.Pop();
                }
            }

            while (operatorStack.Count > 0)
            {
                outputQueue.Add(operatorStack.Pop());
            }

            return outputQueue;
        }

        /// <summary>
        /// Преобразование в обратную польскую запись деревом
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static string ConvertToReversePolishNotationString(string expression)
        {
            List<string> tokens = ConvertToReversePolishNotation(expression);
            Node expressionTree = BuildExpressionTree(tokens);
            return TraverseExpressionTree(expressionTree) + "\nРезультат вычисления:" + Convert.ToString(Calculate(expressionTree));
        }

        /// <summary>
        /// Проход по бинарному дереву
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private static string TraverseExpressionTree(Node node)
        {
            if (node == null)
            {
                return "";
            }

            string left = TraverseExpressionTree(node.left);
            string right = TraverseExpressionTree(node.right);

            if (left != "" && right != "")
            {
                return left + " " + right + " " + node.value;
            }
            else
            {
                return node.value;
            }
        }

        /// <summary>
        /// Вычисление формулы в обратной польской записи деревом
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static double Calculate(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            if (double.TryParse(node.value, out double result))
            {
                return result;
            }

            double leftValue = Calculate(node.left);
            double rightValue = Calculate(node.right);

            switch (node.value)
            {
                case "+":
                    return leftValue + rightValue;
                case "-":
                    return leftValue - rightValue;
                case "*":
                    return leftValue * rightValue;
                case "/":
                    return leftValue / rightValue;
                default:
                    return 0;
            }
        }
    }
}
