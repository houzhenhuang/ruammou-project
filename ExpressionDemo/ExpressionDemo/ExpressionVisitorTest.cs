using ExpressionDemo.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionDemo
{
    public class ExpressionVisitorTest
    {
        public static void Show()
        {
            {
                Expression<Func<int, int, int>> exp = (m, n) => m * n + 2;

                OperationsVisitor visitor = new OperationsVisitor();
                Expression exp1 = visitor.Visit(exp);
                Expression expression = visitor.Modify(exp);
            }

            {

                Expression<Func<People, bool>> exp = (p) => p.Age > 5 && p.Id > 5&&p.Name.StartsWith("t");
                ConditionBuilderVisitor cond = new ConditionBuilderVisitor();
                cond.Visit(exp);
                string sResult = cond.Condition();
            }
        }
    }
}
