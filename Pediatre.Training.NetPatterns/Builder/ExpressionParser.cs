using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Pediatre.Training.NetPatterns.Builder
{
    public class ExpressionParser
    {
        public ExpressionParser()
        {
            var assembly = Assembly.GetExecutingAssembly();
            foreach (var type in assembly.GetTypes())
            {
                if (type.IsDefined(typeof(OperatorAttribute)))
                {
                    var attr = type.GetCustomAttribute<OperatorAttribute>();
                    _operators.Add(attr.OperatorSign, type);
                }
            }
        }

        /// <summary>
        /// 6 5 +       => 6 + 5        => 11
        /// 1 2 + 3 *   => (1 + 2) * 3  => 9
        /// 1 2 3 * +   => 1 + (2 * 3)  => 7
        /// </summary>
        public IExpression Parse(string input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));
            Stack<IExpression> stack = new Stack<IExpression>();
            
            var parts = input.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (var part in parts)
            {
                ParsePart(part, stack);
            }

            return stack.Pop();
        }

        private void ParsePart(string part, Stack<IExpression> stack)
        {
            int numberValue;
            if (int.TryParse(part, out numberValue))
            {
                stack.Push(new ConstantExpression(numberValue));
            }
            else
            {
                if (!IsOperator(part))
                {
                    throw new ArgumentException("Syntax error.", nameof(part));
                }
                AddOperatorExpressionInStack(part, stack);
            }
        }

        private void AddOperatorExpressionInStack(string part, Stack<IExpression> stack)
        {
            Type type = _operators[part];
            ConstructorInfo[] cis = type.GetConstructors();
            foreach (var ci in cis)
            {
                var paramInfo = ci.GetParameters();
                var fCheck = paramInfo.All(pi => pi.ParameterType == typeof (IExpression));
                if (fCheck)
                {
                    var args = new List<object>();
                    for (int i = 0; i < paramInfo.Length ; i++)
                    {
                        args.Insert(0, stack.Pop());
                    }
                    var expression = (IExpression) ci.Invoke(args.ToArray());
                    stack.Push(expression);
                    return;
                }
            }
        }

        private Dictionary<string, Type> _operators = new Dictionary<string, Type>();

        private bool IsOperator(string part)
        {
            return _operators.ContainsKey(part);
        }
    }
}