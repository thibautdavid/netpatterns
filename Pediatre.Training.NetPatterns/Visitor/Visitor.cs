using System.Reflection;
using System.Text;
using Pediatre.Training.NetPatterns.Builder;

namespace Pediatre.Training.NetPatterns.Visitor
{
    public interface IVisitor
    {
        void Visit(VariableExpression expression);
        
        void Visit(BinaryExpression expression);
        void Visit(ConstantExpression expression);
        void Visit(AssignmentExpression expression);
    }

    public class Visitor : IVisitor
    {
        readonly StringBuilder _aggregate = new StringBuilder();

        public override string ToString()
        {
            return _aggregate.ToString();
        }

        public void Visit(VariableExpression expression)
        {
            _aggregate.Append($"{expression.VariableName}");
        }

        public void Visit(BinaryExpression expression)
        {
            expression.Left.Accept(this);
            _aggregate.Append($" {expression.GetType().GetCustomAttribute<OperatorAttribute>().OperatorSign} ");
            expression.Right.Accept(this);
        }

        public void Visit(AssignmentExpression expression)
        {
            _aggregate.Append("(");
            expression.Left.Accept(this);
            _aggregate.Append($" {expression.GetType().GetCustomAttribute<OperatorAttribute>().OperatorSign} ");
            expression.Right.Accept(this);
            _aggregate.Append(")");
        }

        public void Visit(ConstantExpression expression)
        {
            _aggregate.Append($"{expression.Eval()}");
        }
    }

    public interface IAcceptVisitor
    {
        void Accept(IVisitor visitor);
    }
}
