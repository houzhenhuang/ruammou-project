using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern.Decorator
{
    public class StudentCoreDecorator : BaseStudentDecorator
    {
        public StudentCoreDecorator(AbstractStudent student)
            : base(student)
        {

        }
        public override void Show()
        {
            base.Show();
            Console.WriteLine("{0}在学习核心语法", base.Name);
        }
    }
}
