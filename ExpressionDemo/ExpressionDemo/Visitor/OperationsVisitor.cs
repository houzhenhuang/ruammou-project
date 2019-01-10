using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionDemo.Visitor
{
    public class OperationsVisitor : ExpressionVisitor
    {
        public Expression Modify(Expression exp)
        {
            return this.Visit(exp);
        }
        protected override Expression VisitBinary(BinaryExpression node)
        {
            if (node.NodeType == ExpressionType.Add)
            {
                Expression exp1 = this.Visit(node.Left);
                Expression exp2 = this.Visit(node.Right);
                return Expression.Divide(exp1, exp2);
            }
            return base.VisitBinary(node);
        }
    }
}
