using System;
using Pediatre.Training.NetPatterns.Visitor;

namespace Pediatre.Training.NetPatterns.Builder
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class OperatorAttribute : Attribute
    {
        public string OperatorSign { get; }

        public OperatorAttribute(string operatorSign)
        {
            OperatorSign = operatorSign;
        }
    }
    public interface IExpression : IAcceptVisitor
    {
        int Eval();
    }
    
    public sealed class ConstantExpression : IExpression, IAcceptVisitor
    {
        private readonly int _constantValue;

        public ConstantExpression(int constantValue)
        {
            _constantValue = constantValue;
        }

        public int Eval()
        {
            return _constantValue;
        }
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class VariableExpression : IExpression
    {
        public string VariableName { get; }

        public VariableExpression(string variableName)
        {
            VariableName = variableName;
        }

        public int Eval()
        {
            return State.Instance[VariableName];
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    [Operator("=")]
    public class AssignmentExpression : BinaryExpression
    {
        public AssignmentExpression(VariableExpression left, IExpression right)
            : base(left, right)
        { }

        public override int Eval()
        {
            var leftAsVar = (VariableExpression)Left;
            var rightVal = Right.Eval();
            State.Instance[leftAsVar.VariableName] = rightVal;

            return rightVal;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public abstract class BinaryExpression : IExpression
    {
        public IExpression Left { get; }
        public IExpression Right { get; }

        protected BinaryExpression(IExpression left, IExpression right)
        {
            Left = left;
            Right = right;
        }

        public abstract int Eval();
        public abstract void Accept(IVisitor visitor);
    }

    [Operator("+")]
    public class SumExpression : BinaryExpression, IAcceptVisitor
    {
        public SumExpression(IExpression left, IExpression right):base(left, right)
        {}

        public override int Eval()
        {
            return Left.Eval() + Right.Eval();
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    [Operator("*")]
    public class MultiplyExpression : BinaryExpression, IAcceptVisitor
    {
        public MultiplyExpression(IExpression left, IExpression right) : base(left, right)
        { }

        public override int Eval()
        {
            return Left.Eval() * Right.Eval();
        }
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    [Operator("-")]
    public class SubstractExpression : BinaryExpression, IAcceptVisitor
    {
        public SubstractExpression(IExpression left, IExpression right) : base(left, right)
        { }

        public override int Eval()
        {
            return Left.Eval() - Right.Eval();
        }
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}