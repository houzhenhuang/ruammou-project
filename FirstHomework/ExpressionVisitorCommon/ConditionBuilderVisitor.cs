using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using ExpressionVisitorCommon.DBExtend;
using ExpressionVisitorCommon.ConditionHelper;

namespace ExpressionVisitorCommon
{
    public class ConditionBuilderVisitor : ExpressionVisitor
    {
        private Stack<string> _StringStack = new Stack<string>();
        private Stack<string> _Parameter = new Stack<string>();
        public List<ParameterHelper> paramList = new List<ParameterHelper>();
        public string Condition()
        {
            string condition = string.Concat(this._StringStack.ToArray());
            this._StringStack.Clear();
            return condition;
        }
        protected override Expression VisitBinary(BinaryExpression node)
        {
            if (node == null) throw new ArgumentNullException("BinaryExpression");

            this._StringStack.Push(")");
            base.Visit(node.Right);
            this._StringStack.Push(" " + node.NodeType.ToSqlOperator() + " ");
            base.Visit(node.Left);
            this._StringStack.Push("(");

            return node;
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            if (node == null) throw new ArgumentNullException("MemberExpression");
            this._StringStack.Push(" [" + node.Member.Name + "] ");
            this._Parameter.Push("@" + node.Member.Name);

            this.paramList.Add(new ParameterHelper { Param = this._Parameter.Pop(), Value = this._Parameter.Pop() });
            return node;
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            if (node == null) throw new ArgumentNullException("ConstantExpression");
            this._StringStack.Push(" '" + node.Value + "' ");
            this._Parameter.Push(node.Value.ToString());
            return node;
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node == null) throw new ArgumentNullException("MethodCallExpression");

            string format;
            switch (node.Method.Name)
            {
                case "StartsWith":
                    format = "({0} LIKE '{1}%')";
                    break;
                case "EndsWith":
                    format = "({0} LIKE '%{1}')";
                    break;
                case "Contains":
                    format = "({0} LIKE '%{1}%')";
                    break;
                default:
                    throw new NotSupportedException(node.NodeType + " is not supported!");
            }
            this.Visit(node.Arguments[0]);
            this.Visit(node.Object);
            string left = this._StringStack.Pop();
            string right = this._StringStack.Pop().Replace("'", "").Replace(" ", "");
            this._StringStack.Push(String.Format(format, left, right));

            return node;
        }
    }
}
